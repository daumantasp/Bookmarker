using Bookmarker.Infrastructure.SourceSelector;
using System.Windows.Forms;

namespace Bookmarker.Presentation
{
    public partial class DialogStart : Form
    {
        public string? SourcePath { get; private set; }

        public DialogStart()
        {
            InitializeComponent();
            SetFormStyle();
        }

        private void SetFormStyle()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
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
