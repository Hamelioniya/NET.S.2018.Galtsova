using System.Collections.Generic;

namespace DataStructure.Tests
{
    public class ComparatorBook : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.CompareTo(y);
        }
    }
}
