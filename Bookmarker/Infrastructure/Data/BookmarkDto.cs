namespace Bookmarker.Infrastructure.Data
{
    public class BookmarkDto()
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string Url { get; set; }
        public string[] Tags { get; set; }
        public string Created { get; set; }
    }
}