using BLL.Interface.Interfaces;
using BLL.Repositories;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace URLParcer
{
    public static class ResolverConfig
    {
        private const string FileToReadPath = "url_addresses.txt";

        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IFileReader>().To<FileReader>().WithConstructorArgument("filePath", FileToReadPath);
            kernel.Bind<ITextToURLConverter>().To<TextToURLConverter>();
            kernel.Bind<IURLToXMLConverter>().To<URLToXMLConverter>();
            kernel.Bind<ILogger>().To<NLogger>().WithConstructorArgument("type", typeof(TextToURLConverter));
        }
    }
}
