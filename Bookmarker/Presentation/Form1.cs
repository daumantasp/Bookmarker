using Bookmarker.Infrastructure.Repositories.Reddit;
using Bookmarker.Presentation.ViewModels;
using Bookmarker.Presentation;
using Bookmarker.Domain.Models;
using Bookmarker.Application.Services.BookmarkService;
using Bookmarker.Application.Services.TagService;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Interfaces.Repositories;
using Bookmarker.Infrastructure.Repositories.Cached;
using System.ComponentModel;
using System.Data;

namespace Bookmarker
{
    public partial class FormList : Form
    {
        //private readonly IBookmarkService _bookmarkService;
        private IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;
        private ITagService _tagService;

        private int counter = 0;
        private List<BookmarkGridModel> filteredBookmarkGrid = new List<BookmarkGridModel>();
        private string defaultFileDir = "bookmarks.json";
        private string fullPath = "";


        private BindingSource bindingSource = new BindingSource();
        private BindingList<BookmarkGridModel> bookmarkGridModel;
        private DataTable dataTable;

        public FormList(IBookmarkParserService bookmarkParserService)
        {
            InitializeComponent();
            SetupDataTable();

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

                LoadAllData();
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

                    LoadAllData();
                }
            }
        }

        private void SetupDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Tags", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Created", typeof(string));
            dataTable.Columns.Add("Url", typeof(string));
        }

        private async void LoadAllData()
        {
            if (_bookmarkService == null)
                return;

            try
            {
                var bookmarks = await _bookmarkService.GetAllAsync();

                counter = 0;
                foreach (var bookmark in bookmarks)
                {
                    var bookmarkGridModel = new BookmarkGridModel(++counter, bookmark);

                    dataTable.Rows.Add(bookmarkGridModel.RowNo,
                                       bookmarkGridModel.Id,
                                       bookmarkGridModel.Title,
                                       bookmarkGridModel.Tags,
                                       bookmarkGridModel.Group,
                                       bookmarkGridModel.Type,
                                       bookmarkGridModel.Created,
                                       bookmarkGridModel.Url);
                }

                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
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
                bindingSource.Filter = string.Empty;
            }
            else
            {
                bindingSource.Filter = string.Format(
                    "Title LIKE '%{0}%' OR Tags LIKE '%{0}%'",
                    text.Replace("'", "''"));
            }
        }

        private void buttonOpenBrowser_Click(object sender, EventArgs e)
        {
            OpenSelectedUrlInBrowser();
        }

        private void OpenSelectedUrlInBrowser()
        {
            if (bindingSource.Current is DataRowView selectedItem)
            {
                var url = selectedItem.Row["Url"].ToString();

                if (!string.IsNullOrWhiteSpace(url))
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

            if (bindingSource.Current is DataRowView selectedItem)
            {
                var id = selectedItem.Row["Id"].ToString();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var detailsForm = new FormDetails(_bookmarkService,
                              _bookmarkParserService,
                              _tagService,
                              id);

                    detailsForm.ShowDialog();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bookmark to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bindingSource.Current is DataRowView selectedItem)
            {
                var id = selectedItem.Row["Id"].ToString();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this bookmark?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        _bookmarkService.DeleteAsync(id);
                    }
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

        private async void OnBookmarkAdded(string id)
        {
            var bookmark = await _bookmarkService.GetByIdAsync(id);
            if (bookmark != null)
            {
                var updatedBookmarkGridModel = new BookmarkGridModel(
                    dataTable.Rows.Count + 1,
                    bookmark);

                dataTable.Rows.Add(updatedBookmarkGridModel.RowNo,
                                   updatedBookmarkGridModel.Id,
                                   updatedBookmarkGridModel.Title,
                                   updatedBookmarkGridModel.Tags,
                                   updatedBookmarkGridModel.Group,
                                   updatedBookmarkGridModel.Type,
                                   updatedBookmarkGridModel.Created,
                                   updatedBookmarkGridModel.Url);
            }
        }

        private async void OnBookmarkUpdated(string id)
        {
            var bookmark = await _bookmarkService.GetByIdAsync(id);
            if (bookmark != null)
            {
                int index = bindingSource.Find("Id", id);

                if (index >= 0)
                {
                    var updatedBookmarkGridModel = new BookmarkGridModel(
                        index + 1,
                        bookmark);

                    dataTable.Rows[index]["No"] = updatedBookmarkGridModel.RowNo;
                    dataTable.Rows[index]["Id"] = updatedBookmarkGridModel.Id;
                    dataTable.Rows[index]["Title"] = updatedBookmarkGridModel.Title;
                    dataTable.Rows[index]["Tags"] = updatedBookmarkGridModel.Tags;
                    dataTable.Rows[index]["Group"] = updatedBookmarkGridModel.Group;
                    dataTable.Rows[index]["Type"] = updatedBookmarkGridModel.Type;
                    dataTable.Rows[index]["Created"] = updatedBookmarkGridModel.Created;
                    dataTable.Rows[index]["Url"] = updatedBookmarkGridModel.Url;
                }
            }
        }

        private void OnBookmarkDeleted(string id)
        {
            dataTable.Rows.RemoveAt(bindingSource.Find("Id", id));
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row != null)
            {
                var id = e.Row.Cells["Id"]?.Value?.ToString();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this bookmark?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    if (confirmResult == DialogResult.Yes)
                    {
                        _bookmarkService.DeleteAsync(id);
                    }
                }
            }
        }
    }
}
