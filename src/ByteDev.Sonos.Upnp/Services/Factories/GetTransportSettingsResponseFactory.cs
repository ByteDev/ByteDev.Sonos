using System.Linq;
using System.Xml.Linq;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Upnp.Services.Factories
{
    public class GetTransportSettingsResponseFactory
    {
        public GetTransportSettingsResponse CreateFor(XNamespace actionXNamespace, string xml)
        {
            XElement element = XElement.Parse(xml);

            var responseNode = element.Descendants(actionXNamespace + "GetTransportSettingsResponse").First();

            return new GetTransportSettingsResponse
            {
                PlayMode = responseNode.Element("PlayMode")?.Value,
                RecQualityMode = responseNode.Element("RecQualityMode")?.Value
            };
        }
    }
}