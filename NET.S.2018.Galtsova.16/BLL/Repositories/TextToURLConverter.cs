using System;
using System.Collections.Generic;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.Repositories
{
    /// <summary>
    /// Represents a uri-address converter from the text representation.
    /// </summary>
    public class TextToURLConverter : ITextToURLConverter
    {
        private ILogger _logger;

        public TextToURLConverter(ILogger logger)
        {
            Logger = logger;
        }

        private ILogger Logger
        {
            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(Logger));
                }

                _logger = value;
            }
        }

        #region ITextToUrlConverter implementation

        /// <summary>
        /// Gets a next uri-address converted from the text representation.
        /// </summary>
        /// <param name="fileReader">The file reader to get url-addresses in the text representation</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="fileReader"/> equal to null.
        /// </exception>
        /// <returns>The sequence of the uri-addresses converted from the text representation.</returns>
        public IEnumerable<Uri> GetUri(IFileReader fileReader)
        {
            if (ReferenceEquals(fileReader, null))
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            foreach (var line in fileReader.GetNextLine())
            {
                if (VerifyURLAddress(line))
                {
                    yield return new Uri(line);
                }
            }
        }

        #endregion !ITextToUrlConverter implementation.

        private bool VerifyURLAddress(string urlAddress)
        {
            if (string.IsNullOrEmpty(urlAddress))
            {
                throw new ArgumentException("The url address must not be empty and equal to null.", nameof(urlAddress));
            }

            if (urlAddress.Split(new[] { "://" }, StringSplitOptions.RemoveEmptyEntries).Length != 2)
            {
                _logger.Warn(new ArgumentException("Incorrect url-address", nameof(urlAddress)), "Incorrect url-address");

                return false;
            }

            if (urlAddress.Split(new[] { "://?" }, StringSplitOptions.RemoveEmptyEntries).Length != 1 || urlAddress.Split(new[] { "/?" }, StringSplitOptions.RemoveEmptyEntries).Length != 1)
            {
                _logger.Warn(new ArgumentException("Incorrect url-address", nameof(urlAddress)), "Incorrect url-address");

                return false;
            }

            if (urlAddress.Split('?').Length > 2)
            {
                _logger.Warn(new ArgumentException("Incorrect url-address", nameof(urlAddress)), "Incorrect url-address");

                return false;
            }

            return true;
        }
    }
}
