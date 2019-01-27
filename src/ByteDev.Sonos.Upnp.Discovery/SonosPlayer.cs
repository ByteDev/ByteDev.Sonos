using System;
using System.Net;

namespace ByteDev.Sonos.Upnp.Discovery
{
    public class SonosPlayer
    {
        public string UniqueDeviceName { get; set; }            // "RINCON_5CAAFD9AFD4001400"
        public Uri BaseUrl { get; set; }                        // {http://10.0.1.38:1400/xml}
        public string LocationUrl { get; set; }                 // "http://10.0.1.38:1400/xml/device_description.xml"
        public string Manufacturer { get; set; }                // "Sonos, Inc."
        public string FriendlyName { get; set; }                // "10.0.1.92 - Sonos PLAY:1"
        public string ModelDescription { get; set; }            // "Sonos PLAY:1"
        public string ModelName { get; set; }                   // "Sonos PLAY:1"
        public string ModelNumber { get; set; }                 // "S1"
        public string StandardDeviceType { get; set; }          // "ZonePlayer" || "MediaRenderer" || "MediaServer"
        public IPEndPoint RemoteEndPoint { get; set; }          // {10.0.1.92:1400}
                                                                // Address = {10.0.1.38}
                                                                // Port = 1400

        public override string ToString()
        {
            return FriendlyName ?? string.Empty;
        }
    }
}