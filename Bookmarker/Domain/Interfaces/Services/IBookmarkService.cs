using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Services
{
    public interface IBookmarkService
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<IEnumerable<Bookmark>> GetAllAsync(string? title, string? type, string[]? groups, string[]? tags);
        Task<Bookmark?> GetByIdAsync(string id);
        Task AddAsync(Bookmark newBookmark);
        Task UpdateAsync(Bookmark updatedBookmark);
        Task DeleteAsync(string id);

        event Action<string> BookmarkAdded;
        event Action<string> BookmarkUpdated;
        event Action<string> BookmarkDeleted;
    }
}
