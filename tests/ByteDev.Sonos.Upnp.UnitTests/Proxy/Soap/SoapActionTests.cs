using ByteDev.Sonos.Upnp.Proxy.Soap;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.UnitTests.Proxy.Soap
{
    [TestFixture]
    public class SoapActionTests
    {
        [Test]
        public void WhenCreated_ThenSetProperties()
        {
            var sut = new SoapAction("someAction", "someActionNameSpace");

            Assert.That(sut.HeaderValue, Is.EqualTo("\"someActionNameSpace#someAction\""));
        }
    }
}