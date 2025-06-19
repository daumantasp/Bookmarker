using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Repositories
{
    internal interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<Bookmark?> GetByIdASync(string id);
        Task AddAsync(Bookmark newBookmark);
        Task UpdateAsync(Bookmark updatedBookmark);
        Task DeleteAsync(string id);
    }
}
