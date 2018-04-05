using System.Collections.Generic;

namespace BookStore
{
    /// <summary>
    /// Represents an interface for book list storage.
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Gets a list of books by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>A list of books.</returns>
        List<Book> GetListOfBooks(string filePath);

        /// <summary>
        /// Saves a list <paramref name="books"/> by the path <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="books"> A list of books.</param>
        void SaveListOfBooks(string filePath, List<Book> books);
    }
}
