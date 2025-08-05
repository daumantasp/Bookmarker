using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Application.Services.GroupService
{
    internal class GroupService(IBookmarkRepository repo) : IGroupService
    {
        private readonly IBookmarkRepository _repo = repo;

        public async Task<IEnumerable<GroupData>> GetAllGroupDataAsync(GroupsDataOrder order)
        {
            var bookmarks = await _repo.GetAllAsync();

            var groups = new Dictionary<string, int>();

            foreach (var bookmark in bookmarks)
            {
                var group = bookmark.Group;
                if (group == null) continue;

                if (groups.ContainsKey(group))
                {
                    groups[group]++;
                }
                else
                {
                    groups[group] = 1;
                }
            }

            var groupData = groups.Select(kvp => new GroupData(kvp.Key, kvp.Value));

            if (order == GroupsDataOrder.Count)
            {
                groupData = groupData.OrderByDescending(gd => gd.Count);
            }
            else
            {
                groupData = groupData.OrderBy(gd => gd.Name);
            }

            return groupData.ToList();
        }
    }
}
