using Bookmarker.Presentation.ViewModels;
using Bookmarker.Presentation;
using Bookmarker.Domain.Interfaces.Services;
using System.Data;
using Bookmarker.Infrastructure.SourceSelector;
using Bookmarker.Presentation.Shared;
using Bookmarker.Domain.Models;

namespace Bookmarker
{
    public partial class FormList : Form
    {
        private IBookmarkService _bookmarkService;
        private IBookmarkParserService _bookmarkParserService;
        private ITagService _tagService;
        private IGroupService _groupService;
        private string _sourcePath;

        private BindingSource bindingSource = new BindingSource();
        private DataTable dataTable = new DataTable();

        private string? titleFilter = null;
        private string? typeFilter = null;
        private string[]? groupsFilter = null;
        private string[]? tagsFilter = null;
        private DateTime? from = null;
        private DateTime? to = null;

        private bool IsFilterApplied
        {
            get => !string.IsNullOrWhiteSpace(titleFilter)
                || !string.IsNullOrWhiteSpace(typeFilter)
                || (groupsFilter != null && groupsFilter.Length > 0)
                || (tagsFilter != null && tagsFilter.Length > 0)
                || from.HasValue
                || to.HasValue;
        }

        public event Action<string> OnSourcePathSelected;
        public event Action<string> OnNewSourcePathSelected;

        public FormList()
        {
            InitializeComponent();
            SetupUI();
        }

        public void LoadSource(string sourcePath,
                               IBookmarkService bookmarkService,
                               IBookmarkParserService bookmarkParserService,
                               ITagService tagService,
                               IGroupService groupService)
        {
            _sourcePath = sourcePath;
            _bookmarkService = bookmarkService;
            _bookmarkParserService = bookmarkParserService;
            _tagService = tagService;
            _groupService = groupService;
            textBoxFileDir.Text = sourcePath;

            ReloadBookmarks();
        }

        private void ReloadBookmarks()
        {
            ClearBookmarks();
            UpdateUI();
            LoadBookmarks(() =>
            {
                SetFormTitle();
                SetupEvents();
            });
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
        }

        private void SetupEvents()
        {
            _bookmarkService.BookmarkAdded += OnBookmarkAdded;
            _bookmarkService.BookmarkUpdated += OnBookmarkUpdated;
            _bookmarkService.BookmarkDeleted += OnBookmarkDeleted;
        }

        private void ClearBookmarks()
        {
            if (_bookmarkService == null)
                return;

            _bookmarkService.BookmarkAdded -= OnBookmarkAdded;
            _bookmarkService.BookmarkUpdated -= OnBookmarkUpdated;
            _bookmarkService.BookmarkDeleted -= OnBookmarkDeleted;

            bindingSource.DataSource = null;
            bindingSource.Clear();
            dataTable.Clear();
        }

        private void UpdateUI()
        {
            var isSelected = dataGridView1.SelectedRows.Count > 0;
            buttonOpenBrowser.Enabled = isSelected;
            buttonEdit.Enabled = isSelected;
            buttonDelete.Enabled = isSelected;

            buttonFilter.BackColor = IsFilterApplied ? Color.LightGreen : SystemColors.ControlLightLight;
        }

        private async void LoadBookmarks(Action onLoaded)
        {
            if (_bookmarkService == null)
                return;

            try
            {
                IEnumerable<Bookmark> bookmarks;
                if (IsFilterApplied)
                {
                    bookmarks = await _bookmarkService.GetAllAsync(titleFilter, typeFilter, groupsFilter, tagsFilter, from, to);
                }
                else
                {
                    bookmarks = await _bookmarkService.GetAllAsync();
                }

                var counter = 0;
                foreach (var bookmark in bookmarks)
                {
                    AddBookmarkGridModelToDataTable(new BookmarkGridModel(++counter, bookmark));
                }

                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;

                onLoaded();
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
            // TODO: move this to a separate method or service
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

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            using (var formFilter = new FormFilter(_tagService,
                                                   _groupService,
                                                   titleFilter,
                                                   typeFilter,
                                                   (string[]?)groupsFilter?.Clone(),
                                                   (string[]?)tagsFilter?.Clone(),
                                                   from,
                                                   to))
            {
                var dialogResult = formFilter.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    titleFilter = formFilter.Title;
                    typeFilter = formFilter.Type;
                    groupsFilter = formFilter.Groups;
                    tagsFilter = formFilter.Tags;
                    from = formFilter.From;
                    to = formFilter.To;

                    ReloadBookmarks();
                }
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetFormTitle();
            UpdateUI();
        }

        private void SetFormTitle()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow != null)
                {
                    var title = selectedRow.Cells["Title"].Value?.ToString();
                    var rowNo = selectedRow.Cells["No"].Value?.ToString();
                    var totalCount = dataGridView1.Rows.Count.ToString();
                    if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(rowNo))
                    {
                        Text = $"Bookmarker - {title} ({rowNo} of {totalCount})";
                    }
                    else
                    {
                        Text = $"Bookmarker ({totalCount})";
                    }
                }
            }
            else
            {
                Text = "Bookmarker";
            }
        }
    }
}
