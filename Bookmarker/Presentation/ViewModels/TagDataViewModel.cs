using Bookmarker.Domain.Models;

namespace Bookmarker.Presentation.ViewModels
{
    internal class TagDataViewModel(string name, int count)
    {
        public string Name { get; } = name;
        public int Count { get; } = count;

        public TagDataViewModel(TagData tagData) : this("#" + tagData.Name, tagData.Count)
        { }
    }
}
