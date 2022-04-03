using ByteDev.Sonos.Upnp.Services;

namespace ByteDev.Sonos
{
    public class SonosControllerFactory
    {
        public SonosController Create(string ipAddress)
        {
            return new SonosController(new AvTransportService(ipAddress),
                new RenderingControlService(ipAddress),
                new ContentDirectoryService(ipAddress),
                new ZoneGroupTopologyService(ipAddress));
        }
    }
}