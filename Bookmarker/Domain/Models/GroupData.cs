namespace Bookmarker.Domain.Models
{
    public class GroupData(string name, int count)
    {
        public string Name { get; } = name;
        public int Count { get; } = count;
    }
}
