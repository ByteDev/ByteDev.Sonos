using System;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.Sonos.Upnp;

namespace ByteDev.Sonos.Device
{
    internal class SonosDeviceClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<string> GetDeviceDescriptionXmlAsync(string ipAddress)
        {
            if(string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException("IP address was null or empty.", nameof(ipAddress));

            var uri = new SonosUri(ipAddress, "xml/device_description.xml").ToUri();

            var response = await HttpClient.GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }
    }
}