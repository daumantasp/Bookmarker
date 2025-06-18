namespace Bookmarker
{
    partial class FormList
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLoad = new Button();
            dataGridView1 = new DataGridView();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            buttonOpenBrowser = new Button();
            textBoxFileDir = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonOpenFile = new Button();
            buttonOpenDir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(120, 23);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += Form1_Load;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1155, 745);
            dataGridView1.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(14, 799);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(45, 15);
            labelSearch.TabIndex = 2;
            labelSearch.Text = "Search:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSearch.Location = new Point(65, 796);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(1102, 23);
            textBoxSearch.TabIndex = 3;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonOpenBrowser
            // 
            buttonOpenBrowser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonOpenBrowser.Location = new Point(12, 826);
            buttonOpenBrowser.Name = "buttonOpenBrowser";
            buttonOpenBrowser.Size = new Size(129, 23);
            buttonOpenBrowser.TabIndex = 4;
            buttonOpenBrowser.Text = "Open in Browser";
            buttonOpenBrowser.UseVisualStyleBackColor = true;
            buttonOpenBrowser.Click += buttonOpenBrowser_Click;
            // 
            // textBoxFileDir
            // 
            textBoxFileDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFileDir.Enabled = false;
            textBoxFileDir.Location = new Point(138, 13);
            textBoxFileDir.Name = "textBoxFileDir";
            textBoxFileDir.Size = new Size(836, 23);
            textBoxFileDir.TabIndex = 5;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdd.Location = new Point(147, 826);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonEdit.Location = new Point(228, 826);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 7;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDelete.Location = new Point(309, 826);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpenFile.Location = new Point(980, 12);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(75, 23);
            buttonOpenFile.TabIndex = 9;
            buttonOpenFile.Text = "Open File";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpen_Click;
            // 
            // buttonOpenDir
            // 
            buttonOpenDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOpenDir.Location = new Point(1061, 13);
            buttonOpenDir.Name = "buttonOpenDir";
            buttonOpenDir.Size = new Size(106, 23);
            buttonOpenDir.TabIndex = 10;
            buttonOpenDir.Text = "Open Directory";
            buttonOpenDir.UseVisualStyleBackColor = true;
            buttonOpenDir.Click += buttonOpenDir_Click;
            // 
            // FormList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 861);
            Controls.Add(buttonOpenDir);
            Controls.Add(buttonOpenFile);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxFileDir);
            Controls.Add(buttonOpenBrowser);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearch);
            Controls.Add(dataGridView1);
            Controls.Add(buttonLoad);
            Name = "FormList";
            Text = "Bookmarker";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLoad;
        private DataGridView dataGridView1;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private Button buttonOpenBrowser;
        private TextBox textBoxFileDir;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonOpenFile;
        private Button buttonOpenDir;
    }
}
