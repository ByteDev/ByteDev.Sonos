using System;
using System.Collections.Generic;
using OpenSource.UPnP;

namespace ByteDev.Sonos.Upnp.Discovery
{
    public class SonosDiscoveryService
    {
        private const string DeviceType = "urn:schemas-upnp-org:device:ZonePlayer:1";

        private UPnPSmartControlPoint ControlPoint { get; set; }

        public SonosDiscoveryService()
        {
            Players = new List<SonosPlayer>();
        }

        public event Action PlayersChanged;

        public IList<SonosPlayer> Players { get; }

        public virtual void StartScan()
        {
            ControlPoint = new UPnPSmartControlPoint(OnDeviceAdded, OnServiceAdded, DeviceType);
        }

        private void OnDeviceAdded(UPnPSmartControlPoint sender, UPnPDevice upnpDevice)
        {
            var player = SonosPlayerMapper.Map(upnpDevice);

            Players.Add(player);

            PlayersChanged?.Invoke();
        }

        private void OnServiceAdded(UPnPSmartControlPoint sender, UPnPService service)
        {
        }
    }
}