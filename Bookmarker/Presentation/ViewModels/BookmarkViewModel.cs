using Bookmarker.Domain.Models;

namespace Bookmarker.Presentation.ViewModels
{
    internal class BookmarkViewModel(string Id,
                          string Type,
                          string Title,
                          string Group,
                          string Url,
                          string[] Tags,
                          DateTime Created)
    {
        public string Id { get; } = Id;
        public string Type { get; } = Type;
        public string Title { get; } = Title;
        public string Group { get; } = Group;
        public string Url { get; } = Url;
        public string[] Tags { get; } = Tags;
        public DateTime Created { get; } = Created;

        public BookmarkViewModel(Bookmark bookmark) : this(
            bookmark.Id,
            bookmark.Type,
            bookmark.Title,
            bookmark.Group,
            bookmark.Url,
            bookmark.Tags.Select(t => "#" + t).ToArray(),
            bookmark.Created)
        { }

        public BookmarkViewModel Clone()
        {
            return new BookmarkViewModel(
                Id,
                Type,
                Title,
                Group,
                Url,
                Tags.ToArray(),
                Created
            );
        }
    }
}
