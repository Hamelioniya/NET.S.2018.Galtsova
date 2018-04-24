using System.Xml.Linq;
using DAL.Interface.Interfaces;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides an url-address converter to xml interface.
    /// </summary>
    public interface IURLToXMLConverter
    {
        /// <summary>
        /// Gets an xml document from url-addresses.
        /// </summary>
        /// <param name="textToUrlConverter">The url-address from text representation converter.</param>
        /// <param name="fileReader">The file reader to get url-addresses in the text representation.</param>
        /// <returns>The formed xml document.</returns>
        XDocument GetXMLDocument(ITextToURLConverter textToUrlConverter, IFileReader fileReader);
    }
}
