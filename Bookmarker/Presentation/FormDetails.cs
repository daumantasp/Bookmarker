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
            if (!string.IsNullOrEmpty(_bookmarkId))
            {
                LoadBookmarkData(_bookmarkId);
            }
            else
            {
                // If no bookmark ID is provided, clear the fields
                textBoxId.Clear();
                textBoxUrl.Clear();
                radioButtonPost.Checked = true; // Default to Post type
                radioButtonComment.Checked = false; // Uncheck Comment type
                textBoxTitle.Clear();
                textBoxGroup.Clear();
                textBoxTags.Clear();
            }

            LoadTagData(TagsDataOrder.Name);
            radioButtonOrderByName.Checked = true; // Default to order by name
        }

        private async void LoadBookmarkData(string bookmarkId)
        {
            var bookmark = await _bookmarkService.GetByIdAsync(bookmarkId);

            if (bookmark != null)
            {
                textBoxId.Text = bookmark.Id;
                textBoxUrl.Text = bookmark.Url;
                textBoxTitle.Text = bookmark.Title;
                textBoxGroup.Text = bookmark.Group;
                radioButtonComment.Checked = bookmark.Type.ToLower() == "comment";

                //if (bookmark.Tags != null)
                //{
                //    textBoxTags.Text = string.Join(", ", bookmark.Tags);
                //}
                //else
                //{
                //    textBoxTags.Text = string.Empty;
                //}
            }
            else
            {
                MessageBox.Show("Bookmark not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void LoadTagData(TagsDataOrder order)
        {
            var tagData = await _bookmarkService.GetAllTagDataAsync(order);

            dataGridViewTagData.DataSource = null;
            dataGridViewTagData.DataSource = tagData;
        }

        private void textBoxUrl_Leave(object sender, EventArgs e)
        {
            var text = textBoxUrl.Text.Trim();

            var bookmark = _bookmarkParserService.Parse(text);
            if (bookmark != null)
            {
                // Update the form fields with the parsed bookmark data
                textBoxUrl.Text = bookmark.Url;
                textBoxId.Text = bookmark.Id;
                textBoxTitle.Text = bookmark.Title;
                textBoxGroup.Text = bookmark.Group;
                //textBoxTags.Text = string.Join(", ", bookmark.Tags);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
