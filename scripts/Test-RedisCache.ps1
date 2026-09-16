[CmdletBinding()]
param(
    [string]$ApiBaseUrl = "http://localhost:7161",
    [switch]$TestRedisOutage
)

$ErrorActionPreference = "Stop"
$cacheKey = "generita:Home"
$endpoint = "$($ApiBaseUrl.TrimEnd('/'))/api/Home"

function Invoke-Compose {
    param([Parameter(Mandatory)][string[]]$Arguments)

    $output = & docker compose @Arguments 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "docker compose $($Arguments -join ' ') failed:`n$($output | Out-String)"
    }

    return $output
}

function Invoke-Redis {
    param([Parameter(Mandatory)][string[]]$Arguments)

    $output = Invoke-Compose -Arguments (@("exec", "-T", "redis", "redis-cli") + $Arguments)
    return ($output | Select-Object -Last 1).ToString().Trim()
}

Write-Host "Checking Docker Compose services..." -ForegroundColor Cyan
$runningServices = Invoke-Compose -Arguments @("ps", "--status", "running", "--services")
if ($runningServices -notcontains "redis") {
    throw "Required service 'redis' is not running. Run: docker compose up -d redis"
}
$apiRunsInCompose = $runningServices -contains "generita.api"

Write-Host "Removing only '$cacheKey'..." -ForegroundColor Cyan
[void](Invoke-Redis -Arguments @("DEL", $cacheKey))

$startedAt = Get-Date

Write-Host "Sending the first request; this must execute the query handler..." -ForegroundColor Cyan
$firstResponse = (Invoke-WebRequest -Uri $endpoint -UseBasicParsing).Content

$exists = [int](Invoke-Redis -Arguments @("EXISTS", $cacheKey))
$ttl = [int](Invoke-Redis -Arguments @("TTL", $cacheKey))
$redisType = Invoke-Redis -Arguments @("TYPE", $cacheKey)

if ($exists -ne 1) {
    throw "The first request succeeded, but Redis key '$cacheKey' was not created."
}

if ($ttl -le 0 -or $ttl -gt 1800) {
    throw "Unexpected TTL for '$cacheKey': $ttl seconds. Expected 1..1800."
}

Write-Host "Sending the second request; this must be served from Redis..." -ForegroundColor Cyan
Start-Sleep -Milliseconds 1100
$secondResponse = (Invoke-WebRequest -Uri $endpoint -UseBasicParsing).Content
$ttlAfterSecondRequest = [int](Invoke-Redis -Arguments @("TTL", $cacheKey))

if ($firstResponse -ne $secondResponse) {
    throw "The two responses are different. Cache correctness could not be confirmed."
}

if ($ttlAfterSecondRequest -le 0 -or $ttlAfterSecondRequest -gt $ttl) {
    throw "The cache TTL was unexpectedly refreshed by the second request: $ttl -> $ttlAfterSecondRequest seconds."
}

if ($apiRunsInCompose) {
    $since = $startedAt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
    $apiLogs = Invoke-Compose -Arguments @("logs", "--since", $since, "generita.api")
    $logText = $apiLogs | Out-String

    $hasMiss = $logText -match "Cache Miss for Home"
    $hasSet = $logText -match "Cache Set for Home"
    $hasHit = $logText -match "Cache Hit for Home"

    if (-not ($hasMiss -and $hasSet -and $hasHit)) {
        throw @"
The Redis key and responses are valid, but the expected Miss/Set/Hit log sequence was not found.
Open Seq at http://localhost:5341 and filter with: CacheKey = 'Home'
"@
    }
}
else {
    Write-Warning "The API is not running as the Compose 'generita.api' service, so container-log verification was skipped. Verify Seq with: CacheKey = 'Home'"
}

Write-Host "PASS: Miss -> Set -> Hit was confirmed." -ForegroundColor Green
Write-Host "Redis key: $cacheKey" -ForegroundColor Green
Write-Host "Redis type: $redisType" -ForegroundColor Green
Write-Host "TTL after first request: $ttl seconds" -ForegroundColor Green
Write-Host "TTL after cached request: $ttlAfterSecondRequest seconds" -ForegroundColor Green

if ($TestRedisOutage) {
    Write-Host "Stopping Redis to verify fail-open behavior..." -ForegroundColor Yellow
    [void](Invoke-Compose -Arguments @("stop", "redis"))

    try {
        $outageResponse = (Invoke-WebRequest -Uri $endpoint -UseBasicParsing).Content
        if ([string]::IsNullOrWhiteSpace($outageResponse)) {
            throw "The API returned an empty response while Redis was unavailable."
        }

        Write-Host "PASS: the API still responded while Redis was unavailable." -ForegroundColor Green
    }
    finally {
        Write-Host "Starting Redis again..." -ForegroundColor Yellow
        [void](Invoke-Compose -Arguments @("start", "redis"))
    }
}

Write-Host "Seq verification: http://localhost:5341  |  CacheKey = 'Home'" -ForegroundColor Cyan
