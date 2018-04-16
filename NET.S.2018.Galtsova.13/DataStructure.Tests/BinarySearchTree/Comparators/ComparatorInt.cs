using System.Collections.Generic;

namespace DataStructure.Tests
{
    public class ComparatorInt : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}
