using Bookmarker.Domain.Interfaces;
using Bookmarker.Domain.Models;
using System.Text.Json;

namespace Bookmarker.Infrastructure.Repositories.Reddit
{
    internal class RedditBookmarkRepository(string filePath) : IBookmarkRepository
    {
        private readonly string _filePath = filePath;
        private IEnumerable<Bookmark> _bookmarks = Enumerable.Empty<Bookmark>();
        private bool hasChanged = false;

        public async Task<IEnumerable<Bookmark>> GetAll()
        {
            CheckFileExists();
            
            await LoadBookmarksIfNeeded();

            return _bookmarks
                .Select(b => b.Clone())
                .ToList();
        }

        public async Task<Bookmark?> GetById(string id)
        {
            CheckFileExists();
            
            await LoadBookmarksIfNeeded();

            return _bookmarks
                .FirstOrDefault(b => b.Id == id)?
                .Clone();
        }

        private async Task LoadBookmarksIfNeeded()
        {
            if (_bookmarks.Count() == 0 || hasChanged)
            {
                await LoadBookmarks();
                hasChanged = false;
            }
        }

        private async Task LoadBookmarks()
        {
            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                var serializerOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                _bookmarks = JsonSerializer
                    .Deserialize<IEnumerable<RedditBookmark>>(json, serializerOptions)
                    .Select(rb => rb.ToBookmark());
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error deserializing json file: {ex.Message}", ex);
            }
        }

        private void CheckFileExists()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("Bookmark file not found.", _filePath);
        }
    }
}
