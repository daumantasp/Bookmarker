using Bookmarker.Application.Validators;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Interfaces.Validation;
using Bookmarker.Domain.Interfaces.Validators;
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
        public string? Type { get => checkBoxType.Checked ? _type : null; }

        public string[]? Groups { get => _groups.ToArray(); }
        public string[]? Tags { get => _tags.Select(t => t.Substring(1)).ToArray(); }
        public DateTime? From { get => checkBoxFrom.Checked ? _from : null; }
        public DateTime? To { get => checkBoxTo.Checked ? _to : null; }

        private ErrorProvider errorProvider = new ErrorProvider();

        private List<IControlValidator<string>> titleValidators = new List<IControlValidator<string>>();
        private IControlValidator<DateTime, DateTime> fromDateValidator;

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
            _tags = new List<string>(tags?.Select(t => "#" + t) ?? []);
            _from = from;
            _to = to;

            SetFormStyle();
            SetTitle();
            SetType();
            SetGroup();
            SetTags();
            SetFrom();
            SetTo();
            SetValidators();
        }

        private void SetFormStyle()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
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
                var tagName = "#" + tag.Name;
                checkedListBoxTags.Items.Add(tagName, _tags.Contains(tagName));
            }
        }

        private void SetType()
        {
            if (string.IsNullOrEmpty(_type))
            {
                checkBoxType.Checked = false;
                radioButtonPost.Enabled = false;
                radioButtonComment.Enabled = false;
            }
            else
            {
                checkBoxType.Checked = true;
                radioButtonPost.Enabled = true;
                radioButtonComment.Enabled = true;
            }
            if (_type == "Post")
            {
                radioButtonPost.Checked = true;
            }
            else if (_type == "Comment")
            {
                radioButtonComment.Checked = true;
            }
            else
            {
                radioButtonPost.Checked = true;
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
            dateTimePickerTo.MaxDate = DateTime.Now.Date;
        }

        private void SetValidators()
        {
            titleValidators.AddRange([
                new ControlValidator<string>(textBoxTitle, new MinLengthValidator(3), "Title must be at least 3 characters long."),
                new ControlValidator<string>(textBoxTitle, new MaxLengthValidator(100), "Title cannot exceed 45 characters.")
            ]);
            fromDateValidator = new ControlValidator<DateTime, DateTime>(
                dateTimePickerFrom,
                new DateRangeValidator(),
                "The 'From' date must be earlier than or equal to the 'To' date."
            );
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
            if (!ValidateAllFields())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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
            checkBoxType.Checked = false;
            radioButtonPost.Enabled = false;
            radioButtonComment.Enabled = false;
            radioButtonPost.Checked = true;

            _from = null;
            checkBoxFrom.Checked = false;
            dateTimePickerFrom.Enabled = false;
            dateTimePickerFrom.Value = DateTime.Now.Date;

            _to = null;
            checkBoxTo.Checked = false;
            dateTimePickerTo.Enabled = false;
            dateTimePickerTo.Value = DateTime.Now.Date;
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
            ValidateFromDate();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            _to = dateTimePickerTo.Value.Date;
            ValidateFromDate();
        }

        private void buttonToday_Click(object sender, EventArgs e)
        {
            var today = DateTime.Now.Date;
            dateTimePickerFrom.Value = today;
            dateTimePickerTo.Value = today;
            _from = today;
            _to = today;
            checkBoxFrom.Checked = true;
            checkBoxTo.Checked = true;
        }

        private void buttonYesterday_Click(object sender, EventArgs e)
        {
            var yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePickerFrom.Value = yesterday;
            dateTimePickerTo.Value = yesterday;
            _from = yesterday;
            _to = yesterday;
            checkBoxFrom.Checked = true;
            checkBoxTo.Checked = true;
        }

        private void buttonThisWeek_Click(object sender, EventArgs e)
        {
            var dayOfWeek = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + 1);
            var today = DateTime.Now.Date;
            dateTimePickerFrom.Value = dayOfWeek;
            dateTimePickerTo.Value = today;
            _from = dayOfWeek;
            _to = today;
            checkBoxFrom.Checked = true;
            checkBoxTo.Checked = true;
        }

        private void buttonThisMonth_Click(object sender, EventArgs e)
        {
            var startOfTheMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var today = DateTime.Now.Date;
            dateTimePickerFrom.Value = startOfTheMonth;
            dateTimePickerTo.Value = today;
            _from = startOfTheMonth;
            _to = today;
            checkBoxFrom.Checked = true;
            checkBoxTo.Checked = true;
        }

        private void buttonThisYear_Click(object sender, EventArgs e)
        {
            var startOfTheYear = new DateTime(DateTime.Now.Year, 1, 1);
            var today = DateTime.Now.Date;
            dateTimePickerFrom.Value = startOfTheYear;
            dateTimePickerTo.Value = today;
            _from = startOfTheYear;
            _to = today;
            checkBoxFrom.Checked = true;
            checkBoxTo.Checked = true;
        }

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonPost.Enabled = checkBoxType.Checked;
            radioButtonComment.Enabled = checkBoxType.Checked;
        }

        private void radioButtonPost_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPost.Checked)
            {
                _type = "Post";
            }
        }

        private void radioButtonComment_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonComment.Checked)
            {
                _type = "Comment";
            }
        }

        private bool ValidateFromDate()
        {
            if (fromDateValidator == null) return true;

            if (checkBoxFrom.Checked && checkBoxTo.Checked)
            {
                if (_from != null && _to != null && _from.HasValue && _to.HasValue)
                {
                    var validationResult = fromDateValidator.Validate(_from.Value, _to.Value);
                    if (!validationResult.IsValid)
                    {
                        errorProvider.SetError(dateTimePickerTo, validationResult.ErrorMessage);
                        return false;
                    }
                }
            }
            errorProvider.SetError(dateTimePickerTo, string.Empty);
            return true;
        }

        private void dateTimePickerFrom_Validating(object sender, CancelEventArgs e)
        {
            ValidateFromDate();
        }

        private void dateTimePickerTo_Validating(object sender, CancelEventArgs e)
        {
            ValidateFromDate();
        }

        private bool ValidateTitle()
        {
            if (string.IsNullOrEmpty(_title)) 
                return true;
            else 
                return ValidateControl(textBoxTitle, titleValidators);
        }

        private bool ValidateControl(Control control, IEnumerable<IControlValidator<string>> validators)
        {
            foreach (var validator in validators)
            {
                var validationResult = validator.Validate(control.Text.Trim());
                if (!validationResult.IsValid)
                {
                    errorProvider.SetError(control, validationResult.ErrorMessage);
                    return false;
                }
            }
            errorProvider.SetError(control, string.Empty);
            return true;
        }

        private bool ValidateAllFields()
        {
            // Validate all fields before saving
            // without short-circuiting to ensure all errors are shown at once
            return ValidateTitle() &
                   ValidateFromDate();
        }
    }
}
