[CmdletBinding()]
param(
    [string]$ApiBaseUrl = "http://localhost:7161",
    [switch]$TestRedisOutage
)

$ErrorActionPreference = "Stop"
$healthEndpoint = "$($ApiBaseUrl.TrimEnd('/'))/health"

Write-Host "Checking PostgreSQL and Redis through $healthEndpoint..." -ForegroundColor Cyan
$healthResponse = Invoke-RestMethod -Uri $healthEndpoint -Method Get

if ($healthResponse.status -ne "Healthy") {
    throw "System health is '$($healthResponse.status)' instead of 'Healthy'."
}

foreach ($requiredCheck in @("postgresql", "redis")) {
    $check = $healthResponse.checks |
        Where-Object { $_.name -eq $requiredCheck } |
        Select-Object -First 1

    if ($null -eq $check) {
        throw "Health response does not contain the '$requiredCheck' check."
    }

    if ($check.status -ne "Healthy") {
        throw "Health check '$requiredCheck' failed: $($check.description)"
    }

    Write-Host "PASS: $requiredCheck - $($check.description)" -ForegroundColor Green
}

$redisCacheTest = Join-Path $PSScriptRoot "Test-RedisCache.ps1"
if (-not (Test-Path -LiteralPath $redisCacheTest)) {
    throw "Redis cache test was not found at '$redisCacheTest'."
}

Write-Host "Checking the application cache flow..." -ForegroundColor Cyan
if ($TestRedisOutage) {
    & $redisCacheTest -ApiBaseUrl $ApiBaseUrl -TestRedisOutage
}
else {
    & $redisCacheTest -ApiBaseUrl $ApiBaseUrl
}

Write-Host "PASS: database connectivity and Redis cache behavior are healthy." -ForegroundColor Green
