using Bookmarker.Domain.Models;
using System.Globalization;

namespace Bookmarker.Infrastructure.Data
{
    public static class BookmarkMapper
    {
        private const string DateFormat = "yyyy-MM-dd";

        public static Bookmark ToDomain(BookmarkDto dto)
        {
            DateTime? created = null;
            if (!string.IsNullOrWhiteSpace(dto.Created))
            {
                if (!DateTime.TryParseExact(dto.Created, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
                {
                    throw new FormatException($"Invalid date format: {dto.Created}. Expected format is {DateFormat}.");
                }
                created = parsed;
            }

            return new Bookmark(
                dto.Id,
                dto.Type == "P" ? BookmarkType.Post : BookmarkType.Comment,
                dto.Title,
                dto.Group,
                dto.Url,
                dto.Tags ?? Array.Empty<string>(),
                created ?? DateTime.Now);
        }

        public static BookmarkDto ToDto(Bookmark bookmark)
        {
            return new BookmarkDto
            {
                Id = bookmark.Id,
                Type = bookmark.Type == BookmarkType.Post ? "P" : "C",
                Title = bookmark.Title,
                Group = bookmark.Group,
                Url = bookmark.Url,
                Tags = bookmark.Tags ?? Array.Empty<string>(),
                Created = bookmark.Created.ToString(DateFormat)
            };
        }
    }
}
