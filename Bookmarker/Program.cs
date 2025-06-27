using Bookmarker.Application.Services.BookmarkParserService;
using Bookmarker.Application.Services.BookmarkService;
using Bookmarker.Application.Services.TagService;
using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Infrastructure.Repositories.Cached;
using Bookmarker.Infrastructure.Repositories.Reddit;
using Bookmarker.Infrastructure.SourceSelector;
using FormsApplication = System.Windows.Forms.Application;

namespace Bookmarker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            string sourcePath;
            if (SourceSelector.IsDefaultFileDirExists())
            {
                sourcePath = SourceSelector.DefaultPath;
            }
            else
            {
                sourcePath = SourceSelector.ShowFileDialog() ?? throw new InvalidOperationException("No file selected.");
            }

            IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository(sourcePath);
            IBookmarkRepository cachedBookmarkRepository = new CachedBookmarkRepository(bookmarkRepository);

            IBookmarkService bookmarkService = new BookmarkService(cachedBookmarkRepository);
            IBookmarkParserService bookmarkParserService = new RedditBookmarkParserService();

            ITagService tagService = new TagService(cachedBookmarkRepository);
            
            var formList = new FormList(bookmarkService, bookmarkParserService, tagService, sourcePath);
            FormsApplication.Run(formList);
        }
    }
}