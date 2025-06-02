using Bookmarker.Application.Services;

namespace Bookmarker
{
    public partial class Form1 : Form
    {
        private readonly IBookmarkService _bookmarkService;

        public Form1(IBookmarkService bookmarkService)
        {
            InitializeComponent();

            _bookmarkService = bookmarkService;
        }
    }
}
