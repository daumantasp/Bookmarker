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
            labelFilterByGroup = new Label();
            textBoxGroup = new TextBox();
            buttonClear = new Button();
            labelFilterStatus = new Label();
            SuspendLayout();
            // 
            // labelFilterByTag
            // 
            labelFilterByTag.AutoSize = true;
            labelFilterByTag.Location = new Point(12, 9);
            labelFilterByTag.Name = "labelFilterByTag";
            labelFilterByTag.Size = new Size(71, 15);
            labelFilterByTag.TabIndex = 0;
            labelFilterByTag.Text = "Filter by Tag";
            // 
            // checkedListBoxTags
            // 
            checkedListBoxTags.CheckOnClick = true;
            checkedListBoxTags.FormattingEnabled = true;
            checkedListBoxTags.Location = new Point(89, 9);
            checkedListBoxTags.Name = "checkedListBoxTags";
            checkedListBoxTags.Size = new Size(166, 220);
            checkedListBoxTags.TabIndex = 1;
            checkedListBoxTags.ItemCheck += checkedListBoxTags_ItemCheck;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(12, 415);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(75, 23);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(93, 415);
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
            labelFilterByTitle.Location = new Point(261, 9);
            labelFilterByTitle.Name = "labelFilterByTitle";
            labelFilterByTitle.Size = new Size(75, 15);
            labelFilterByTitle.TabIndex = 4;
            labelFilterByTitle.Text = "Filter by Title";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(261, 27);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(266, 23);
            textBoxTitle.TabIndex = 5;
            textBoxTitle.TextChanged += textBoxTitle_TextChanged;
            // 
            // labelFilterByGroup
            // 
            labelFilterByGroup.AutoSize = true;
            labelFilterByGroup.Location = new Point(261, 62);
            labelFilterByGroup.Name = "labelFilterByGroup";
            labelFilterByGroup.Size = new Size(40, 15);
            labelFilterByGroup.TabIndex = 6;
            labelFilterByGroup.Text = "Group";
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(261, 80);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(266, 23);
            textBoxGroup.TabIndex = 7;
            textBoxGroup.TextChanged += textBoxGroup_TextChanged;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(261, 206);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 8;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelFilterStatus
            // 
            labelFilterStatus.AutoSize = true;
            labelFilterStatus.Location = new Point(89, 244);
            labelFilterStatus.Name = "labelFilterStatus";
            labelFilterStatus.Size = new Size(0, 15);
            labelFilterStatus.TabIndex = 9;
            // 
            // FormFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelFilterStatus);
            Controls.Add(buttonClear);
            Controls.Add(textBoxGroup);
            Controls.Add(labelFilterByGroup);
            Controls.Add(textBoxTitle);
            Controls.Add(labelFilterByTitle);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
            Controls.Add(checkedListBoxTags);
            Controls.Add(labelFilterByTag);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFilter";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormFilter";
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
        private Label labelFilterByGroup;
        private TextBox textBoxGroup;
        private Button buttonClear;
        private Label labelFilterStatus;
    }
}