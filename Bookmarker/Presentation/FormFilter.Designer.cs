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
            SuspendLayout();
            // 
            // labelFilterByTag
            // 
            labelFilterByTag.AutoSize = true;
            labelFilterByTag.Location = new Point(14, 71);
            labelFilterByTag.Name = "labelFilterByTag";
            labelFilterByTag.Size = new Size(34, 15);
            labelFilterByTag.TabIndex = 0;
            labelFilterByTag.Text = "Tags:";
            // 
            // checkedListBoxTags
            // 
            checkedListBoxTags.CheckOnClick = true;
            checkedListBoxTags.FormattingEnabled = true;
            checkedListBoxTags.Location = new Point(14, 89);
            checkedListBoxTags.Name = "checkedListBoxTags";
            checkedListBoxTags.Size = new Size(166, 220);
            checkedListBoxTags.TabIndex = 1;
            checkedListBoxTags.ItemCheck += checkedListBoxTags_ItemCheck;
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(15, 339);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(75, 23);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(290, 339);
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
            buttonClear.Location = new Point(96, 339);
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
            labelFilterByGroups.Location = new Point(204, 71);
            labelFilterByGroups.Name = "labelFilterByGroups";
            labelFilterByGroups.Size = new Size(48, 15);
            labelFilterByGroups.TabIndex = 6;
            labelFilterByGroups.Text = "Groups:";
            // 
            // checkedListBoxGroups
            // 
            checkedListBoxGroups.FormattingEnabled = true;
            checkedListBoxGroups.Location = new Point(204, 89);
            checkedListBoxGroups.Name = "checkedListBoxGroups";
            checkedListBoxGroups.Size = new Size(161, 220);
            checkedListBoxGroups.TabIndex = 9;
            checkedListBoxGroups.ItemCheck += checkedListBoxGroups_ItemCheck;
            // 
            // FormFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 374);
            Controls.Add(checkedListBoxGroups);
            Controls.Add(buttonClear);
            Controls.Add(labelFilterByGroups);
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
    }
}