using Bookmarker.Application.Validators;
using Bookmarker.Domain.Interfaces.Services;
using Bookmarker.Domain.Interfaces.Validation;
using Bookmarker.Domain.Interfaces.Validators;
using Bookmarker.Domain.Models;
using System.ComponentModel;
using System.Data;

namespace Bookmarker.Presentation
{
    public partial class FormDetails : Form
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly IBookmarkParserService _bookmarkParserService;
        private readonly ITagService _tagService;
        private readonly string? _bookmarkId;
        private readonly List<string> currentTags = new List<string>();

        private TagsDataOrder order = TagsDataOrder.Name;
        private ErrorProvider errorProvider = new ErrorProvider();

        private List<IControlValidator<string>> urlValidators = new List<IControlValidator<string>>();
        private List<IControlValidator<string>> idValidators = new List<IControlValidator<string>>();
        private List<IControlValidator<string>> titleValidators = new List<IControlValidator<string>>();
        private List<IControlValidator<string>> groupValidators = new List<IControlValidator<string>>();
        private List<IControlValidator<string>> tagsValidators = new List<IControlValidator<string>>();
        private List<IControlValidator<string>> createdValidators = new List<IControlValidator<string>>();

        public FormDetails(
            IBookmarkService bookmarkService,
            IBookmarkParserService bookmarkParserService,
            ITagService tagService,
            string? bookmarkId)
        {
            _bookmarkService = bookmarkService;
            _bookmarkParserService = bookmarkParserService;
            _tagService = tagService;
            _bookmarkId = bookmarkId;

            InitializeComponent();
            SetFormStyle();
            SetValidators();
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
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private async void LoadTagData()
        {
            var tagData = await _tagService.GetAllTagDataAsync(order);

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
                textBoxCreated.Text = bookmark.Created;

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

        private void SetValidators()
        {
            urlValidators.AddRange([
                new ControlValidator<string>(textBoxUrl, new RequiredValidator(), "URL cannot be empty."),
                new ControlValidator<string>(textBoxUrl, new UrlValidator(), "Invalid URL format.")
            ]);
            idValidators.AddRange([
                new ControlValidator<string>(textBoxId, new RequiredValidator(), "Id cannot be empty."),
                new ControlValidator<string>(textBoxId, new MinLengthValidator(5), "Id must be at least 5 characters long."),
                new ControlValidator<string>(textBoxId, new MaxLengthValidator(20), "Id cannot exceed 20 characters.")
            ]);
            titleValidators.AddRange([
                new ControlValidator<string>(textBoxTitle, new RequiredValidator(), "Title cannot be empty."),
                new ControlValidator<string>(textBoxTitle, new MinLengthValidator(3), "Title must be at least 3 characters long."),
                new ControlValidator<string>(textBoxTitle, new MaxLengthValidator(100), "Title cannot exceed 45 characters.")
            ]);
            groupValidators.AddRange([
                new ControlValidator<string>(textBoxGroup, new RequiredValidator(), "Group cannot be empty."),
                new ControlValidator<string>(textBoxGroup, new MinLengthValidator(1), "Group must be at least 1 characters long."),
                new ControlValidator<string>(textBoxGroup, new MaxLengthValidator(45), "Group cannot exceed 45 characters."),
                new ControlValidator<string>(textBoxGroup, new WordsCountValidator(1), "Group must contain exactly 1 word.")
            ]);
            tagsValidators.AddRange([
                new ControlValidator<string>(textBoxTags, new TagsValidator(), "Invalid tags format. Use #tag1, #tag2, ..."),
            ]);
            createdValidators.AddRange([
                new ControlValidator<string>(textBoxCreated, new RequiredValidator(), "Created date cannot be empty."),
                new ControlValidator<string>(textBoxCreated, new DateValidator(), "Invalid date. Use yyyy-MM-dd format.")
            ]);
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            textBoxUrl.Text = Clipboard.GetText().Trim();
            ValidateUrl();
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

                ValidateAllFields();
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
            {
                MessageBox.Show("Please correct the errors in the form.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var id = textBoxId.Text.Trim();
            if (await _bookmarkService.GetByIdAsync(id) != null)
            {
                MessageBox.Show("A bookmark with this ID already exists. Please choose a different ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var bookmark = new Bookmark(
                Id: id,
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
                var tagData = await _tagService.GetTagDataAsync(order, filter);

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

        private bool ValidateAllFields()
        {
            // Validate all fields before saving
            // without short-circuiting to ensure all errors are shown at once
            return ValidateUrl() &
                   ValidateId() &
                   ValidateTitle() &
                   ValidateGroup() &
                   ValidateTags() &
                   ValidateCreated();
        }

        private void TextBoxUrl_Validating(object sender, CancelEventArgs e)
        {
            ValidateUrl();
        }

        private void TextBoxId_Validating(object sender, CancelEventArgs e)
        {
            ValidateId();
        }

        private void TextBoxTitle_Validating(object sender, CancelEventArgs e)
        {
            ValidateTitle();
        }

        private void TextBoxGroup_Validating(object sender, CancelEventArgs e)
        {
            ValidateGroup();
        }

        private void textBoxCreated_Validating(object sender, CancelEventArgs e)
        {
            ValidateCreated();
        }

        private void textBoxTags_Validating(object sender, CancelEventArgs e)
        {
            ValidateTags();
        }

        private bool ValidateUrl() => ValidateControl(textBoxUrl, urlValidators);
        private bool ValidateId() => ValidateControl(textBoxId, idValidators);
        private bool ValidateTitle() => ValidateControl(textBoxTitle, titleValidators);
        private bool ValidateGroup() => ValidateControl(textBoxGroup, groupValidators);
        private bool ValidateTags() => ValidateControl(textBoxTags, tagsValidators);
        private bool ValidateCreated() => ValidateControl(textBoxCreated, createdValidators);
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
    }
}
