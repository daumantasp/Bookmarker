using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarker.Domain.Models
{
    public class TagData(string name, int count)
    {
        public string Name { get; } = name;
        public int Count { get; } = count;
    }
}
