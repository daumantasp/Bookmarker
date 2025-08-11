namespace Bookmarker.Domain.Models
{
    public class Bookmark(string Id,
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

        public Bookmark Clone()
        {
            return new Bookmark(
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
