namespace Bookmarker.Presentation
{
    partial class FormFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelFilterByTag = new Label();
            checkedListBoxTags = new CheckedListBox();
            buttonApply = new Button();
            buttonCancel = new Button();
            labelFilterByTitle = new Label();
            textBoxTitle = new TextBox();
            buttonClear = new Button();
            labelFilterByGroups = new Label();
            checkedListBoxGroups = new CheckedListBox();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            checkBoxFrom = new CheckBox();
            checkBoxTo = new CheckBox();
            buttonToday = new Button();
            buttonYesterday = new Button();
            buttonThisWeek = new Button();
            buttonThisMonth = new Button();
            buttonThisYear = new Button();
            checkBoxType = new CheckBox();
            radioButtonPost = new RadioButton();
            radioButtonComment = new RadioButton();
            SuspendLayout();
            // 
            // labelFilterByTag
            // 
            labelFilterByTag.AutoSize = true;
            labelFilterByTag.Location = new Point(14, 130);
            labelFilterByTag.Name = "labelFilterByTag";
            labelFilterByTag.Size = new Size(34, 15);
            labelFilterByTag.TabIndex = 0;
            labelFilterByTag.Text = "Tags:";
            // 
            // checkedListBoxTags
            // 
            checkedListBoxTags.CheckOnClick = true;
            checkedListBoxTags.FormattingEnabled = true;
            checkedListBoxTags.Location = new Point(14, 148);
            checkedListBoxTags.Name = "checkedListBoxTags";
            checkedListBoxTags.Size = new Size(166, 220);
            checkedListBoxTags.TabIndex = 1;
            checkedListBoxTags.ItemCheck += checkedListBoxTags_ItemCheck;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(15, 589);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(75, 23);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(290, 589);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelFilterByTitle
            // 
            labelFilterByTitle.AutoSize = true;
            labelFilterByTitle.Location = new Point(14, 9);
            labelFilterByTitle.Name = "labelFilterByTitle";
            labelFilterByTitle.Size = new Size(33, 15);
            labelFilterByTitle.TabIndex = 4;
            labelFilterByTitle.Text = "Title:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(14, 27);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(351, 23);
            textBoxTitle.TabIndex = 5;
            textBoxTitle.TextChanged += textBoxTitle_TextChanged;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(96, 589);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 8;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelFilterByGroups
            // 
            labelFilterByGroups.AutoSize = true;
            labelFilterByGroups.Location = new Point(204, 130);
            labelFilterByGroups.Name = "labelFilterByGroups";
            labelFilterByGroups.Size = new Size(48, 15);
            labelFilterByGroups.TabIndex = 6;
            labelFilterByGroups.Text = "Groups:";
            // 
            // checkedListBoxGroups
            // 
            checkedListBoxGroups.FormattingEnabled = true;
            checkedListBoxGroups.Location = new Point(204, 148);
            checkedListBoxGroups.Name = "checkedListBoxGroups";
            checkedListBoxGroups.Size = new Size(161, 220);
            checkedListBoxGroups.TabIndex = 9;
            checkedListBoxGroups.ItemCheck += checkedListBoxGroups_ItemCheck;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerFrom.Location = new Point(14, 410);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(351, 23);
            dateTimePickerFrom.TabIndex = 14;
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerTo.Location = new Point(14, 481);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(350, 23);
            dateTimePickerTo.TabIndex = 16;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
            // 
            // checkBoxFrom
            // 
            checkBoxFrom.AutoSize = true;
            checkBoxFrom.Location = new Point(15, 385);
            checkBoxFrom.Name = "checkBoxFrom";
            checkBoxFrom.Size = new Size(57, 19);
            checkBoxFrom.TabIndex = 17;
            checkBoxFrom.Text = "From:";
            checkBoxFrom.UseVisualStyleBackColor = true;
            checkBoxFrom.CheckedChanged += checkBoxFrom_CheckedChanged;
            // 
            // checkBoxTo
            // 
            checkBoxTo.AutoSize = true;
            checkBoxTo.Location = new Point(14, 456);
            checkBoxTo.Name = "checkBoxTo";
            checkBoxTo.Size = new Size(42, 19);
            checkBoxTo.TabIndex = 18;
            checkBoxTo.Text = "To:";
            checkBoxTo.UseVisualStyleBackColor = true;
            checkBoxTo.CheckedChanged += checkBoxTo_CheckedChanged;
            // 
            // buttonToday
            // 
            buttonToday.Location = new Point(12, 510);
            buttonToday.Name = "buttonToday";
            buttonToday.Size = new Size(52, 23);
            buttonToday.TabIndex = 19;
            buttonToday.Text = "Today";
            buttonToday.UseVisualStyleBackColor = true;
            buttonToday.Click += buttonToday_Click;
            // 
            // buttonYesterday
            // 
            buttonYesterday.Location = new Point(70, 510);
            buttonYesterday.Name = "buttonYesterday";
            buttonYesterday.Size = new Size(66, 23);
            buttonYesterday.TabIndex = 20;
            buttonYesterday.Text = "Yesterday";
            buttonYesterday.UseVisualStyleBackColor = true;
            buttonYesterday.Click += buttonYesterday_Click;
            // 
            // buttonThisWeek
            // 
            buttonThisWeek.Location = new Point(142, 510);
            buttonThisWeek.Name = "buttonThisWeek";
            buttonThisWeek.Size = new Size(69, 23);
            buttonThisWeek.TabIndex = 21;
            buttonThisWeek.Text = "This Week";
            buttonThisWeek.UseVisualStyleBackColor = true;
            buttonThisWeek.Click += buttonThisWeek_Click;
            // 
            // buttonThisMonth
            // 
            buttonThisMonth.Location = new Point(217, 510);
            buttonThisMonth.Name = "buttonThisMonth";
            buttonThisMonth.Size = new Size(77, 23);
            buttonThisMonth.TabIndex = 22;
            buttonThisMonth.Text = "This Month";
            buttonThisMonth.UseVisualStyleBackColor = true;
            buttonThisMonth.Click += buttonThisMonth_Click;
            // 
            // buttonThisYear
            // 
            buttonThisYear.Location = new Point(300, 510);
            buttonThisYear.Name = "buttonThisYear";
            buttonThisYear.Size = new Size(65, 23);
            buttonThisYear.TabIndex = 23;
            buttonThisYear.Text = "This Year";
            buttonThisYear.UseVisualStyleBackColor = true;
            buttonThisYear.Click += buttonThisYear_Click;
            // 
            // checkBoxType
            // 
            checkBoxType.AutoSize = true;
            checkBoxType.Location = new Point(15, 63);
            checkBoxType.Name = "checkBoxType";
            checkBoxType.Size = new Size(54, 19);
            checkBoxType.TabIndex = 24;
            checkBoxType.Text = "Type:";
            checkBoxType.UseVisualStyleBackColor = true;
            checkBoxType.CheckedChanged += checkBoxType_CheckedChanged;
            // 
            // radioButtonPost
            // 
            radioButtonPost.AutoSize = true;
            radioButtonPost.Location = new Point(21, 88);
            radioButtonPost.Name = "radioButtonPost";
            radioButtonPost.Size = new Size(48, 19);
            radioButtonPost.TabIndex = 25;
            radioButtonPost.TabStop = true;
            radioButtonPost.Text = "Post";
            radioButtonPost.UseVisualStyleBackColor = true;
            radioButtonPost.CheckedChanged += radioButtonPost_CheckedChanged;
            // 
            // radioButtonComment
            // 
            radioButtonComment.AutoSize = true;
            radioButtonComment.Location = new Point(101, 88);
            radioButtonComment.Name = "radioButtonComment";
            radioButtonComment.Size = new Size(79, 19);
            radioButtonComment.TabIndex = 26;
            radioButtonComment.TabStop = true;
            radioButtonComment.Text = "Comment";
            radioButtonComment.UseVisualStyleBackColor = true;
            radioButtonComment.CheckedChanged += radioButtonComment_CheckedChanged;
            // 
            // FormFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 624);
            Controls.Add(radioButtonComment);
            Controls.Add(radioButtonPost);
            Controls.Add(checkBoxType);
            Controls.Add(buttonThisYear);
            Controls.Add(buttonThisMonth);
            Controls.Add(buttonThisWeek);
            Controls.Add(buttonYesterday);
            Controls.Add(buttonToday);
            Controls.Add(checkBoxTo);
            Controls.Add(checkBoxFrom);
            Controls.Add(dateTimePickerTo);
            Controls.Add(dateTimePickerFrom);
            Controls.Add(checkedListBoxGroups);
            Controls.Add(buttonClear);
            Controls.Add(labelFilterByGroups);
            Controls.Add(textBoxTitle);
            Controls.Add(labelFilterByTitle);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(checkedListBoxTags);
            Controls.Add(labelFilterByTag);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFilter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelFilterByTag;
        private CheckedListBox checkedListBoxTags;
        private Button buttonApply;
        private Button buttonCancel;
        private Label labelFilterByTitle;
        private TextBox textBoxTitle;
        private Button buttonClear;
        private Label labelFilterByGroups;
        private CheckedListBox checkedListBoxGroups;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
        private CheckBox checkBoxFrom;
        private CheckBox checkBoxTo;
        private Button buttonToday;
        private Button buttonYesterday;
        private Button buttonThisWeek;
        private Button buttonThisMonth;
        private Button buttonThisYear;
        private CheckBox checkBoxType;
        private RadioButton radioButtonPost;
        private RadioButton radioButtonComment;
    }
}