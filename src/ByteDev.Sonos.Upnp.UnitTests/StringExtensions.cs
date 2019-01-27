using System.Xml;
using ByteDev.Common;

namespace ByteDev.Sonos.Upnp.UnitTests
{
    internal static class StringExtensions
    {
        public static bool IsSoapMessage(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            if (!source.IsXml())
                return false;

            var doc = new XmlDocument();
            doc.LoadXml(source);

            if (doc.DocumentElement == null)
                return false;

            return doc.DocumentElement.NamespaceURI == "http://schemas.xmlsoap.org/soap/envelope/";
        }
    }
}