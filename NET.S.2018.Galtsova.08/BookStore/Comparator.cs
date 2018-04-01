namespace BookStore
{
    /// <summary>
    /// Represents comparators for <see cref="Book"/>.
    /// </summary>
    public static class Comparator
    {
        public static int CompareByISBN(Book firstBook, Book secondBook)
        {
            return firstBook.ISBN.CompareTo(secondBook.ISBN);
        }

        public static int CompareByAuthor(Book firstBook, Book secondBook)
        {
            return firstBook.Author.CompareTo(secondBook.Author);
        }

        public static int CompareByName(Book firstBook, Book secondBook)
        {
            return firstBook.Name.CompareTo(secondBook.Name);
        }

        public static int CompareByPublishingHouse(Book firstBook, Book secondBook)
        {
            return firstBook.PublishingHouse.CompareTo(secondBook.PublishingHouse);
        }

        public static int CompareByPublishingYear(Book firstBook, Book secondBook)
        {
            return firstBook.PublishingYear.CompareTo(secondBook.PublishingYear);
        }

        public static int CompareByNumOfPages(Book firstBook, Book secondBook)
        {
            return firstBook.NumOfPages.CompareTo(secondBook.NumOfPages);
        }

        public static int CompareByPrice(Book firstBook, Book secondBook)
        {
            return firstBook.Price.CompareTo(secondBook.Price);
        }
    }
}
