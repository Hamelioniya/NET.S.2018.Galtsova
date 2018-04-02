using System;
using System.Collections.Generic;
using System.IO;

namespace BookStore
{
    /// <summary>
    /// Represents a book list storage.
    /// </summary>
    public class BookListStorage : IBookListStorage
    {
        #region Private fields

        private const string StorageFilePath = "books.txt";

        #endregion !Private fields.

        #region Public methods

        /// <summary>
        /// Gets a list of books.
        /// </summary>
        /// <returns>A list of books.</returns>
        public List<Book> GetListOfBooks() => GetListOfBooks(StorageFilePath);

        /// <summary>
        /// Saves a list <paramref name="books"/>.
        /// </summary>
        /// <param name="books">A list of books.</param>
        public void SaveListOfBooks(List<Book> books) => SaveListOfBooks(StorageFilePath, books);

        #endregion !Public methods.

        #region IBookListStorage methods implementation

        /// <summary>
        /// Gets a list of books by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>A list of books.</returns>
        public List<Book> GetListOfBooks(string filePath)
        {
            if (filePath == string.Empty)
            {
                throw new ArgumentException("Incorrect file path.", nameof(filePath));
            }

            if (ReferenceEquals(filePath, null))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            return ReadBinaryFile(filePath);
        }

        /// <summary>
        /// Saves a list <paramref name="books"/> by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="books">A list of books.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="filePath"/> equal to empty string.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="filePath"/> or/and <paramref name="books"/> equal to null.
        /// </exception>
        public void SaveListOfBooks(string filePath, List<Book> books)
        {
            if (filePath == string.Empty)
            {
                throw new ArgumentException("Incorrect file path.", nameof(filePath));
            }

            if (ReferenceEquals(filePath, null))
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (ReferenceEquals(books, null))
            {
                throw new ArgumentNullException(nameof(books));
            }

            WriteBinaryFile(filePath, books);
        }

        #endregion !IBookListStorage methods implementation.

        #region Private methods

        /// <summary>
        /// Reads a list of books from binary file by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A binary file path.</param>
        /// <returns>A list of books.</returns>
        private static List<Book> ReadBinaryFile(string filePath)
        {
            List<Book> resultList = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    Book book = new Book(reader.ReadInt32())
                    {
                        Author = reader.ReadString(),
                        Name = reader.ReadString(),
                        PublishingHouse = reader.ReadString(),
                        PublishingYear = reader.ReadInt16(),
                        NumOfPages = reader.ReadInt32(),
                        Price = reader.ReadDecimal()
                    };

                    resultList.Add(book);
                }
            }

            return resultList;
        }

        /// <summary>
        /// Writes a list <paramref name="books"/> to the binary file by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A binary file path.</param>
        /// <param name="books">A list of books.</param>
        private static void WriteBinaryFile(string filePath, List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.ISBN);
                    writer.Write(book.Author);
                    writer.Write(book.Name);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.NumOfPages);
                    writer.Write(book.Price);
                }
            }
        }

        #endregion !Private methods.
    }
}
