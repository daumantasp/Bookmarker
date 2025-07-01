namespace Bookmarker.Presentation
{
    partial class DialogStart
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
            labelBookmarkNotFound = new Label();
            labelAsk = new Label();
            buttonCreate = new Button();
            buttonBrowse = new Button();
            SuspendLayout();
            // 
            // labelBookmarkNotFound
            // 
            labelBookmarkNotFound.AutoSize = true;
            labelBookmarkNotFound.Location = new Point(12, 9);
            labelBookmarkNotFound.Name = "labelBookmarkNotFound";
            labelBookmarkNotFound.Size = new Size(254, 15);
            labelBookmarkNotFound.TabIndex = 0;
            labelBookmarkNotFound.Text = "The bookmarks source file could not be found.";
            // 
            // labelAsk
            // 
            labelAsk.AutoSize = true;
            labelAsk.Location = new Point(12, 35);
            labelAsk.Name = "labelAsk";
            labelAsk.Size = new Size(348, 15);
            labelAsk.TabIndex = 1;
            labelAsk.Text = "Would you like to create a new one or browse for an existing file?";
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(78, 65);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "Create New";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Location = new Point(159, 65);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(75, 23);
            buttonBrowse.TabIndex = 3;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // DialogStart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 100);
            Controls.Add(buttonBrowse);
            Controls.Add(buttonCreate);
            Controls.Add(labelAsk);
            Controls.Add(labelBookmarkNotFound);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DialogStart";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bookmarks File Not Found";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelBookmarkNotFound;
        private Label labelAsk;
        private Button buttonCreate;
        private Button buttonBrowse;
    }
}