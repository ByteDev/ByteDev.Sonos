using System.Xml.Serialization;

namespace ByteDev.Sonos.Upnp.Services.Models
{
    public class ZoneGroups
    {
        [XmlElement("ZoneGroup")]
        public ZoneGroup[] Items{ get; set; }
    }
}