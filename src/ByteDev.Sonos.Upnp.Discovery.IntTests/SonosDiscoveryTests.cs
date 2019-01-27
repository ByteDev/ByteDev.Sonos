using System.Threading;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.Discovery.IntTests
{
    [TestFixture]
    public class SonosDiscoveryTests
    {
        [Test]
        public void WhenDevicesExist_ThenDetectThem()
        {
            var sut = new SonosDiscoveryService();

            sut.StartScan();

            Thread.Sleep(3000);

            Assert.That(sut.Players.Count, Is.GreaterThan(0));
        }
    }
}