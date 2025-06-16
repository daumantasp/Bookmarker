using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarker.Domain.Models;

namespace Bookmarker.Application.Services
{
    public interface IBookmarkService
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
        Task<Bookmark?> GetByIdAsync(string id);
        Task SaveAync(Bookmark bookmark);
        Task<IEnumerable<TagData>> GetAllTagDataAsync(TagsDataOrder order);
        Task<IEnumerable<TagData>> GetTagDataAsync(TagsDataOrder order, string filter);
        event EventHandler<Bookmark> BookmarkEdited;
    }
}
