using OpenSource.UPnP;

namespace ByteDev.Sonos.Upnp.Discovery
{
    public class SonosPlayerMapper
    {
        public static SonosPlayer Map(UPnPDevice device)
        {
            return new SonosPlayer
            {
                UniqueDeviceName = device.UniqueDeviceName,
                BaseUrl = device.BaseURL,
                LocationUrl = device.LocationURL,
                FriendlyName = device.FriendlyName,
                ModelNumber = device.ModelNumber,
                ModelDescription = device.ModelDescription,
                ModelName = device.ModelName,
                Manufacturer = device.Manufacturer,
                RemoteEndPoint = device.RemoteEndPoint,
                StandardDeviceType = device.StandardDeviceType
            };
        }
    }
}