using Bookmarker.Infrastructure.Repositories.Reddit;
using Bookmarker.Presentation.ViewModels;
using Bookmarker.Presentation;
using Bookmarker.Domain.Models;
using Bookmarker.Application.Services.BookmarkService;
using Bookmarker.Application.Services.TagService;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Infrastructure.Repositories.Cached;

namespace Bookmarker
{
    public partial class FormList : Form
    {
        //private readonly IBookmarkService _bookmarkService;
        private IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;
        private ITagService _tagService;

        private int counter = 0;
        private List<BookmarkGridModel> fullBookmarkGrid = new List<BookmarkGridModel>();
        private List<BookmarkGridModel> filteredBookmarkGrid = new List<BookmarkGridModel>();
        private string defaultFileDir = "bookmarks.json";
        private string fullPath = "";

        public FormList(IBookmarkParserService bookmarkParserService)
        {
            InitializeComponent();
            _bookmarkParserService = bookmarkParserService;

            fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultFileDir);
            if (!File.Exists(defaultFileDir))
            {
                buttonOpenFile.Enabled = false;
                MessageBox.Show($"Bookmark file '{defaultFileDir}' not found. Please select a valid file.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                buttonOpenFile.Enabled = true;
                textBoxFileDir.Text = fullPath;
                IBookmarkRepository bookmarkRepository = new CachedBookmarksRepository(new RedditBookmarkRepository(fullPath));
                _bookmarkService = new BookmarkService(bookmarkRepository);
                _tagService = new TagService(bookmarkRepository);

                _bookmarkService.BookmarkAdded += OnBookmarkAdded;
                _bookmarkService.BookmarkUpdated += OnBookmarkUpdated;
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

                    buttonOpenFile.Enabled = true;
                    textBoxFileDir.Text = filePath;
                    IBookmarkRepository bookmarkRepository = new CachedBookmarksRepository(new RedditBookmarkRepository(filePath));
                    _bookmarkService = new BookmarkService(bookmarkRepository);
                    _tagService = new TagService(bookmarkRepository);

                    _bookmarkService.BookmarkAdded += OnBookmarkAdded;
                    _bookmarkService.BookmarkUpdated += OnBookmarkUpdated;
                    _bookmarkService.BookmarkDeleted += OnBookmarkDeleted;

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
                                    string.Join(", ", b.Tags.Select(t => "#" + t)),
                                    b.Group,
                                    b.Type,
                                    b.Created ?? "-",
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
            OpenSelectedUrlInBrowser();
        }

        private void OpenSelectedUrlInBrowser()
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
            var detailsForm = new FormDetails(_bookmarkService,
                                              _bookmarkParserService,
                                              _tagService,
                                              null);
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
                var detailsForm = new FormDetails(_bookmarkService,
                                                  _bookmarkParserService,
                                                  _tagService,
                                                  selectedItem.Id);
                detailsForm.ShowDialog();
            }
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
                    _bookmarkService.DeleteAsync(selectedItem.Id);
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fullPath))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOpenDir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fullPath))
            {
                var directoryPath = Path.GetDirectoryName(fullPath);
                if (directoryPath != null)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = directoryPath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenSelectedUrlInBrowser();
        }

        private void OnBookmarkAdded()
        {
            loadData();
        }

        private void OnBookmarkUpdated()
        {
            loadData();
        }

        private void OnBookmarkDeleted()
        {
            loadData();
        }
    }
}
