using System.Threading;
using System.Threading.Tasks;
using ByteDev.Sonos.Testing;
using ByteDev.Sonos.Upnp.Services;
using ByteDev.Sonos.Upnp.Services.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.IntTests.Services
{
    [TestFixture]
    public class AvTransportServiceTest
    {
        private AvTransportService _sut;

        private SonosController _sonosController;
        private RenderingControlService _renderingControlService;
        private ContentDirectoryService _contentDirectoryService;

        [SetUp]
        public void SetUp()
        {
            _renderingControlService = new RenderingControlService(TestSpeaker.IpAddress);
            _contentDirectoryService = new ContentDirectoryService(TestSpeaker.IpAddress);

            _sonosController = new SonosController(new AvTransportService(TestSpeaker.IpAddress), 
                _renderingControlService,
                _contentDirectoryService);

            _sut = new AvTransportService(TestSpeaker.IpAddress);
        }

        private async Task AssertIsPlayingAsync()
        {
            Thread.Sleep(1000);
            var isPlaying = await _sonosController.GetIsPlayingAsync();
            
            Assert.That(isPlaying, Is.True);
        }

        private async Task AssertIsNotPlayingAsync()
        {
            Thread.Sleep(1000);
            var isPlaying = await _sonosController.GetIsPlayingAsync();

            Assert.That(isPlaying, Is.False);
        }

        [TestFixture]
        public class StopAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenStopPlayback()
            {
                await _sut.StopAsync();

                await AssertIsNotPlayingAsync();
            }
        }

        [TestFixture]
        public class PauseAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenPausePlayback()
            {
                await _sut.PauseAsync();

                await AssertIsNotPlayingAsync();
            }
        }
        
        [TestFixture]
        public class PlayAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenStartPlayback()
            {
                await _sut.PlayAsync();

                await AssertIsPlayingAsync();
            }
        }

        [TestFixture]
        public class NextTrackAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenOnFirstTrack_ThenMoveToSecondTrack()
            {
                await _sut.NextTrackAsync();
            }
        }

        [TestFixture]
        public class PreviousTrackAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenOnSecondTrack_ThenMoveToFirstTrack()
            {
                await _sut.PreviousTrackAsync();
            }
        }

        [TestFixture]
        public class SeekAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenPosition_ThenSeekToPosition()
            {
                await _sut.SeekAsync(new SeekUnit(SeekUnitType.Time), "00:00:00");
            }

            [Test]
            public async Task WhenTrackNumber_ThenSeekToTrack()
            {
                await _sut.SeekAsync(new SeekUnit(SeekUnitType.TrackNumber), "1");
            }
        }

        [TestFixture]
        public class ClearQueueAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenEmptyQueue()
            {
                await _sut.ClearQueueAsync();
            }
        }

        [TestFixture]
        public class RemoveTrackFromQueueAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenTrackExists_ThenRemoveTrack()
            {
                await _sut.RemoveTrackFromQueueAsync(new QueueItemId(1));
            }
        }

        [TestFixture]
        public class AddTrackToQueueAsync : AvTransportServiceTest
        {
            private const string TrackOnNas = @"x-file-cifs://hal/Music/Mp3/Archive/Artists/a/Air/Moon%20Safari/02%20-%20Air%20-%20Sexy%20Boy.mp3";
            
            [Test]
            public async Task WhenTrackIsOnNas_AndPositionNotSpecified_ThenTrackIsAddedToEndOfQueue()
            {
                // x-file-cifs://HOSTNAME/sharename/artist/album/01%20-%20Song.mp3

                // \\hal\Music\Mp3\Archive\Artists\a\Air\Moon Safari\02 - Air - Sexy Boy.mp3
                //
                // x-file-cifs://hal/Music/Mp3/Archive/Artists/a/Air/Moon%20Safari/02%20-%20Air%20-%20Sexy%20Boy.mp3

                await _sut.AddTrackToQueueAsync(TrackOnNas);
            }

            [Test]
            public async Task WhenTrackIsOnNas_AndPositionSpecified_ThenReturnsResponse()
            {
                const int queuePosition = 3;

                var result = await _sut.AddTrackToQueueAsync(TrackOnNas, queuePosition, true);

                Assert.That(result.FirstTrackNumberEnqueued, Is.EqualTo(queuePosition));
                Assert.That(result.NewQueueLength, Is.GreaterThan(0));
                Assert.That(result.NumTracksAdded, Is.EqualTo(1));
            }



            [Test]
            public async Task WhenTrackExists_ThenAddToQueue()
            {
//                var uri = "x-sonos-spotify:" + Uri.EscapeDataString("spotify:track:5UnX1hCXQzmUzw2dn3L9nY") + "?sid=9&flags=0";
//
//                var metaData = string.Format(@"<DIDL-Lite xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:upnp=""urn:schemas-upnp-org:metadata-1-0/upnp/"" xmlns:r=""urn:schemas-rinconnetworks-com:metadata-1-0/"" xmlns=""urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/""><item id=""00030000{0}"" parentID=""-1"" restricted=""true""><dc:title>{1}</dc:title><upnp:class>object.item.audioItem.musicTrack</upnp:class><desc id=""cdudn"" nameSpace=""urn:schemas-rinconnetworks-com:metadata-1-0/"">SA_RINCON2311_jishi</desc></item></DIDL-Lite>",
//                        Uri.EscapeDataString("spotify:track:5UnX1hCXQzmUzw2dn3L9nY"),
//                        "Foo");

                
                var r = await _contentDirectoryService.BrowseAsync(0, 1);

                //var uri = "x-sonos-spotify:spotify%3atrack%3a389R9arpxdfl0JA450Qn9m?sid=9&flags=8224&sn=1";

                //var uri = "x-rincon-cpcontainer:1006006cspotify%3auser%3abaretom%3aplaylist%3a50oyVNwpgWEaBSL5YDybtC";

                // Does meta data have to be encoded? (should it be??)
                //var metaData = "&lt;DIDL-Lite xmlns:dc=&quot;http://purl.org/dc/elements/1.1/&quot; xmlns:upnp=&quot;urn:schemas-upnp-org:metadata-1-0/upnp/&quot; xmlns:r=&quot;urn:schemas-rinconnetworks-com:metadata-1-0/&quot; xmlns=&quot;urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/&quot;&gt;&lt;item id=&quot;1006006cspotify%3auser%3casretom%3aplaylist%3a50oyVNwpgWEaBSL5YDybtC&quot; parentID=&quot;10080664playlists%3afolder%3a6954091786839755846&quot; restricted=&quot;true&quot;&gt;&lt;dc:title&gt;Enter The Dub&lt;/dc:title&gt;&lt;upnp:class&gt;object.container.playlistContainer&lt;/upnp:class&gt;&lt;desc id=&quot;cdudn&quot; nameSpace=&quot;urn:schemas-rinconnetworks-com:metadata-1-0/&quot;&gt;SA_RINCON2311_X_#Svc2311-0-Token&lt;/desc&gt;&lt;/item&gt;&lt;/DIDL-Lite&gt;";

                // Must pass in uri and meta data
                //await _sut.AddTrackToQueueAsync(uri, metaData, EnqueueAsNextType.AddToEndOfQueue);
            }
        }

        [TestFixture]
        public class AddSpotifyTrackToQueue : AvTransportServiceTest
        {
            // TODO: currently returns 800 (possible auth error adding spotify track?)
            [Test]
            public async Task WhenTrackExists_ThenAddToQueue()
            {
                // https://api.spotify.com/v1/tracks/389R9arpxdfl0JA450Qn9m
                var spotifyId = "389R9arpxdfl0JA450Qn9m";

                await _sut.AddSpotifyTrackToQueueAsync(spotifyId);
            }
        }
        
        [TestFixture]
        public class GetMediaInfoAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnInfo()
            {
                var classUnderTest = new AvTransportService(TestSpeaker.IpAddress);

                var result = await classUnderTest.GetMediaInfoAsync();

                Assert.That(result, Is.Not.Null);
            }
        }

        [TestFixture]
        public class GetTransportInfoAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnInfo()
            {
                var classUnderTest = new AvTransportService(TestSpeaker.IpAddress);

                var result = await classUnderTest.GetTransportInfoAsync();
                
                Assert.That(result.CurrentSpeed, Is.EqualTo("1"));
            }
        }

        [TestFixture]
        public class GetPositionInfoAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnInfo()
            {
                var classUnderTest = new AvTransportService(TestSpeaker.IpAddress);

                var result = await classUnderTest.GetPositionInfoAsync();

                Assert.That(result, Is.Not.Null);
            }
        }

        [TestFixture]
        public class GetTransportSettingsAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnInfo()
            {
                var classUnderTest = new AvTransportService(TestSpeaker.IpAddress);

                var result = await classUnderTest.GetTransportSettingsAsync();

                Assert.That(result, Is.Not.Null);
            }
        }

        [TestFixture]
        public class SetPlayModeAsync : AvTransportServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenSetMode()
            {
                await _sut.SetPlayModeAsync(new PlayMode(PlayModeType.Normal));
            }
        }
    }
}