using Bookmarker.Domain.Interfaces;
using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Application.Services
{
    internal class BookmarkService(IBookmarkRepository repo) : IBookmarkService
    {
        private readonly IBookmarkRepository _repo = repo;

        public async Task<IEnumerable<Bookmark>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Bookmark?> GetByIdAsync(string id)
        {
            return await _repo.GetByIdASync(id);
        }

        public async Task AddAsync(Bookmark newBookmark)
        {
            await _repo.AddAsync(newBookmark);
            BookmarkAdded.Invoke();
        }

        public async Task UpdateAsync(Bookmark updatedBookmark)
        {
            await _repo.UpdateAsync(updatedBookmark);
            BookmarkUpdated.Invoke();
        }

        public async Task DeleteAsync(string id)
        {
            await _repo.DeleteAsync(id);
            BookmarkDeleted.Invoke();
        }

        public async Task<IEnumerable<TagData>> GetAllTagDataAsync(TagsDataOrder order)
        {
            var bookmarks = await _repo.GetAllAsync();

            var tags = new Dictionary<string, int>();

            foreach (var bookmark in bookmarks)
            {
                if (bookmark.Tags == null) continue;

                foreach (var tag in bookmark.Tags)
                {
                    if (tags.ContainsKey(tag))
                    {
                        tags[tag]++;
                    }
                    else
                    {
                        tags[tag] = 1;
                    }
                }
            }

            var tagData = tags.Select(kvp => new TagData(kvp.Key, kvp.Value));

            if (order == TagsDataOrder.Count)
            {
                tagData = tagData.OrderByDescending(td => td.Count);
            }
            else
            {
                tagData = tagData.OrderBy(td => td.Name);
            }

            return tagData.ToList();
        }

        public async Task<IEnumerable<TagData>> GetTagDataAsync(TagsDataOrder order, string filter)
        {
            var tagData = await GetAllTagDataAsync(order);

            return tagData.Where(td => td.Name.Contains(filter, StringComparison.OrdinalIgnoreCase));
        }

        public event Action BookmarkAdded;
        public event Action BookmarkUpdated;
        public event Action BookmarkDeleted;
    }
}
