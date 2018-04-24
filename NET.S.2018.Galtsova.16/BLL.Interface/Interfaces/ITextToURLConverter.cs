using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides a converter from text to uri-address interface.
    /// </summary>
    public interface ITextToURLConverter
    {
        /// <summary>
        /// Gets a next uri-address converted from the url-address text representation.
        /// </summary>
        /// <param name="fileReader">The file reader to get url-addresses in the text representation</param>
        /// <returns>The sequence of the uri-addresses converted from the url-address text representation.</returns>
        IEnumerable<Uri> GetUri(IFileReader fileReader);
    }
}
