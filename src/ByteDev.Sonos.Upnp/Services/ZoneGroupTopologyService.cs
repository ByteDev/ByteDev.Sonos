using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ByteDev.Sonos.Upnp.Proxy;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Upnp.Services
{
    public class ZoneGroupTopologyService
    {
        private readonly IUpnpClient _upnpClient;
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(ZoneGroupState));

        private const string ControlUrl = "/ZoneGroupTopology/Control";
        private const string ActionNamespace = "urn:schemas-upnp-org:service:ZoneGroupTopology:1";

        public ZoneGroupTopologyService(string ipAddress)
        {
            var upnpUri = new SonosUri(ipAddress, ControlUrl);
            _upnpClient = new UpnpClient(upnpUri.ToUri(), ActionNamespace);
        }

        public async Task<ZoneGroupState> GetZoneGroupStateAsync()
        {
            var xmlResponse = await _upnpClient.InvokeFuncAsync<string>("GetZoneGroupState");
            using (var responseStream = new StringReader(xmlResponse))
            {
                var zoneGroupState = (ZoneGroupState) XmlSerializer.Deserialize(responseStream);
                return zoneGroupState;
            }
        }
    }
}