using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Domain.Models
{
    public class Bookmark(string Id,
                          string Type,
                          string Title,
                          string Group,
                          string Url,
                          string[] Tags,
                          string? Created)
    {
        public string Id { get; } = Id;
        public string Type { get; } = Type;
        public string Title { get; } = Title;
        public string Group { get; } = Group;
        public string Url { get; } = Url;
        public string[] Tags { get; } = Tags;
        public string? Created { get; } = Created;

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
