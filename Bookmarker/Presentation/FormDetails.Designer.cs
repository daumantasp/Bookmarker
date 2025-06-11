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
            labelTagDataOrder = new Label();
            radioButtonOrderByName = new RadioButton();
            radioButtonOrderByCount = new RadioButton();
            radioButtonPost = new RadioButton();
            radioButtonComment = new RadioButton();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTagData).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            textBoxUrl.Leave += textBoxUrl_Leave;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(12, 63);
            labelType.Name = "labelType";
            labelType.Size = new Size(35, 15);
            labelType.TabIndex = 2;
            labelType.Text = "Type:";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(12, 108);
            labelId.Name = "labelId";
            labelId.Size = new Size(21, 15);
            labelId.TabIndex = 3;
            labelId.Text = "ID:";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(12, 153);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(33, 15);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Title:";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(12, 198);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(43, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Group:";
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Location = new Point(12, 243);
            labelTags.Name = "labelTags";
            labelTags.Size = new Size(34, 15);
            labelTags.TabIndex = 6;
            labelTags.Text = "Tags:";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(65, 105);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(293, 23);
            textBoxId.TabIndex = 7;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(65, 150);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(293, 23);
            textBoxTitle.TabIndex = 8;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(65, 195);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(293, 23);
            textBoxGroup.TabIndex = 9;
            // 
            // textBoxTags
            // 
            textBoxTags.Location = new Point(65, 240);
            textBoxTags.Name = "textBoxTags";
            textBoxTags.Size = new Size(293, 23);
            textBoxTags.TabIndex = 10;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 390);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(105, 390);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // dataGridViewTagData
            // 
            dataGridViewTagData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTagData.Location = new Point(382, 15);
            dataGridViewTagData.Name = "dataGridViewTagData";
            dataGridViewTagData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTagData.Size = new Size(240, 368);
            dataGridViewTagData.TabIndex = 13;
            // 
            // labelTagDataOrder
            // 
            labelTagDataOrder.AutoSize = true;
            labelTagDataOrder.Location = new Point(382, 394);
            labelTagDataOrder.Name = "labelTagDataOrder";
            labelTagDataOrder.Size = new Size(56, 15);
            labelTagDataOrder.TabIndex = 14;
            labelTagDataOrder.Text = "Order By:";
            // 
            // radioButtonOrderByName
            // 
            radioButtonOrderByName.AutoSize = true;
            radioButtonOrderByName.Checked = true;
            radioButtonOrderByName.Location = new Point(3, 3);
            radioButtonOrderByName.Name = "radioButtonOrderByName";
            radioButtonOrderByName.Size = new Size(57, 19);
            radioButtonOrderByName.TabIndex = 15;
            radioButtonOrderByName.TabStop = true;
            radioButtonOrderByName.Text = "Name";
            radioButtonOrderByName.UseVisualStyleBackColor = true;
            radioButtonOrderByName.CheckedChanged += radioButtonOrderByName_CheckedChanged;
            // 
            // radioButtonOrderByCount
            // 
            radioButtonOrderByCount.AutoSize = true;
            radioButtonOrderByCount.Location = new Point(106, 3);
            radioButtonOrderByCount.Name = "radioButtonOrderByCount";
            radioButtonOrderByCount.Size = new Size(58, 19);
            radioButtonOrderByCount.TabIndex = 16;
            radioButtonOrderByCount.Text = "Count";
            radioButtonOrderByCount.UseVisualStyleBackColor = true;
            radioButtonOrderByCount.CheckedChanged += radioButtonOrderByCount_CheckedChanged;
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
            panel1.Location = new Point(65, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(293, 44);
            panel1.TabIndex = 19;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioButtonOrderByName);
            panel2.Controls.Add(radioButtonOrderByCount);
            panel2.Location = new Point(444, 388);
            panel2.Name = "panel2";
            panel2.Size = new Size(187, 25);
            panel2.TabIndex = 20;
            // 
            // FormDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 426);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelTagDataOrder);
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label labelTagDataOrder;
        private RadioButton radioButtonOrderByName;
        private RadioButton radioButtonOrderByCount;
        private RadioButton radioButtonPost;
        private RadioButton radioButtonComment;
        private Panel panel1;
        private Panel panel2;
    }
}