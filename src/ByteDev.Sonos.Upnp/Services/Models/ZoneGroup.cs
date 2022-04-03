using System.Xml.Serialization;

namespace ByteDev.Sonos.Upnp.Services.Models
{
    public class ZoneGroup
    {
        [XmlElement("ZoneGroupMember")]
        public ZoneGroupMember[] ZoneGroupMembers { get; set; }

        [XmlAttribute]
        public string Coordinator { get; set; }

        [XmlAttribute("ID")]
        public string Id { get; set; }
    }
}