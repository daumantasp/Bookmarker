using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces
{
    internal interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> GetAll();
    }
}
