using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Provides a file reader interface.
    /// </summary>
    public interface IFileReader
    {
        /// <summary>
        /// A reading file path.
        /// </summary>
        string FilePath { set; }

        /// <summary>
        /// Gets a next line from the file.
        /// </summary>
        /// <returns>The sequence of lines from the reading file.</returns>
        IEnumerable<string> GetNextLine();
    }
}
