using Bookmarker.Presentation.ViewModels;
using Bookmarker.Presentation;
using Bookmarker.Domain.Interfaces.Services;
using System.Data;
using Bookmarker.Infrastructure.SourceSelector;
using Bookmarker.Presentation.Shared;

namespace Bookmarker
{
    public partial class FormList : Form
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;
        private readonly ITagService _tagService;
        private string _sourcePath;

        private BindingSource bindingSource = new BindingSource();
        private DataTable dataTable = new DataTable();

        public event Action<string> OnSourcePathSelected;
        public event Action<string> OnNewSourcePathSelected;

        public FormList(
            IBookmarkService bookmarkService,
            IBookmarkParserService bookmarkParserService,
            ITagService tagService,
            string sourcePath)
        {
            _bookmarkService = bookmarkService;
            _bookmarkParserService = bookmarkParserService;
            _tagService = tagService;
            _sourcePath = sourcePath;

            InitializeComponent();
            SetupUI();
            SetupEvents();
            LoadAllBookmarks();
        }

        private void SetupUI()
        {
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomMenuStripColorTable());

            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Id", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Tags", typeof(string));
            dataTable.Columns.Add("Group", typeof(string));
            dataTable.Columns.Add("Type", typeof(string));
            dataTable.Columns.Add("Created", typeof(string));
            dataTable.Columns.Add("Url", typeof(string));

            textBoxFileDir.Text = _sourcePath;
        }

        private void SetupEvents()
        {
            _bookmarkService.BookmarkAdded += OnBookmarkAdded;
            _bookmarkService.BookmarkUpdated += OnBookmarkUpdated;
            _bookmarkService.BookmarkDeleted += OnBookmarkDeleted;
        }

        private async void LoadAllBookmarks()
        {
            if (_bookmarkService == null)
                return;

            try
            {
                var bookmarks = await _bookmarkService.GetAllAsync();

                var counter = 0;
                foreach (var bookmark in bookmarks)
                {
                    AddBookmarkGridModelToDataTable(new BookmarkGridModel(++counter, bookmark));
                }

                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookmarks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private async void OnBookmarkAdded(string id)
        {
            var bookmark = await _bookmarkService.GetByIdAsync(id);
            if (bookmark != null)
            {
                var bookmarkGridModel = new BookmarkGridModel(
                    dataTable.Rows.Count + 1,
                    bookmark);

                AddBookmarkGridModelToDataTable(bookmarkGridModel);
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

                    UpdateBookmarkGridModelToDataTable(updatedBookmarkGridModel);
                }
            }
        }

        private void OnBookmarkDeleted(string id)
        {
            dataTable.Rows.RemoveAt(bindingSource.Find("Id", id));
        }

        private void AddBookmarkGridModelToDataTable(BookmarkGridModel bookmarkGridModel)
        {
            dataTable.Rows.Add(bookmarkGridModel.RowNo,
                               bookmarkGridModel.Id,
                               bookmarkGridModel.Title,
                               bookmarkGridModel.Tags,
                               bookmarkGridModel.Group,
                               bookmarkGridModel.Type,
                               bookmarkGridModel.Created,
                               bookmarkGridModel.Url);
        }

        private void UpdateBookmarkGridModelToDataTable(BookmarkGridModel bookmarkGridModel)
        {
            var index = bookmarkGridModel.RowNo - 1;
            if (index >= 0 && index < dataTable.Rows.Count)
            {
                dataTable.Rows[index]["No"] = bookmarkGridModel.RowNo;
                dataTable.Rows[index]["Id"] = bookmarkGridModel.Id;
                dataTable.Rows[index]["Title"] = bookmarkGridModel.Title;
                dataTable.Rows[index]["Tags"] = bookmarkGridModel.Tags;
                dataTable.Rows[index]["Group"] = bookmarkGridModel.Group;
                dataTable.Rows[index]["Type"] = bookmarkGridModel.Type;
                dataTable.Rows[index]["Created"] = bookmarkGridModel.Created;
                dataTable.Rows[index]["Url"] = bookmarkGridModel.Url;
            }
        }
        private void ShowBookmarkDeletionConfirmationDialog(string? id)
        {
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenSelectedUrlInBrowser();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            SourceSelector.ShowFileDialog();
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
                ShowBookmarkDeletionConfirmationDialog(id);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row != null)
            {
                var id = e.Row.Cells["Id"]?.Value?.ToString();
                ShowBookmarkDeletionConfirmationDialog(id);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_sourcePath))
            {
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = _sourcePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_sourcePath))
            {
                var directoryPath = Path.GetDirectoryName(_sourcePath);
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

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSourcePath = SourceSelector.ShowFileDialog();
            if (!string.IsNullOrWhiteSpace(newSourcePath) && OnSourcePathSelected != null)
                OnSourcePathSelected(newSourcePath);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSourcePath = SourceSelector.ShowCreateFileDialog();
            if (!string.IsNullOrWhiteSpace(newSourcePath) && OnSourcePathSelected != null)
                OnNewSourcePathSelected(newSourcePath);
        }
    }
}
