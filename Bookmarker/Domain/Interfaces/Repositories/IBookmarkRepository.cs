using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Repositories
{
    internal interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<IEnumerable<Bookmark>> GetAllAsync(string? title, BookmarkType? type, string[]? groups, string[]? tags, DateTime? from, DateTime? to);
        Task<Bookmark?> GetByIdASync(string id);
        Task AddAsync(Bookmark newBookmark);
        Task UpdateAsync(Bookmark updatedBookmark);
        Task DeleteAsync(string id);
    }
}
