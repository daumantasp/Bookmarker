using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Presentation.ViewModels
{
    internal class BookmarkGridModel(
        int rowId,
        string id,
        string title,
        string tags,
        string group,
        string type,
        string url)
    {
        public int RowId { get; } = rowId;
        public string Id { get; } = id;
        public string Title { get; } = title;
        public string Tags { get; } = tags;
        public string Group { get; } = group;
        public string Type { get; } = type;
        public string Url { get; } = url;

    }
}
