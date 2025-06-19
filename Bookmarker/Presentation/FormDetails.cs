using Bookmarker.Application.Services;
using Bookmarker.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookmarker.Presentation
{
    public partial class FormDetails : Form
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;
        private readonly string? _bookmarkId;
        private readonly List<string> currentTags = new List<string>();

        private TagsDataOrder order = TagsDataOrder.Name;


        public FormDetails(
            IBookmarkService bookmarkService,
            IBookmarkParserService bookmarkParserService,
            string? bookmarkId)
        {
            _bookmarkService = bookmarkService;
            _bookmarkParserService = bookmarkParserService;
            _bookmarkId = bookmarkId;

            InitializeComponent();
            SetFormStyle();
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            LoadTagData();
            LoadBookmarkData();
        }

        private void SetFormStyle()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private async void LoadTagData()
        {
            var tagData = await _bookmarkService.GetAllTagDataAsync(order);

            dataGridViewTagData.DataSource = null;
            dataGridViewTagData.DataSource = tagData;
        }

        private async void LoadBookmarkData()
        {
            if (string.IsNullOrEmpty(_bookmarkId))
            {
                ClearFields();
                SetTodayDate();
                return;
            }

            var bookmark = await _bookmarkService.GetByIdAsync(_bookmarkId);

            if (bookmark != null)
            {
                Text = "Edit Bookmark - " + bookmark.Title;

                textBoxId.Text = bookmark.Id;
                textBoxUrl.Text = bookmark.Url;
                textBoxTitle.Text = bookmark.Title;
                textBoxGroup.Text = bookmark.Group;
                radioButtonComment.Checked = bookmark.Type.ToLower() == "comment";

                if (bookmark.Tags != null)
                {
                    currentTags.Clear();
                    currentTags.AddRange(bookmark.Tags);

                    textBoxTags.Text = string.Join(", ", bookmark.Tags.Select(t => "#" + t));

                    foreach (DataGridViewRow row in dataGridViewTagData.Rows)
                    {
                        row.Selected = bookmark.Tags.Contains(row.Cells["Name"].Value);
                    }
                }
                else
                {
                    textBoxTags.Text = string.Empty;
                }
            }
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            textBoxUrl.Text = Clipboard.GetText().Trim();
        }

        private void buttonParseUrl_Click(object sender, EventArgs e)
        {
            var text = textBoxUrl.Text.Trim();

            var bookmark = _bookmarkParserService.Parse(text);
            if (bookmark != null)
            {
                textBoxUrl.Text = bookmark.Url;
                textBoxId.Text = bookmark.Id;
                textBoxTitle.Text = bookmark.Title;
                textBoxGroup.Text = bookmark.Group;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var bookmark = new Bookmark(
                Id: textBoxId.Text.Trim(),
                Type: radioButtonPost.Checked ? "post" : "comment",
                Title: textBoxTitle.Text.Trim(),
                Group: textBoxGroup.Text.Trim(),
                Url: textBoxUrl.Text.Trim(),
                Tags: string.IsNullOrEmpty(textBoxTags.Text) ?
                    Array.Empty<string>() :
                    textBoxTags.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim().TrimStart('#')).ToArray(),
                Created: string.IsNullOrWhiteSpace(textBoxCreated.Text) ? null : textBoxCreated.Text.Trim()
            );

            if (_bookmarkId == null)
            {
                await _bookmarkService.AddAsync(bookmark);
            }
            else
            {
                await _bookmarkService.UpdateAsync(bookmark);
            }

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewTagData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = dataGridViewTagData.Columns[e.ColumnIndex].Name.ToString().ToLower();
            order = columnName == "name" ? TagsDataOrder.Name : TagsDataOrder.Count;
            LoadTagData();
        }

        private async void textBoxSearchTags_TextChanged(object sender, EventArgs e)
        {
            var filter = textBoxSearchTags.Text.Trim();

            if (filter.Length > 3)
            {
                var tagData = await _bookmarkService.GetTagDataAsync(order, filter);

                dataGridViewTagData.DataSource = null;
                dataGridViewTagData.DataSource = tagData.ToList();
            }
            else
            {
                LoadTagData();
            }
        }

        private void ClearFields()
        {
            Text = "Add New Bookmark";
            textBoxId.Clear();
            textBoxUrl.Clear();
            radioButtonPost.Checked = true;
            textBoxTitle.Clear();
            textBoxGroup.Clear();
            textBoxTags.Clear();
        }

        private void SetTodayDate()
        {
            textBoxCreated.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void dataGridViewTagData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0 || e.RowIndex >= dataGridViewTagData.Rows.Count)
            //    return;

            var tagName = dataGridViewTagData.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            if (!string.IsNullOrEmpty(tagName))
            {
                if (!currentTags.Contains(tagName))
                    currentTags.Add(tagName);

                textBoxTags.Text = string.Join(", ", currentTags.Select(t => "#" + t));
            }
        }
    }
}
