using Bookmarker.Application.Services;
using Bookmarker.Domain.Interfaces;
using Bookmarker.Infrastructure.Repositories.Reddit;
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

            // Manual DI
            //IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository("bookmarks.json");
            //IBookmarkService bookmarkService = new BookmarkService(bookmarkRepository);

            //FormsApplication.Run(new Form1(bookmarkService));

            FormsApplication.Run(new Form1(new RedditBookmarkParserService()));
        }
    }
}