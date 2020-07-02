using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ByteDev.Sonos.Upnp.Proxy;
using ByteDev.Sonos.Upnp.Proxy.Soap;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.UnitTests.Proxy
{
    [TestFixture]
    public class UpnpRequestContentFactoryTests
    {
        private const string ActionNamespace = "urn:schemas-upnp-org:service:AVTransport:1";

        private UpnpRequestContentFactory _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new UpnpRequestContentFactory();
        }

        [Test]
        public void WhenSoapActionIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateFor(null, new UpnpArgumentList()));
        }

        [Test]
        public void WhenUpnpArgListIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _sut.CreateFor(CreateSoapAction(), null));
        }

        [Test]
        public async Task WhenArgsValid_ThenReturnSoapMessage()
        {
            var list = new UpnpArgumentList(new List<UpnpArgument>
            {
                new UpnpArgument("Speed", 1)
            });

            var result = _sut.CreateFor(CreateSoapAction(), list);

            var content = await result.ReadAsStringAsync();

            Assert.That(content.IsSoapMessage(), Is.True);
        }

        private static SoapAction CreateSoapAction()
        {
            return new SoapAction("Play", ActionNamespace);
        }
    }
}