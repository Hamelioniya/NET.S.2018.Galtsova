using System;
using System.Globalization;

namespace BookStore
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        #region Public constructors

        /// <summary>
        /// Initializes an instance of the book with the passed ISBN.
        /// </summary>
        /// <param name="isbn">An ISBN.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="isbn"/> less than 0.
        /// </exception>
        public Book(int isbn)
        {
            if (isbn < 0)
            {
                throw new ArgumentOutOfRangeException("ISBN must be greater than 0.", nameof(isbn));
            }

            ISBN = isbn;
            Author = string.Empty;
            Name = string.Empty;
            PublishingHouse = string.Empty;
        }

        /// <summary>
        /// Initializes an instance of the book with passed ISBN, book author and book name.
        /// </summary>
        /// <param name="isbn">An ISBN.</param>book ISBN
        /// <param name="author">A book author.</param>
        /// <param name="name">A book name.</param>
        public Book(int isbn, string author, string name) : this(isbn)
        {
            Author = author;
            Name = name;
        }

        /// <summary>
        /// Initializes an instance of the book with passed ISBN, book author, book name and book price.
        /// </summary>
        /// <param name="isbn">An ISBN.</param>
        /// <param name="author">A book author.</param>
        /// <param name="name">A book name.</param>
        /// <param name="price">A book price.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="price"/> less than 0.
        /// </exception>
        public Book(int isbn, string author, string name, decimal price) : this(isbn, author, name)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException("Price must be greater than 0.", nameof(price));
            }

            Price = price;
        }

        /// <summary>
        /// Initializes an instance of the book with the passed parameters.
        /// </summary>
        /// <param name="isbn">An ISBN.</param>
        /// <param name="author">A book author.</param>
        /// <param name="name">A book name.</param>
        /// <param name="publishingHouse">A book publishing house</param>
        /// <param name="publishingYear">A book publishing year.</param>
        /// <param name="numOfPages">A number of book's pages.</param>
        /// <param name="price">A book price.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="numOfPages"/> less than or equal to 0.
        /// </exception>
        public Book(int isbn, string author, string name, string publishingHouse, short publishingYear, int numOfPages, decimal price)
                                       : this(isbn, author, name, price)
        {
            if (numOfPages <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of pages must be greater than 0.", nameof(numOfPages));
            }

            PublishingHouse = publishingHouse;
            PublishingYear = publishingYear;
            NumOfPages = numOfPages;
        }

        #endregion !Public constructors.

        #region Public properties

        /// <summary>
        /// International Standard Book Number.
        /// </summary>
        public int ISBN { get; private set; }

        /// <summary>
        /// Book author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Book name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Publishing house.
        /// </summary>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// Publishing year.
        /// </summary>
        public short PublishingYear { get; set; }

        /// <summary>
        /// Number of book's pages
        /// </summary>
        public int NumOfPages { get; set; }

        /// <summary>
        /// Book price.
        /// </summary>
        public decimal Price { get; set; }

        #endregion !Public properties.

        #region Equals public methods

        /// <summary>
        /// Checks equality of the <paramref name="firstBook"/> and the <paramref name="secondBook"/>.
        /// </summary>
        /// <param name="firstBook">A first book.</param>
        /// <param name="secondBook">A second book.</param>
        /// <returns>true if books are equal.</returns>
        public static bool operator ==(Book firstBook, Book secondBook)
        {
            return firstBook.Equals(secondBook);
        }

        /// <summary>
        /// Checks inequality of the <paramref name="firstBook"/> and the <paramref name="secondBook"/>.
        /// </summary>
        /// <param name="firstBook">A first book.</param>
        /// <param name="secondBook">A second book.</param>
        /// <returns>true if books are not equal.</returns>
        public static bool operator !=(Book firstBook, Book secondBook)
        {
            return !firstBook.Equals(secondBook);
        }

        /// <summary>
        /// Checks equality of the current book and the <paramref name="other"/> book.
        /// </summary>
        /// <param name="other">An other book.</param>
        /// <returns>true if books are equal.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return (this.ISBN == other.ISBN) &&
                   (this.Author == other.Author) &&
                   (this.Name == other.Name) &&
                   (this.PublishingHouse == other.PublishingHouse) &&
                   (this.PublishingYear == other.PublishingYear) &&
                   (this.NumOfPages == other.NumOfPages) &&
                   (this.Price == other.Price);
        }

        /// <summary>
        /// Checks equality of the current book and the <paramref name="other"/> book.
        /// </summary>
        /// <param name="other">An other book.</param>
        /// <returns>true if books are equal.</returns>
        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return this.Equals((Book)other);
        }

        #endregion !Equals public methods.

        #region ToString pubic method

        /// <summary>
        /// Returns a string representation of the <see cref="Book"/> object.
        /// </summary>
        /// <returns>A string representation of the <see cref="Book"/> object.</returns>
        public override string ToString()
        {
            if (ReferenceEquals(this, null))
            {
                throw new ArgumentNullException();
            }

            return "IBSN: " + ISBN.ToString() + "\nName: "+ Name + "\nAuthor: " + Author + "\nPublishing house: " + PublishingHouse +
                "\nPublishing year: " + PublishingYear.ToString() + "\nNumber of pages: " + NumOfPages.ToString() + "\nPrice: " + Price.ToString("C", CultureInfo.CurrentCulture);
        }

        #endregion !ToString pubic method.

        #region GetHashCode public method

        /// <summary>
        /// This method returns a hash code for the <see cref="Book"/> object.
        /// </summary>
        /// <returns>A hash code for the <see cref="Book"/> object.</returns>
        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        #endregion !GetHashCode public method.

        #region CompareTo public methods

        /// <summary>
        /// Compares the current book and the <paramref name="other"/> book by ISBN.
        /// </summary>
        /// <param name="other">An other book.</param>
        /// <returns>Greater than 0, if the current book is larger, 0 if equal, -1 if less.</returns>
        public int CompareTo(object other)
        {
            if (ReferenceEquals(other, null))
            {
                return -1;
            }

            if (this.GetType() != other.GetType())
            {
                throw new ArgumentException("Arqument is not a book", nameof(other));
            }

            return this.CompareTo((Book)other);
        }

        /// <summary>
        /// Compares the current book and the <paramref name="other"/> book by ISBN.
        /// </summary>
        /// <param name="other">An other book.</param>
        /// <returns>Greater than 0, if the current book is larger, 0 if equal, -1 if less.</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return -1;
            }

            return this.ISBN.CompareTo(other.ISBN);
        }

        #endregion !CompareTo public methods.
    }
}
