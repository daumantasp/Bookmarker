using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Models;

namespace Bookmarker.Infrastructure.Repositories.Cached
{
    internal class CachedBookmarksRepository : IBookmarkRepository
    {
        private readonly IBookmarkRepository _innerRepository;
        private List<Bookmark>? _cachedBookmarks;

        public CachedBookmarksRepository(IBookmarkRepository innerRepository)
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
