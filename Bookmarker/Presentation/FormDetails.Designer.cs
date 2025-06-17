namespace Bookmarker.Presentation
{
    partial class FormDetails
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
            labelUrl = new Label();
            textBoxUrl = new TextBox();
            labelType = new Label();
            labelId = new Label();
            labelTitle = new Label();
            labelGroup = new Label();
            labelTags = new Label();
            textBoxId = new TextBox();
            textBoxTitle = new TextBox();
            textBoxGroup = new TextBox();
            textBoxTags = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            dataGridViewTagData = new DataGridView();
            radioButtonPost = new RadioButton();
            radioButtonComment = new RadioButton();
            panel1 = new Panel();
            labelSearch = new Label();
            textBoxSearchTags = new TextBox();
            buttonParseUrl = new Button();
            buttonPaste = new Button();
            label1 = new Label();
            textBoxCreated = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTagData).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // labelUrl
            // 
            labelUrl.AutoSize = true;
            labelUrl.Location = new Point(12, 18);
            labelUrl.Name = "labelUrl";
            labelUrl.Size = new Size(31, 15);
            labelUrl.TabIndex = 0;
            labelUrl.Text = "URL:";
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(65, 15);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(293, 23);
            textBoxUrl.TabIndex = 1;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(12, 85);
            labelType.Name = "labelType";
            labelType.Size = new Size(35, 15);
            labelType.TabIndex = 2;
            labelType.Text = "Type:";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(12, 130);
            labelId.Name = "labelId";
            labelId.Size = new Size(21, 15);
            labelId.TabIndex = 3;
            labelId.Text = "ID:";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(12, 175);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(33, 15);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Title:";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(12, 220);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(43, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Group:";
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Location = new Point(12, 265);
            labelTags.Name = "labelTags";
            labelTags.Size = new Size(34, 15);
            labelTags.TabIndex = 6;
            labelTags.Text = "Tags:";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(65, 127);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(293, 23);
            textBoxId.TabIndex = 7;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(65, 172);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(293, 23);
            textBoxTitle.TabIndex = 8;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(65, 217);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(293, 23);
            textBoxGroup.TabIndex = 9;
            // 
            // textBoxTags
            // 
            textBoxTags.Location = new Point(65, 262);
            textBoxTags.Multiline = true;
            textBoxTags.Name = "textBoxTags";
            textBoxTags.ScrollBars = ScrollBars.Vertical;
            textBoxTags.Size = new Size(293, 73);
            textBoxTags.TabIndex = 10;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 406);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(93, 406);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // dataGridViewTagData
            // 
            dataGridViewTagData.AllowUserToDeleteRows = false;
            dataGridViewTagData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTagData.Location = new Point(382, 15);
            dataGridViewTagData.Name = "dataGridViewTagData";
            dataGridViewTagData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTagData.Size = new Size(240, 368);
            dataGridViewTagData.TabIndex = 13;
            dataGridViewTagData.CellMouseDoubleClick += dataGridViewTagData_CellMouseDoubleClick;
            dataGridViewTagData.ColumnHeaderMouseClick += dataGridViewTagData_ColumnHeaderMouseClick;
            // 
            // radioButtonPost
            // 
            radioButtonPost.AutoSize = true;
            radioButtonPost.Checked = true;
            radioButtonPost.Location = new Point(3, 6);
            radioButtonPost.Name = "radioButtonPost";
            radioButtonPost.Size = new Size(48, 19);
            radioButtonPost.TabIndex = 17;
            radioButtonPost.TabStop = true;
            radioButtonPost.Text = "Post";
            radioButtonPost.UseVisualStyleBackColor = true;
            // 
            // radioButtonComment
            // 
            radioButtonComment.AutoSize = true;
            radioButtonComment.Location = new Point(79, 6);
            radioButtonComment.Name = "radioButtonComment";
            radioButtonComment.Size = new Size(79, 19);
            radioButtonComment.TabIndex = 18;
            radioButtonComment.Text = "Comment";
            radioButtonComment.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonPost);
            panel1.Controls.Add(radioButtonComment);
            panel1.Location = new Point(65, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 44);
            panel1.TabIndex = 19;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(382, 393);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(90, 15);
            labelSearch.TabIndex = 21;
            labelSearch.Text = "Search for Tags:";
            // 
            // textBoxSearchTags
            // 
            textBoxSearchTags.Location = new Point(478, 390);
            textBoxSearchTags.Name = "textBoxSearchTags";
            textBoxSearchTags.Size = new Size(144, 23);
            textBoxSearchTags.TabIndex = 22;
            textBoxSearchTags.TextChanged += textBoxSearchTags_TextChanged;
            // 
            // buttonParseUrl
            // 
            buttonParseUrl.Location = new Point(148, 44);
            buttonParseUrl.Name = "buttonParseUrl";
            buttonParseUrl.Size = new Size(75, 23);
            buttonParseUrl.TabIndex = 23;
            buttonParseUrl.Text = "Parse URL";
            buttonParseUrl.UseVisualStyleBackColor = true;
            buttonParseUrl.Click += buttonParseUrl_Click;
            // 
            // buttonPaste
            // 
            buttonPaste.Location = new Point(65, 44);
            buttonPaste.Name = "buttonPaste";
            buttonPaste.Size = new Size(75, 23);
            buttonPaste.TabIndex = 24;
            buttonPaste.Text = "Paste";
            buttonPaste.UseVisualStyleBackColor = true;
            buttonPaste.Click += buttonPaste_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 363);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 25;
            label1.Text = "Created:";
            // 
            // textBoxCreated
            // 
            textBoxCreated.Location = new Point(65, 360);
            textBoxCreated.Name = "textBoxCreated";
            textBoxCreated.Size = new Size(293, 23);
            textBoxCreated.TabIndex = 26;
            // 
            // FormDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 441);
            Controls.Add(textBoxCreated);
            Controls.Add(label1);
            Controls.Add(buttonPaste);
            Controls.Add(buttonParseUrl);
            Controls.Add(textBoxSearchTags);
            Controls.Add(labelSearch);
            Controls.Add(panel1);
            Controls.Add(dataGridViewTagData);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxTags);
            Controls.Add(textBoxGroup);
            Controls.Add(textBoxTitle);
            Controls.Add(textBoxId);
            Controls.Add(labelTags);
            Controls.Add(labelGroup);
            Controls.Add(labelTitle);
            Controls.Add(labelId);
            Controls.Add(labelType);
            Controls.Add(textBoxUrl);
            Controls.Add(labelUrl);
            Name = "FormDetails";
            Text = "FormDetails";
            Load += FormDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTagData).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUrl;
        private TextBox textBoxUrl;
        private Label labelType;
        private Label labelId;
        private Label labelTitle;
        private Label labelGroup;
        private Label labelTags;
        private TextBox textBoxId;
        private TextBox textBoxTitle;
        private TextBox textBoxGroup;
        private TextBox textBoxTags;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridView dataGridViewTagData;
        private RadioButton radioButtonPost;
        private RadioButton radioButtonComment;
        private Panel panel1;
        private Label labelSearch;
        private TextBox textBoxSearchTags;
        private Button buttonParseUrl;
        private Button buttonPaste;
        private Button buttonEditTags;
        private Label label1;
        private TextBox textBoxCreated;
    }
}