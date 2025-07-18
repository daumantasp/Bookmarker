using Bookmarker.Domain.Interfaces.Services;
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
    public partial class FormFilter : Form
    {
        private readonly ITagService _tagService;

        private string? _title = null;
        private string? _group = null;
        private List<string> _tags;

        public string? Title { get => _title; }

        public string? Group { get => _group; }
        public string[]? Tags { get => _tags.ToArray(); }

        public FormFilter(ITagService tagService, string? title, string? group, string[]? tags)
        {
            InitializeComponent();

            _tagService = tagService;

            _title = title;
            _group = group;
            _tags = new List<string>(tags ?? []);

            SetTitle();
            SetGroup();
            SetTags();
        }

        private void SetTitle()
        {
            if (_title != null)
            {
                textBoxTitle.Text = _title;
            }
            else
            {
                textBoxTitle.Text = string.Empty;
            }
        }

        private void SetGroup()
        {
            if (_group != null)
            {
                textBoxGroup.Text = _group;
            }
            else
            {
                textBoxGroup.Text = string.Empty;
            }
        }

        private async void SetTags()
        {
            var tagData = await _tagService.GetAllTagDataAsync(TagsDataOrder.Name);

            foreach (var tag in tagData)
            {
                checkedListBoxTags.Items.Add(tag.Name, _tags.Contains(tag.Name));
            }
        }

        private void checkedListBoxTags_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var tag = checkedListBoxTags.Items[e.Index].ToString();

            if (tag != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (!_tags.Contains(tag))
                    {
                        _tags.Add(tag);
                    }
                }
                else
                {
                    if (_tags.Contains(tag))
                    {
                        _tags.Remove(tag);
                    }
                }
            }

            labelFilterStatus.Text = $"Filtering by: {string.Join(", ", _tags)}";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            _title = textBoxTitle.Text.Trim();
        }

        private void textBoxGroup_TextChanged(object sender, EventArgs e)
        {
            _group = textBoxGroup.Text.Trim();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = string.Empty;
            textBoxGroup.Text = string.Empty;

            _tags.Clear();
            for (int i = 0; i < checkedListBoxTags.Items.Count; i++)
            {
                checkedListBoxTags.SetItemChecked(i, false);
            }
        }
    }
}
