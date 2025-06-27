namespace Bookmarker.Infrastructure.SourceSelector
{
    internal class SourceSelector
    {
        public static readonly string DefaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bookmarks.json");

        public static bool IsDefaultFileDirExists()
        {
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultPath);
            return File.Exists(fullPath);
        }

        public static string? ShowFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return openFileDialog.FileName;
                else
                    return null;
            }
        }
    }
}