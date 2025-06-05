using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Application.Services
{
    public interface IBookmarkParserService
    {
        Bookmark Parse(string url);
    }
}
