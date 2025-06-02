using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Domain.Models
{
    public class RedditBookmark(string Id,
                          string Type,
                          string Title,
                          string Subreddit,
                          string Url,
                          string[] Tags)
    {
        public string Id { get; } = Id;
        public string Type { get; } = Type;
        public string Title { get; } = Title;
        public string Subreddit { get; } = Subreddit;
        public string Url { get; } = Url;
        public string[] Tags { get; } = Tags;

        public Bookmark ToBookmark() => new Bookmark(
                Id: Id,
                Type: Type,
                Title: Title,
                Group: Subreddit,
                Url: Url,
                Tags: Tags
            );
    }
}
