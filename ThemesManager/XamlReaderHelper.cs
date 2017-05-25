
namespace Microshaoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    //using System.Xaml;
    using System.Windows.Markup;
    public static class XamlReaderHelper
    {
        public static T Parse<T>(string xamlText) where T : class
        {
            return XamlReader.Parse(xamlText) as T;
        }
        public static T Parse<T>(string xamlText, ParserContext parserContext) where T : class
        {
            return XamlReader.Parse(xamlText, parserContext) as T;
        }
        public static T ParseFromFile<T>(string xamlFilePath) where T : class
        {
            var xaml = File.ReadAllText(xamlFilePath);
            return XamlReader.Parse(xaml) as T;
        }
        public static T ParseFromFile<T>(string xamlFilePath, ParserContext parserContext) where T : class
        {
            var xaml = File.ReadAllText(xamlFilePath);
            return XamlReader.Parse(xaml, parserContext) as T;
        }
    }
}
