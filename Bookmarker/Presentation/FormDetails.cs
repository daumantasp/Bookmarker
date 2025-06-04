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

        public FormDetails(Bookmark bookmark)
        {
            _bookmark = bookmark;

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
    }
}
