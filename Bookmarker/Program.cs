using Bookmarker.Application.Services.BookmarkParserService;
using Bookmarker.Application.Services.BookmarkService;
using Bookmarker.Application.Services.TagService;
using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Infrastructure.Repositories.Cached;
using Bookmarker.Infrastructure.Repositories.Reddit;
using Bookmarker.Presentation;
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

            string sourcePath = Properties.Settings.Default.LastUsedPath;

            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                using (DialogStart dialogStart = new DialogStart())
                {
                    if (dialogStart.ShowDialog() == DialogResult.OK)
                    {
                        sourcePath = dialogStart.SourcePath ?? throw new InvalidOperationException("Source path cannot be null.");
                    }
                }
            }

            if (!string.IsNullOrEmpty(sourcePath) && File.Exists(sourcePath))
            {
                SavePath(sourcePath);
                var formList = CreateFormList(sourcePath);
                FormsApplication.Run(formList);
            }
        }

        // TODO: Refactor
        private static FormList CreateFormList(string sourcePath)
        {
            IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository(sourcePath);
            IBookmarkRepository cachedBookmarkRepository = new CachedBookmarkRepository(bookmarkRepository);

            IBookmarkService bookmarkService = new BookmarkService(cachedBookmarkRepository);
            IBookmarkParserService bookmarkParserService = new RedditBookmarkParserService();

            ITagService tagService = new TagService(cachedBookmarkRepository);

            var formList = new FormList();
            formList.OnSourcePathSelected += (newSourcePath) =>
            {
                if (newSourcePath != null && File.Exists(newSourcePath))
                {
                    SavePath(newSourcePath);


                    IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository(newSourcePath);
                    IBookmarkRepository cachedBookmarkRepository = new CachedBookmarkRepository(bookmarkRepository);

                    IBookmarkService bookmarkService = new BookmarkService(cachedBookmarkRepository);
                    IBookmarkParserService bookmarkParserService = new RedditBookmarkParserService();

                    ITagService tagService = new TagService(cachedBookmarkRepository);


                    formList.LoadSource(newSourcePath, bookmarkService, bookmarkParserService, tagService);
                }
            };
            formList.OnNewSourcePathSelected += (newSourcePath) =>
            {
                // TODO: Refine
                if (newSourcePath != null && File.Exists(newSourcePath))
                {
                    File.WriteAllText(newSourcePath, "[]");
                    SavePath(newSourcePath);


                    IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository(newSourcePath);
                    IBookmarkRepository cachedBookmarkRepository = new CachedBookmarkRepository(bookmarkRepository);

                    IBookmarkService bookmarkService = new BookmarkService(cachedBookmarkRepository);
                    IBookmarkParserService bookmarkParserService = new RedditBookmarkParserService();

                    ITagService tagService = new TagService(cachedBookmarkRepository);

                    formList.LoadSource(newSourcePath, bookmarkService, bookmarkParserService, tagService);
                }
            };
            formList.LoadSource(sourcePath, bookmarkService, bookmarkParserService, tagService);

            return formList;
        }

        private static void SavePath(string sourcePath)
        {
            Properties.Settings.Default.LastUsedPath = sourcePath;
            Properties.Settings.Default.Save();
        }
    }
}