using System.Collections.Generic;

namespace DataStructure.Tests
{
    public class ComparatorString : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }
}
