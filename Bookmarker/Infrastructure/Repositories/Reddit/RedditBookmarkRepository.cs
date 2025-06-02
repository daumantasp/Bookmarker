using Bookmarker.Domain.Interfaces;
using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookmarker.Infrastructure.Repositories.Reddit
{
    internal class RedditBookmarkRepository(string filePath) : IBookmarkRepository
    {
        private readonly string _filePath = filePath;

        public async Task<IEnumerable<Bookmark>> GetAll()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("Bookmark file not found.", _filePath);

            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var redditBookmarks = JsonSerializer
                    .Deserialize<IEnumerable<RedditBookmark>>(json, serializerOptions)
                    .Select(rb => rb.ToBookmark());

                return redditBookmarks ?? Enumerable.Empty<Bookmark>();

            }
            catch (JsonException ex)
            {
                throw new Exception($"Error deserializing josn file: {ex.Message}", ex);
            }

        }
    }
}
