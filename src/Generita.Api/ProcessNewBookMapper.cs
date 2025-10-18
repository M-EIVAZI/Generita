using Generita.Application.Common.Dtos;
using Generita.Domain.Common.Enums;

public static class ProcessNewBookMapper
{
    public static ProcessNewBookDto ToCommand(this ProcessNewBookCommand dto)
    {
        // Parsing fail-safe
        if (!DateOnly.TryParse(dto.PublishedDate, out var publishedDate))
            throw new ArgumentException("Invalid PublishedDate");

        if (!Enum.TryParse<BookAccess>(dto.Access, true, out var access))
            throw new ArgumentException("Invalid Access");

        if (!Guid.TryParse(dto.CategoryId, out var categoryId))
            throw new ArgumentException("Invalid CategoryId");

        if (!Guid.TryParse(dto.AuthorId, out var authorId))
            throw new ArgumentException("Invalid AuthorId");

        return new ProcessNewBookDto
        {
            Title = dto.Title,
            Synopsis = dto.Synopsis,
            Access = access,
            PublishedDate = publishedDate,
            CategoryId = categoryId,
            AuthorId = authorId,
            config_json = dto.ConfigJson,
            Image = dto.Image,
            file = dto.File,
            abstract_audio = dto.AbstractAudios,
            situational_audio = dto.SituationalAudios
        };
    }

}
