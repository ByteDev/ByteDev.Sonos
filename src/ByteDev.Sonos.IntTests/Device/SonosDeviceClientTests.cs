using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.Common;
using ByteDev.Sonos.Device;
using ByteDev.Sonos.Testing;
using NUnit.Framework;

namespace ByteDev.Sonos.IntTests.Device
{
    [TestFixture]
    public class SonosDeviceClientTests
    {
        [TestFixture]
        public class GetDeviceDescriptionXmlAsync : SonosDeviceClientTests
        {
            private SonosDeviceClient _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new SonosDeviceClient();
            }

            [Test]
            public async Task WhenDeviceExists_ThenReturnXml()
            {
                var result = await _sut.GetDeviceDescriptionXmlAsync(TestSpeaker.IpAddress);

                Assert.That(result.IsXml(), Is.True);
            }

            [Test]
            public void WhenDeviceNotExist_ThenThrowException()
            {
                Assert.ThrowsAsync<HttpRequestException>(() => _sut.GetDeviceDescriptionXmlAsync(TestSpeaker.IpAddressNotExist));
            }
        }
    }
}