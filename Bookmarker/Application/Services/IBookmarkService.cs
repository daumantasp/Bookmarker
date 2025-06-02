using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarker.Domain.Models;

namespace Bookmarker.Application.Services
{
    internal interface IBookmarkService
    {
        Task<IEnumerable<Bookmark>> GetAllAsync();
    }
}
