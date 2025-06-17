using Bookmarker.Application.Services;
using Bookmarker.Domain.Interfaces;
using Bookmarker.Infrastructure.Repositories.Reddit;
using Bookmarker.Presentation.ViewModels;
using Bookmarker.Presentation;
using Bookmarker.Domain.Models;

namespace Bookmarker
{
    public partial class Form1 : Form
    {
        //private readonly IBookmarkService _bookmarkService;
        private IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;

        private int counter = 0;
        private List<BookmarkGridModel> fullBookmarkGrid = new List<BookmarkGridModel>();
        private List<BookmarkGridModel> filteredBookmarkGrid = new List<BookmarkGridModel>();
        private string defaultFileDir = "bookmarks.json";

        public Form1(IBookmarkParserService bookmarkParserService)
        {
            InitializeComponent();
            _bookmarkParserService = bookmarkParserService;


            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultFileDir);
            if (!File.Exists(defaultFileDir))
            {
                MessageBox.Show($"Bookmark file '{defaultFileDir}' not found. Please select a valid file.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBoxFileDir.Text = fullPath;
                _bookmarkService = new BookmarkService(new RedditBookmarkRepository(fullPath));
                _bookmarkService.BookmarkEdited += OnBookmarkEdited;
                _bookmarkService.BookmarkDeleted += OnBookmarkDeleted;
                loadData();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = ".\\"; // or set to a specific folder
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    textBoxFileDir.Text = filePath;

                    IBookmarkRepository bookmarkRepository = new RedditBookmarkRepository(filePath);
                    _bookmarkService = new BookmarkService(bookmarkRepository);
                    _bookmarkService.BookmarkEdited += OnBookmarkEdited;

                    loadData();
                }
            }


        }

        private async void loadData()
        {
            if (_bookmarkService == null)
                return;

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
                                    b.Id,
                                    b.Title,
                                    String.Join(", ", b.Tags.Select(t => "#" + t)),
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

                if (url != null)
                {
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var detailsForm = new FormDetails(_bookmarkService, _bookmarkParserService, null);
            detailsForm.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bookmark to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var selectedRow = dataGridView1.SelectedRows[0];
            var selectedItem = selectedRow.DataBoundItem as BookmarkGridModel;
            if (selectedItem != null)
            {
                var detailsForm = new FormDetails(_bookmarkService, _bookmarkParserService, selectedItem.Id);
                detailsForm.ShowDialog();
            }
        }

        private void OnBookmarkEdited(object sender, Bookmark bookmark)
        {
            // Reload the data after a bookmark is edited
            loadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bookmark to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];
            var selectedItem = selectedRow.DataBoundItem as BookmarkGridModel;
            if (selectedItem != null)
            {
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this bookmark?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    _bookmarkService.DeleteByIdAsync(selectedItem.Id);
                }
            }
        }

        private void OnBookmarkDeleted(object sender, Bookmark? bookmark)
        {
            // Reload the data after a bookmark is edited
            loadData();
        }
    }
}
