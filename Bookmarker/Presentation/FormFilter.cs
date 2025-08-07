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
        private readonly IGroupService _groupService;

        private string? _title = null;
        private string? _type = null;
        private List<string> _groups;
        private List<string> _tags;
        private DateTime? _from = null;
        private DateTime? _to = null;

        public string? Title { get => _title; }
        public string? Type { get => _type; }

        public string[]? Groups { get => _groups.ToArray(); }
        public string[]? Tags { get => _tags.ToArray(); }
        public DateTime? From { get => checkBoxFrom.Enabled ? _from : null; }
        public DateTime? To { get => checkBoxTo.Enabled ? _to : null; }

        public FormFilter(ITagService tagService,
                          IGroupService groupService,
                          string? title,
                          string? type,
                          string[]? groups,
                          string[]? tags,
                          DateTime? from,
                          DateTime? to)
        {
            InitializeComponent();

            _tagService = tagService;
            _groupService = groupService;

            _title = title;
            _type = type;
            _groups = new List<string>(groups ?? []);
            _tags = new List<string>(tags ?? []);
            _from = from;
            _to = to;

            SetTitle();
            SetType();
            SetGroup();
            SetTags();
            SetFrom();
            SetTo();
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

        private async void SetGroup()
        {
            var groupData = await _groupService.GetAllGroupDataAsync(GroupsDataOrder.Name);

            foreach (var group in groupData)
            {
                checkedListBoxGroups.Items.Add(group.Name, _groups.Contains(group.Name));
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

        private void SetType()
        {
            if (string.IsNullOrEmpty(_type))
            {
                checkBoxComment.Checked = true;
                checkBoxPost.Checked = true;
            }
            if (_type == "Comment")
            {
                checkBoxComment.Checked = true;
                checkBoxPost.Checked = false;
            }
            if (_type == "Post")
            {
                checkBoxComment.Checked = false;
                checkBoxPost.Checked = true;
            }
        }

        private void SetFrom()
        {
            if (_from.HasValue)
            {
                checkBoxFrom.Checked = true;
                dateTimePickerFrom.Value = _from.Value;
                dateTimePickerFrom.Enabled = true;
            }
            else
            {
                checkBoxFrom.Checked = false;
                dateTimePickerFrom.Enabled = false;
            }
            dateTimePickerFrom.MaxDate = DateTime.Now.Date;
        }

        private void SetTo()
        {
            if (_to.HasValue)
            {
                checkBoxTo.Checked = true;
                dateTimePickerTo.Value = _to.Value;
                dateTimePickerTo.Enabled = true;
            }
            else
            {
                checkBoxTo.Checked = false;
                dateTimePickerTo.Enabled = false;
            }
            dateTimePickerFrom.MaxDate = DateTime.Now.Date;
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
        }

        private void checkedListBoxGroups_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var group = checkedListBoxGroups.Items[e.Index].ToString();

            if (group != null)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (!_groups.Contains(group))
                    {
                        _groups.Add(group);
                    }
                }
                else
                {
                    if (_groups.Contains(group))
                    {
                        _groups.Remove(group);
                    }
                }
            }
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            _title = textBoxTitle.Text.Trim();
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

        private void checkBoxPost_CheckedChanged(object sender, EventArgs e)
        {
            TypeCheckboxChanged();


        }

        private void checkBoxComment_CheckedChanged(object sender, EventArgs e)
        {
            TypeCheckboxChanged();
        }

        private void TypeCheckboxChanged()
        {
            if (checkBoxPost.Checked && !checkBoxComment.Checked)
            {
                _type = "Post";
            }
            if (checkBoxComment.Checked && !checkBoxPost.Checked)
            {
                _type = "Comment";
            }
            if (checkBoxPost.Checked && checkBoxComment.Checked)
            {
                _type = null;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = string.Empty;

            _tags.Clear();
            for (int i = 0; i < checkedListBoxTags.Items.Count; i++)
            {
                checkedListBoxTags.SetItemChecked(i, false);
            }

            _groups.Clear();
            for (int i = 0; i < checkedListBoxGroups.Items.Count; i++)
            {
                checkedListBoxGroups.SetItemChecked(i, false);
            }

            _type = null;
            checkBoxPost.Checked = true;
            checkBoxComment.Checked = true;

            _from = null;
            checkBoxFrom.Checked = false;
            dateTimePickerFrom.Enabled = false;

            _to = null;
            checkBoxTo.Checked = false;
            dateTimePickerTo.Enabled = false;
        }

        private void checkBoxFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFrom.Checked)
            {
                dateTimePickerFrom.Enabled = true;
            }
            else
            {
                dateTimePickerFrom.Enabled = false;
            }
        }

        private void checkBoxTo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTo.Checked)
            {
                dateTimePickerTo.Enabled = true;
            }
            else
            {
                dateTimePickerTo.Enabled = false;
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            _from = dateTimePickerFrom.Value.Date;
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            _to = dateTimePickerTo.Value.Date;
        }
    }
}
