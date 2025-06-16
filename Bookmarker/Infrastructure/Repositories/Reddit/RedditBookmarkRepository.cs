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

        public async Task Save(Bookmark newBookmark)
        {
            CheckFileExists();

            await LoadBookmarksIfNeeded();

            var newBookmarks = new List<Bookmark>();
            var updated = false;
            for (var i = 0; i < _bookmarks.Count(); i++)
            {
                if (_bookmarks.ElementAt(i).Id == newBookmark.Id)
                {
                    newBookmarks.Add(newBookmark.Clone());
                    updated = true;
                }
                else
                {
                    newBookmarks.Add(_bookmarks.ElementAt(i));
                }
            }
            if (!updated)
            {
                newBookmarks.Add(newBookmark.Clone());
            }

            _bookmarks = newBookmarks;
            hasChanged = true;
            await SaveBookmarksToFile();
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

        private async Task SaveBookmarksToFile()
        {
            try
            {
                var json = JsonSerializer.Serialize(
                    _bookmarks,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                await File.WriteAllTextAsync(_filePath, json);
            }
            catch (JsonException ex)
            {
                throw new Exception($"Error serializing bookmarks to json: {ex.Message}", ex);
            }
        }
    }
}
