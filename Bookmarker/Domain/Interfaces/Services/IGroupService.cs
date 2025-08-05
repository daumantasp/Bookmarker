using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupData>> GetAllGroupDataAsync(GroupsDataOrder order);
    }
}
