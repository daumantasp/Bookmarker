using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bookmarker.Application.Services
{
    internal class RedditBookmarkParserService : IBookmarkParserService
    {
        public Bookmark Parse(string url)
        {
            var partsUrl = ParseUrl(url);

            return new Bookmark(
                ParseIdFromUrl(partsUrl),
                ParseTypeFromUrl(partsUrl),
                ParseTitleFromUrl(partsUrl),
                ParseGroupFromUrl(partsUrl),
                url,
                Array.Empty<string>(),
                string.Empty);
        }

        private static string[] ParseUrl(string url)
        {
            return HttpUtility.UrlDecode(url, Encoding.UTF8).Replace("https://", "").Split("/");
        }

        private static string ParseTitleFromUrl(string[] partsUrl)
        {
            if (partsUrl.Length == 0) return string.Empty;

            if (partsUrl.Length > 5) return ParseTitle(partsUrl[5]);

            return "";
        }

        private static string ParseTitle(string title) => title.Replace("_", " ");

        private static string ParseIdFromUrl(string[] partsUrl)
        {
            var id = "";

            if (partsUrl.Length > 7)
            {
                id = partsUrl[6]; // COMMENT
            }
            else if (partsUrl.Length > 4)
            {
                id = partsUrl[4]; // POST
            }

            return id;
        }

        private static string ParseGroupFromUrl(string[] partsUrl)
        {
            var group = "";

            if (partsUrl.Length > 2)
            {
                group = partsUrl[2];
            }

            return group;
        }

        private static string ParseTypeFromUrl(string[] partsUrl)
        {
            var type = "post";

            if (partsUrl.Length > 7)
            {
                type = "comment";
            }

            return type;
        }
    }
}
