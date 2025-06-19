using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagData>> GetAllTagDataAsync(TagsDataOrder order);
        Task<IEnumerable<TagData>> GetTagDataAsync(TagsDataOrder order, string filter);
    }
}
