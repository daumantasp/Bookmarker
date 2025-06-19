using Bookmarker.Domain.Models;

namespace Bookmarker.Domain.Interfaces.Services
{
    public interface IBookmarkParserService
    {
        Bookmark Parse(string url);
    }
}
