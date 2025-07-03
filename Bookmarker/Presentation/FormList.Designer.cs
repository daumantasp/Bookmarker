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
            dataGridView1 = new DataGridView();
            labelSearch = new Label();
            textBoxSearch = new TextBox();
            buttonOpenBrowser = new Button();
            textBoxFileDir = new TextBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            browseToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openDirectoryToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(12, 56);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1155, 730);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
            dataGridView1.UserDeletingRow += dataGridView1_UserDeletingRow;
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
            textBoxFileDir.Location = new Point(14, 27);
            textBoxFileDir.Name = "textBoxFileDir";
            textBoxFileDir.Size = new Size(1153, 23);
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
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, browseToolStripMenuItem, openToolStripMenuItem, openDirectoryToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // browseToolStripMenuItem
            // 
            browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            browseToolStripMenuItem.Size = new Size(180, 22);
            browseToolStripMenuItem.Text = "Browse";
            browseToolStripMenuItem.Click += browseToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openDirectoryToolStripMenuItem
            // 
            openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            openDirectoryToolStripMenuItem.Size = new Size(180, 22);
            openDirectoryToolStripMenuItem.Text = "Open Directory";
            openDirectoryToolStripMenuItem.Click += openDirectoryToolStripMenuItem_Click;
            // 
            // FormList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 861);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxFileDir);
            Controls.Add(buttonOpenBrowser);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearch);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormList";
            Text = "Bookmarker";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Label labelSearch;
        private TextBox textBoxSearch;
        private Button buttonOpenBrowser;
        private TextBox textBoxFileDir;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem browseToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openDirectoryToolStripMenuItem;
    }
}
