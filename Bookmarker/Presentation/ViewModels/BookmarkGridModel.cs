using Bookmarker.Domain.Models;

namespace Bookmarker.Presentation.ViewModels
{
    internal class BookmarkGridModel(
        int rowNo,
        string id,
        string title,
        string tags,
        string group,
        BookmarkType type,
        string created,
        string url)
    {
        public BookmarkGridModel(int rowNo, BookmarkViewModel bookmarkViewModel) : this(
            rowNo,
            bookmarkViewModel.Id,
            bookmarkViewModel.Title,
            string.Join(", ", bookmarkViewModel.Tags),
            bookmarkViewModel.Group,
            bookmarkViewModel.Type,
            bookmarkViewModel.Created.ToString(Constants.DateFormat),
            bookmarkViewModel.Url)
        { }

        public int RowNo { get; } = rowNo;
        public string Id { get; } = id;
        public string Title { get; } = title;
        public string Tags { get; } = tags;
        public string Group { get; } = group;
        public BookmarkType Type { get; } = type;
        public string Created { get; } = created;
        public string Url { get; } = url;
    }
}
