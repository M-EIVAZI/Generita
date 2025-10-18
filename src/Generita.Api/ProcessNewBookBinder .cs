using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;
using Microsoft.Net.Http.Headers;
using Generita.Application.Common.Dtos;

public class ProcessNewBookBinder : IModelBinder
{
    private static readonly Regex SituationalRegex = new(@"^situational_audio_(\d+)_(\d+)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private const string AbstractPrefix = "abstract_audio_";

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var httpContext = bindingContext.HttpContext;
        var request = httpContext.Request;

        // اطمینان از multipart
        if (!request.HasFormContentType)
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Request is not multipart/form-data");
            bindingContext.Result = ModelBindingResult.Failed();
            return;
        }

        // بخوان فرم (اینجا ReadFormAsync امنه؛ binder اینو می‌خونه و مدل را پر می‌کنه)
        var form = await request.ReadFormAsync();

        var dto = new ProcessNewBookCommand
        {
            Title = form["Title"].FirstOrDefault(),
            Synopsis = form["Synopsis"].FirstOrDefault(),
            Access = form["Access"].FirstOrDefault(),
            PublishedDate = form["PublishedDate"].FirstOrDefault(),
            CategoryId = form["CategoryId"].FirstOrDefault(),
            AuthorId = form["AuthorId"].FirstOrDefault(),
            ConfigJson = form["config_json"].FirstOrDefault(),
            Image = form.Files.FirstOrDefault(f => string.Equals(f.Name, "Image", StringComparison.OrdinalIgnoreCase)),
            File = form.Files.FirstOrDefault(f => string.Equals(f.Name, "file", StringComparison.OrdinalIgnoreCase))
        };

        foreach (var file in form.Files)
        {
            // توجه: Name ممکنه شامل فاصله یا encode باشه؛ sanitize/trim quotes
            var name = file.Name?.Trim('"') ?? string.Empty;

            // اگر abstract
            if (name.StartsWith(AbstractPrefix, StringComparison.OrdinalIgnoreCase))
            {
                var raw = name.Substring(AbstractPrefix.Length);
                try { raw = Uri.UnescapeDataString(raw); } catch { /* ignore */ }

                if (!dto.AbstractAudios.ContainsKey(raw))
                    dto.AbstractAudios[file.Name] = file;
            }
            else if (name.StartsWith("situational_audio_", StringComparison.OrdinalIgnoreCase))
            {
                var match = SituationalRegex.Match(name);
                if (match.Success)
                {
                        dto.SituationalAudios[file.Name] = file;
                }
            }
        }

        bindingContext.Result = ModelBindingResult.Success(dto);
    }
}
