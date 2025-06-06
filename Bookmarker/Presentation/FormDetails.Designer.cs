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
            ((System.ComponentModel.ISupportInitialize)dataGridViewTagData).BeginInit();
            SuspendLayout();
            // 
            // labelUrl
            // 
            labelUrl.AutoSize = true;
            labelUrl.Location = new Point(12, 9);
            labelUrl.Name = "labelUrl";
            labelUrl.Size = new Size(28, 15);
            labelUrl.TabIndex = 0;
            labelUrl.Text = "URL";
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(46, 6);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(100, 23);
            textBoxUrl.TabIndex = 1;
            textBoxUrl.Leave += textBoxUrl_Leave;
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Location = new Point(15, 37);
            labelType.Name = "labelType";
            labelType.Size = new Size(32, 15);
            labelType.TabIndex = 2;
            labelType.Text = "Type";
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(20, 70);
            labelId.Name = "labelId";
            labelId.Size = new Size(18, 15);
            labelId.TabIndex = 3;
            labelId.Text = "ID";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 97);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(30, 15);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Title";
            // 
            // labelGroup
            // 
            labelGroup.AutoSize = true;
            labelGroup.Location = new Point(21, 138);
            labelGroup.Name = "labelGroup";
            labelGroup.Size = new Size(40, 15);
            labelGroup.TabIndex = 5;
            labelGroup.Text = "Group";
            // 
            // labelTags
            // 
            labelTags.AutoSize = true;
            labelTags.Location = new Point(26, 173);
            labelTags.Name = "labelTags";
            labelTags.Size = new Size(31, 15);
            labelTags.TabIndex = 6;
            labelTags.Text = "Tags";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(57, 68);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(100, 23);
            textBoxId.TabIndex = 7;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(93, 102);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(100, 23);
            textBoxTitle.TabIndex = 8;
            // 
            // textBoxGroup
            // 
            textBoxGroup.Location = new Point(90, 142);
            textBoxGroup.Name = "textBoxGroup";
            textBoxGroup.Size = new Size(100, 23);
            textBoxGroup.TabIndex = 9;
            // 
            // textBoxTags
            // 
            textBoxTags.Location = new Point(108, 175);
            textBoxTags.Name = "textBoxTags";
            textBoxTags.Size = new Size(100, 23);
            textBoxTags.TabIndex = 10;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(48, 283);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(155, 289);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
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
            labelTagDataOrder.Location = new Point(661, 19);
            labelTagDataOrder.Name = "labelTagDataOrder";
            labelTagDataOrder.Size = new Size(56, 15);
            labelTagDataOrder.TabIndex = 14;
            labelTagDataOrder.Text = "Order By:";
            // 
            // radioButtonOrderByName
            // 
            radioButtonOrderByName.AutoSize = true;
            radioButtonOrderByName.Checked = true;
            radioButtonOrderByName.Location = new Point(657, 49);
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
            radioButtonOrderByCount.Location = new Point(658, 81);
            radioButtonOrderByCount.Name = "radioButtonOrderByCount";
            radioButtonOrderByCount.Size = new Size(58, 19);
            radioButtonOrderByCount.TabIndex = 16;
            radioButtonOrderByCount.Text = "Count";
            radioButtonOrderByCount.UseVisualStyleBackColor = true;
            radioButtonOrderByCount.CheckedChanged += radioButtonOrderByCount_CheckedChanged;
            // 
            // FormDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButtonOrderByCount);
            Controls.Add(radioButtonOrderByName);
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
    }
}