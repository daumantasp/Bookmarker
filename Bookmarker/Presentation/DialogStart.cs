using Bookmarker.Infrastructure.SourceSelector;

namespace Bookmarker.Presentation
{
    public partial class DialogStart : Form
    {
        public string? SourcePath { get; private set; }

        public DialogStart()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            SourcePath = SourceSelector.ShowCreateFileDialog();
            if (SourcePath != null)
            {
                File.WriteAllText(SourcePath, "[]");
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            SourcePath = SourceSelector.ShowFileDialog();
            DialogResult = SourcePath != null ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }
    }
}
