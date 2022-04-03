using System.Threading.Tasks;
using ByteDev.Sonos.Testing;
using ByteDev.Sonos.Upnp.Services;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.IntTests.Services
{
    [TestFixture]
    public class ZoneGroupTopologyServiceTest
    {
        private ZoneGroupTopologyService _zoneGroupTopologyService;

        [SetUp]
        public void SetUp()
        {
            _zoneGroupTopologyService = new ZoneGroupTopologyService(TestSpeaker.IpAddress);
        }

        [Test]
        public async Task WhenSpeakerExists_ThenReturnVolume()
        {
            var zoneGroupState = await _zoneGroupTopologyService.GetZoneGroupStateAsync().ConfigureAwait(false);

            Assert.That(zoneGroupState, Is.Not.Null);
            Assert.That(zoneGroupState.ZoneGroups.Items.Length, Is.GreaterThan(0));
        }
    }
}