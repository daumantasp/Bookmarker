namespace Bookmarker
{
    partial class Form1
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 397);
            dataGridView1.TabIndex = 1;
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(14, 451);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(45, 15);
            labelSearch.TabIndex = 2;
            labelSearch.Text = "Search:";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(65, 448);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(723, 23);
            textBoxSearch.TabIndex = 3;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            // 
            // buttonOpenBrowser
            // 
            buttonOpenBrowser.Location = new Point(12, 477);
            buttonOpenBrowser.Name = "buttonOpenBrowser";
            buttonOpenBrowser.Size = new Size(129, 23);
            buttonOpenBrowser.TabIndex = 4;
            buttonOpenBrowser.Text = "Open in Browser";
            buttonOpenBrowser.UseVisualStyleBackColor = true;
            buttonOpenBrowser.Click += buttonOpenBrowser_Click;
            // 
            // textBoxFileDir
            // 
            textBoxFileDir.Location = new Point(138, 13);
            textBoxFileDir.Name = "textBoxFileDir";
            textBoxFileDir.Size = new Size(650, 23);
            textBoxFileDir.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 592);
            Controls.Add(textBoxFileDir);
            Controls.Add(buttonOpenBrowser);
            Controls.Add(textBoxSearch);
            Controls.Add(labelSearch);
            Controls.Add(dataGridView1);
            Controls.Add(buttonLoad);
            Name = "Form1";
            Text = "Form1";
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
    }
}
