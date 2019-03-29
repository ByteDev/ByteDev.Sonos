using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.Sonos.Device;
using ByteDev.Sonos.Models;
using ByteDev.Sonos.Testing;
using NUnit.Framework;

namespace ByteDev.Sonos.IntTests.Device
{
    [TestFixture]
    public class SonosDeviceServiceTests
    {
        private SonosDeviceService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SonosDeviceService();
        }

        [TestFixture]
        public class Reboot : SonosDeviceServiceTests
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReboot()
            {
                var response = await _sut.RebootAsync(TestSpeaker.IpAddress);

                Assert.That(response.IsSuccessStatusCode, Is.True);
            }

            [Test]
            public void WhenSpeakerDoesNotExist_ThenThrowException()
            {
                Assert.ThrowsAsync<HttpRequestException>(() => _sut.RebootAsync(TestSpeaker.IpAddressNotExist));
            }
        }

        [TestFixture]
        public class GetSonosDeviceAsync : SonosDeviceServiceTests
        {
            [Test]
            public async Task WhenSpeakerExists_ThenSetProperties()
            {
                SonosDevice result = await _sut.GetDeviceAsync(TestSpeaker.IpAddress);

                Assert.That(result.IpAddress, Is.EqualTo(TestSpeaker.IpAddress));
                Assert.That(result.ModelNumber, Is.EqualTo("S1"));
            }

            [Test]
            public void WhenSpeakerDoesNotExist_ThenThrowException()
            {
                Assert.ThrowsAsync<HttpRequestException>(() => _sut.GetDeviceAsync(TestSpeaker.IpAddressNotExist));
            }
        }
    }
}
