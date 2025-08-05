using Bookmarker.Application.Services.BookmarkParserService;
using Bookmarker.Application.Services.BookmarkService;
using Bookmarker.Application.Services.GroupService;
using Bookmarker.Application.Services.TagService;
using Bookmarker.Domain.Interfaces.Repositories;
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

            var formList = new FormList();
            formList.OnSourcePathSelected += (newSourcePath) => LoadFormSource(newSourcePath, formList);
            formList.OnNewSourcePathSelected += (newSourcePath) => LoadFormSource(newSourcePath, formList);
            LoadFormSource(sourcePath, formList);

            FormsApplication.Run(formList);
        }

        private static void SavePath(string sourcePath)
        {
            Properties.Settings.Default.LastUsedPath = sourcePath;
            Properties.Settings.Default.Save();
        }

        private static void LoadFormSource(string sourcePath, FormList formList)
        {
            if (!string.IsNullOrWhiteSpace(sourcePath))
            {
                var bookmarkRepository = CreateBookmarkRepository(sourcePath);
                formList.LoadSource(
                        sourcePath,
                        new BookmarkService(bookmarkRepository),
                        new RedditBookmarkParserService(),
                        new TagService(bookmarkRepository),
                        new GroupService(bookmarkRepository)
                        );
                SavePath(sourcePath);
            }
        }

        private static IBookmarkRepository CreateBookmarkRepository(string sourcePath) =>
            new CachedBookmarkRepository(new RedditBookmarkRepository(sourcePath));

    }
}