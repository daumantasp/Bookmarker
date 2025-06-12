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

        public FormDetails(
            IBookmarkService bookmarkService,
            IBookmarkParserService bookmarkParserService,
            string? bookmarkId)
        {
            _bookmarkService = bookmarkService;
            _bookmarkParserService = bookmarkParserService;
            _bookmarkId = bookmarkId;

            InitializeComponent();
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            LoadTagData(TagsDataOrder.Name);

            if (!string.IsNullOrEmpty(_bookmarkId))
            {
                LoadBookmarkData(_bookmarkId);
            }
            else
            {
                ClearFields();
            }
        }

        private async void LoadTagData(TagsDataOrder order)
        {
            var tagData = await _bookmarkService.GetAllTagDataAsync(order);

            dataGridViewTagData.DataSource = null;
            dataGridViewTagData.DataSource = tagData;
        }

        private async void LoadBookmarkData(string bookmarkId)
        {
            var bookmark = await _bookmarkService.GetByIdAsync(bookmarkId);

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

        private void radioButtonOrderByName_CheckedChanged(object sender, EventArgs e)
        {
            LoadTagData(TagsDataOrder.Name);
        }

        private void radioButtonOrderByCount_CheckedChanged(object sender, EventArgs e)
        {
            LoadTagData(TagsDataOrder.Count);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void textBoxSearchTags_TextChanged(object sender, EventArgs e)
        {
            var filter = textBoxSearchTags.Text.Trim();
            var order = radioButtonOrderByName.Checked ? TagsDataOrder.Name : TagsDataOrder.Count;

            if (filter.Length > 3)
            {
                var tagData = await _bookmarkService.GetTagDataAsync(order, filter);

                dataGridViewTagData.DataSource = null;
                dataGridViewTagData.DataSource = tagData.ToList();
            }
            else
            {
                LoadTagData(order);
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
    }
}
