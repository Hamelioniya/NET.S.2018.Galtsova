using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BLL.Interface.Interfaces;
using BLL.Repositories;
using DAL.Interface.Interfaces;
using Ninject;
using URLParcer;

namespace ConsolePL
{
    public class Program
    {
        private const string FileToSavePath = "url_addresses.xml";

        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        public static void Main(string[] args)
        {
            IURLToXMLConverter converter = Resolver.Get<IURLToXMLConverter>();

            XDocument xmlDocument = converter.GetXMLDocument(Resolver.Get<ITextToURLConverter>(), Resolver.Get<IFileReader>());

            xmlDocument.Save(FileToSavePath);
        }
    }
}
