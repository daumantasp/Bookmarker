using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Repositories
{
    internal interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<IEnumerable<Bookmark>> GetAllAsync(string? title, string[]? groups, string[]? tags);
        Task<Bookmark?> GetByIdASync(string id);
        Task AddAsync(Bookmark newBookmark);
        Task UpdateAsync(Bookmark updatedBookmark);
        Task DeleteAsync(string id);
    }
}
