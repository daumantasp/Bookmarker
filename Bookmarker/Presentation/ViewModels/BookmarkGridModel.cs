using Bookmarker.Domain.Models;

namespace Bookmarker.Presentation.ViewModels
{
    internal class BookmarkGridModel(
        int rowNo,
        string id,
        string title,
        string tags,
        string group,
        string type,
        string created,
        string url)
    {
        public BookmarkGridModel(int rowNo, Bookmark bookmark) : this(
            rowNo,
            bookmark.Id,
            bookmark.Title,
            string.Join(", ", bookmark.Tags.Select(t => "#" + t)),
            bookmark.Group,
            bookmark.Type,
            bookmark.Created ?? "-",
            bookmark.Url)
        { }

        public int RowNo { get; } = rowNo;
        public string Id { get; } = id;
        public string Title { get; } = title;
        public string Tags { get; } = tags;
        public string Group { get; } = group;
        public string Type { get; } = type;
        public string Created { get; } = created;
        public string Url { get; } = url;

    }
}
