using System;
using System.Collections.Generic;
using System.IO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Represents a file reader.
    /// </summary>
    public class FileReader : IFileReader
    {
        private string _filePath;

        #region Public constructors

        /// <summary>
        /// Initializes an instance of the <see cref="FileReader"/>.
        /// </summary>
        public FileReader()
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="FileReader"/> with the passed file path.
        /// </summary>
        /// <param name="filePath">The reading file path.</param>
        public FileReader(string filePath)
        {
            FilePath = filePath;
        }

        #endregion !Public constructors.

        #region IFileReader implementation

        /// <summary>
        /// A reading file path.
        /// </summary>
        public string FilePath
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The file path must not be empty ot equal to null.", nameof(FilePath));
                }

                _filePath = value;
            }
        }

        /// <summary>
        /// Gets a next line from the file.
        /// </summary>
        /// <returns>The sequence of lines from the file.</returns>
        public IEnumerable<string> GetNextLine()
        {
            using (StreamReader fileStream = new StreamReader(_filePath))
            {
                while (!fileStream.EndOfStream)
                {
                    yield return fileStream.ReadLine();
                }
            }
        }

        #endregion !IFileReader implementation.
    }
}
