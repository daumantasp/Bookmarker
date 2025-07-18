using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Models;

namespace Bookmarker.Infrastructure.Repositories.Cached
{
    internal class CachedBookmarkRepository : IBookmarkRepository
    {
        private readonly IBookmarkRepository _innerRepository;
        private List<Bookmark>? _cachedBookmarks;

        public CachedBookmarkRepository(IBookmarkRepository innerRepository)
        {
            _innerRepository = innerRepository;
        }

        public async Task AddAsync(Bookmark newBookmark)
        {
            await _innerRepository.AddAsync(newBookmark);

            if (_cachedBookmarks != null)
            {
                _cachedBookmarks.Add(newBookmark);
            }
        }

        public async Task DeleteAsync(string id)
        {
            await _innerRepository.DeleteAsync(id);

            if (_cachedBookmarks != null)
            {
                var bookmarkToRemove = _cachedBookmarks.FirstOrDefault(b => b.Id == id);
                if (bookmarkToRemove != null)
                {
                    _cachedBookmarks.Remove(bookmarkToRemove);
                }
            }
        }

        public async Task<IEnumerable<Bookmark>> GetAllAsync()
        {
            if (_cachedBookmarks == null || _cachedBookmarks.Count == 0)
            {
                _cachedBookmarks = (await _innerRepository.GetAllAsync()).ToList();
            }
            return _cachedBookmarks;
        }

        public async Task<IEnumerable<Bookmark>> GetAllAsync(string? title, string? group, string[]? tags)
        {
            var bookmarks = await GetAllAsync();
            if (!string.IsNullOrEmpty(title))
            {
                bookmarks = bookmarks
                    .Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(group))
            {
                bookmarks = bookmarks
                    .Where(b => b.Group.Equals(group, StringComparison.OrdinalIgnoreCase));
            }
            if (tags != null && tags.Length > 0)
            {
                bookmarks = bookmarks
                    .Where(b => b.Tags.Any(t => tags.Contains(t, StringComparer.OrdinalIgnoreCase)));
            }
            return bookmarks;
        }

        public async Task<Bookmark?> GetByIdASync(string id)
        {
            if (_cachedBookmarks?.FirstOrDefault(b => b.Id == id) is Bookmark cachedBookmark)
            {
                return cachedBookmark;
            }

            return await _innerRepository.GetByIdASync(id);
        }

        public async Task UpdateAsync(Bookmark updatedBookmark)
        {
            await _innerRepository.UpdateAsync(updatedBookmark);

            if (_cachedBookmarks != null)
            {
                var index = _cachedBookmarks.FindIndex(b => b.Id == updatedBookmark.Id);
                if (index >= 0)
                {
                    _cachedBookmarks[index] = updatedBookmark;
                }
            }
        }
    }
}
