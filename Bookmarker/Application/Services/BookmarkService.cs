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
            return await _repo.GetAll();
        }
    }
}
