using Bookmarker.Application.Services;
using Bookmarker.Presentation.ViewModels;

namespace Bookmarker
{
    public partial class Form1 : Form
    {
        private readonly IBookmarkService _bookmarkService;

        public Form1(IBookmarkService bookmarkService)
        {
            InitializeComponent();

            _bookmarkService = bookmarkService;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var bookmarks = await _bookmarkService.GetAllAsync();
                foreach (var bookmark in bookmarks)
                {
                    Console.WriteLine($"Title: {bookmark.Title}, URL: {bookmark.Url}");
                }

                var id = 0;
                var viewData = bookmarks.Select(b => new BookmarkGridModel(
                    ++id, 
                    b.Title, 
                    String.Join(", ", b.Tags), 
                    b.Group, 
                    b.Type, 
                    b.Url)
                ).ToList();

                dataGridView1.DataSource = viewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookmarks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
