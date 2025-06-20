using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Models;
using System.Text.Json;

namespace Bookmarker.Infrastructure.Repositories.Reddit
{
    internal class RedditBookmarkRepository(string filePath) : IBookmarkRepository
    {
        private readonly string _filePath = filePath;

        public async Task<IEnumerable<Bookmark>> GetAllAsync()
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
                return JsonSerializer
                    .Deserialize<IEnumerable<Bookmark>>(json, serializerOptions)
                    .ToList() ?? Enumerable.Empty<Bookmark>();
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error deserializing json file: {ex.Message}", ex);
            }
        }

        public async Task<Bookmark?> GetByIdASync(string id)
        {
            return (await GetAllAsync())
                .FirstOrDefault(b => b.Id == id);
        }

        public async Task AddAsync(Bookmark newBookmark)
        {
            var bookmarks = (await GetAllAsync()).ToList();
            bookmarks.Add(newBookmark);

            try
            {
                await SaveBookmarksToJson(bookmarks);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error serializing bookmarks to json: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(Bookmark updatedBookmark)
        {
            var bookmarks = (await GetAllAsync()).ToList();
            var index = bookmarks.FindIndex(b => b.Id == updatedBookmark.Id);
            bookmarks[index] = updatedBookmark;

            try
            {
                await SaveBookmarksToJson(bookmarks);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error serializing bookmarks to json: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(string id)
        {
            var bookmarks = (await GetAllAsync()).Where(b => b.Id != id);

            try
            {
                await SaveBookmarksToJson(bookmarks);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error serializing bookmarks to json: {ex.Message}", ex);
            }
        }

        private async Task SaveBookmarksToJson(IEnumerable<Bookmark> bookmarks)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(bookmarks, serializerOptions);

            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
