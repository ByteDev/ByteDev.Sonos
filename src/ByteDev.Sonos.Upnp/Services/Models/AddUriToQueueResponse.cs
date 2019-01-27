namespace ByteDev.Sonos.Upnp.Services.Models
{
    public class AddUriToQueueResponse
    {
        public int FirstTrackNumberEnqueued { get; set; }

        public int NumTracksAdded { get; set; }

        public int NewQueueLength { get; set; }
    }
}