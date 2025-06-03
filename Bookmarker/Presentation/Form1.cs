using Bookmarker.Application.Services;
using Bookmarker.Presentation.ViewModels;

namespace Bookmarker
{
    public partial class Form1 : Form
    {
        private readonly IBookmarkService _bookmarkService;

        private int counter = 0;
        private List<BookmarkGridModel> fullBookmarkGrid = new List<BookmarkGridModel>();
        private List<BookmarkGridModel> filteredBookmarkGrid = new List<BookmarkGridModel>();


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

                counter = 0;
                fullBookmarkGrid = bookmarks.Select(b => new BookmarkGridModel(
                                    ++counter,
                                    b.Title,
                                    String.Join(", ", b.Tags),
                                    b.Group,
                                    b.Type,
                                    b.Url)
                                ).ToList();

                dataGridView1.DataSource = fullBookmarkGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookmarks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var text = textBoxSearch.Text.Trim();

            if (text.Length < 3)
            {
                dataGridView1.DataSource = fullBookmarkGrid;
            }
            else
            {
                filteredBookmarkGrid = fullBookmarkGrid
                    .Where(b => b.Title.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                            b.Tags.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                            b.Group.Contains(text, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = filteredBookmarkGrid;
            }
        }

        private void buttonOpenBrowser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedItem = selectedRow.DataBoundItem as BookmarkGridModel;
                var url = selectedItem.Url;

                if (url != null) {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No URL available for the selected bookmark.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
