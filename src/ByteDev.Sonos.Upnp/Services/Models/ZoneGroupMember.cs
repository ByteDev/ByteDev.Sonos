using System.Xml.Serialization;

namespace ByteDev.Sonos.Upnp.Services.Models
{
    public class ZoneGroupMember
    {
        [XmlAttribute]
        public string UUID { get; set; }

        [XmlAttribute]
        public string Location { get; set; }

        [XmlAttribute]
        public string ZoneName { get; set; }

        [XmlAttribute]
        public string Icon { get; set; }

        [XmlAttribute]
        public byte Configuration { get; set; }

        [XmlAttribute]
        public byte Invisible { get; set; }

        [XmlAttribute]
        public string SoftwareVersion { get; set; }

        [XmlAttribute]
        public byte SWGen { get; set; }

        [XmlAttribute]
        public string MinCompatibleVersion { get; set; }

        [XmlAttribute]
        public string LegacyCompatibleVersion { get; set; }

        [XmlAttribute]
        public string ChannelMapSet { get; set; }

        [XmlAttribute]
        public byte BootSeq { get; set; }

        [XmlAttribute]
        public byte TVConfigurationError { get; set; }

        [XmlAttribute]
        public byte HdmiCecAvailable { get; set; }

        [XmlAttribute]
        public byte WirelessMode { get; set; }

        [XmlAttribute]
        public byte WirelessLeafOnly { get; set; }

        [XmlAttribute]
        public ushort ChannelFreq { get; set; }

        [XmlAttribute]
        public byte BehindWifiExtender { get; set; }

        [XmlAttribute]
        public byte WifiEnabled { get; set; }

        [XmlAttribute]
        public byte Orientation { get; set; }

        [XmlAttribute]
        public byte RoomCalibrationState { get; set; }

        [XmlAttribute]
        public byte SecureRegState { get; set; }

        [XmlAttribute]
        public byte VoiceConfigState { get; set; }

        [XmlAttribute]
        public byte MicEnabled { get; set; }

        [XmlAttribute]
        public byte AirPlayEnabled { get; set; }

        [XmlAttribute]
        public byte IdleState { get; set; }

        [XmlAttribute]
        public string MoreInfo { get; set; }

        [XmlAttribute]
        public ushort SSLPort { get; set; }

        [XmlAttribute]
        public ushort HHSSLPort { get; set; }

        [XmlAttribute]
        public string VirtualLineInSource { get; set; }
    }
}