using System;
using System.Web;
using System.Xml.Linq;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.Repositories
{
    /// <summary>
    /// Represents an xml converter from url-address. 
    /// </summary>
    public class URLToXMLConverter : IURLToXMLConverter
    {
        /// <summary>
        /// Gets an xml document from url-addresses.
        /// </summary>
        /// <param name="textToUrlConverter">The url-address from text representation converter.</param>
        /// <param name="fileReader">The file reader to get url-addresses in the text representation.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="textToUrlConverter"/> or/and the <paramref name="fileReader"/> equal to null.
        /// </exception>
        /// <returns>The formed xml document.</returns>
        public XDocument GetXMLDocument(ITextToURLConverter textToUrlConverter, IFileReader fileReader)
        {
            if (ReferenceEquals(textToUrlConverter, null))
            {
                throw new ArgumentNullException(nameof(textToUrlConverter));
            }

            if (ReferenceEquals(fileReader, null))
            {
                throw new ArgumentNullException(nameof(fileReader));
            }

            XDocument document = new XDocument();
            XElement urlAddresses = new XElement("urlAddresses");

            foreach (var uri in textToUrlConverter.GetUri(fileReader))
            {
                urlAddresses.Add(GetUrlAddress(uri));
            }

            document.Add(urlAddresses);

            return document;
        }

        #region Private methods

        private XElement GetUrlAddress(Uri uri)
        {
            XElement address = new XElement("urlAddress");

            address.Add(GetHostName(uri));
            address.Add(GetPathes(uri));
            address.Add(GetParameters(uri));

            return address;
        }

        private XElement GetHostName(Uri uri)
        {
            XElement host = new XElement("host");
            XAttribute hostName = new XAttribute("name", uri.Host);

            host.Add(hostName);

            return host;
        }

        private XElement GetPathes(Uri uri)
        {
            XElement pathes = new XElement("uri");

            foreach (var segment in uri.Segments)
            {
                string segmentValue = segment.Trim('/', ' ');

                if (!string.IsNullOrWhiteSpace(segmentValue))
                {
                    pathes.Add(new XElement("segment", segmentValue));
                }
            }

            return pathes;
        }

        private XElement GetParameters(Uri uri)
        {
            XElement parameters = new XElement("parameters");

            foreach (var key in HttpUtility.ParseQueryString(uri.Query).AllKeys)
            {
                XElement parametr = new XElement("parametr");
                parametr.Add(new XAttribute("value", HttpUtility.ParseQueryString(uri.Query)[key]));
                parametr.Add(new XAttribute("key", key));
                parameters.Add(parametr);
            }

            return parameters;
        }

        #endregion !Private methods.
    }
}
