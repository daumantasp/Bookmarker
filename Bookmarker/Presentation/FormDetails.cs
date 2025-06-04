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
        private readonly Bookmark _bookmark;
        private readonly IBookmarkService _bookmarkService;

        public FormDetails(Bookmark bookmark, IBookmarkService bookmarkService)
        {
            _bookmark = bookmark;
            _bookmarkService = bookmarkService;

            InitializeComponent();
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            if (_bookmark == null)
            {
                MessageBox.Show("Bookmark is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //textBoxTitle.Text = _bookmark.Title;
            textBoxUrl.Text = _bookmark.Url;
            //textBoxDescription.Text = _bookmark.Description;
            //textBoxTags.Text = string.Join(", ", _bookmark.Tags);
            //textBoxCreatedAt.Text = _bookmark.CreatedAt.ToString("g");
            //textBoxUpdatedAt.Text = _bookmark.UpdatedAt.ToString("g");
        }

        private async void LoadTagData(TagsDataOrder order)
        {
            var tagData = await _bookmarkService.GetAllTagDataAsync(order);

            dataGridViewTagData.DataSource = null;
            dataGridViewTagData.DataSource = tagData;
        }

        private void radioButtonOrderByName_CheckedChanged(object sender, EventArgs e)
        {
            LoadTagData(TagsDataOrder.Name);
        }

        private void radioButtonOrderByCount_CheckedChanged(object sender, EventArgs e)
        {
            LoadTagData(TagsDataOrder.Count);
        }
    }
}
