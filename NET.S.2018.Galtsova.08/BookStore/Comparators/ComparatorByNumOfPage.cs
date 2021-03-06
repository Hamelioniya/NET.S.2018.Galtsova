﻿using System;
using System.Collections.Generic;

namespace BookStore
{
    /// <summary>
    /// Represents a comparator of two books by the number of pages.
    /// </summary>
    public class ComparatorByNumOfPage : IComparer<Book>
    {
        /// <summary>
        /// Compares the <paramref name="firstBook"/> and the <paramref name="secondBook"/> by the number of pages.
        /// </summary>
        /// <param name="firstBook">A first book.</param>
        /// <param name="secondBook">A second book.</param>
        /// <returns>Greater than 0, if the current book is larger, 0 if equal, -1 if less.</returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            if (ReferenceEquals(firstBook, null))
            {
                throw new ArgumentNullException(nameof(firstBook));
            }

            if (ReferenceEquals(secondBook, null))
            {
                throw new ArgumentNullException(nameof(secondBook));
            }

            return firstBook.NumOfPages.CompareTo(secondBook.NumOfPages);
        }
    }
}
