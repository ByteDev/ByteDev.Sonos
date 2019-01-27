using System;

namespace ByteDev.Sonos.Upnp.Services.Models
{
    public class GetPositionInfoResponse
    {
        public int TrackNumber { get; set; }
        public TimeSpan TrackDuration { get; set; }
        public string TrackMetaDataRaw { get; set; }
        public TrackMetaData TrackMetaData { get; set; }
        public string TrackUri { get; set; }
        public TimeSpan RelativeTime { get; set; }
        public string AbsoluteTime { get; set; }
        public int RelativeCount { get; set; }
        public int AbsoluteCount { get; set; }
    }

    public class TrackMetaData
    {
        public string ProtocolInfo { get; set; }
        public string Duration { get; set; }
        public string AlbumArtUri { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public string Creator { get; set; }
        public string Album { get; set; }
        public string Res { get; set; }
    }
}