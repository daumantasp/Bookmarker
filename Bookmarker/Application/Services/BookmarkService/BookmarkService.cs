using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Models;

namespace Bookmarker.Application.Services.BookmarkService
{
    internal class BookmarkService(IBookmarkRepository repo) : IBookmarkService
    {
        private readonly IBookmarkRepository _repo = repo;

        public Task<IEnumerable<Bookmark>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<IEnumerable<Bookmark>> GetAllAsync(string? title, string[]? groups, string[]? tags)
        {
            return _repo.GetAllAsync(title, groups, tags);
        }

        public Task<Bookmark?> GetByIdAsync(string id)
        {
            return _repo.GetByIdASync(id);
        }

        public async Task AddAsync(Bookmark newBookmark)
        {
            await _repo.AddAsync(newBookmark);
            BookmarkAdded.Invoke(newBookmark.Id);
        }

        public async Task UpdateAsync(Bookmark updatedBookmark)
        {
            await _repo.UpdateAsync(updatedBookmark);
            BookmarkUpdated.Invoke(updatedBookmark.Id);
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
            BookmarkDeleted.Invoke(id);
        }

        public event Action<string> BookmarkAdded;
        public event Action<string> BookmarkUpdated;
        public event Action<string> BookmarkDeleted;
    }
}
