using System;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.UnitTests
{
    [TestFixture]
    public class SonosUriTests
    {
        private const string ValidIpAddress = "192.168.0.1";
        private const string ValidPath = "some/path";

        [TestFixture]
        public class Constructor : SonosUriTests
        {
            [Test]
            public void WhenIpAddressIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => new SonosUri(null));
            }

            [Test]
            public void WhenIpAddressIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => new SonosUri(string.Empty));
            }

            [Test]
            public void WhenIpAddressIsValid_ThenSet()
            {
                var sut = new SonosUri(ValidIpAddress);

                Assert.That(sut.IpAddress, Is.EqualTo(ValidIpAddress));
                Assert.That(sut.Path, Is.Empty);
            }

            [Test]
            public void WhenPathIsNull_ThenSetPathToEmpty()
            {
                var sut = new SonosUri(ValidIpAddress, null);

                Assert.That(sut.Path, Is.Empty);
            }

            [Test]
            public void WhenPathHasSlashPrefix_ThenSetPathWithoutSlash()
            {
                var sut = new SonosUri(ValidIpAddress, "/somepath");

                Assert.That(sut.Path, Is.EqualTo("somepath"));
            }

            [Test]
            public void WhenPathNoSlashPrefix_ThenSetPath()
            {
                var sut = new SonosUri(ValidIpAddress, ValidPath);

                Assert.That(sut.Path, Is.EqualTo(ValidPath));
            }
        }

        [TestFixture]
        public class OverrideToString : SonosUriTests
        {
            [Test]
            public void WhenCalled_ThenReturnsUriString()
            {
                var expected = $"http://{ValidIpAddress}:{SonosUri.PortNumber}/{ValidPath}";

                var sut = new SonosUri(ValidIpAddress, ValidPath);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class ToUri : SonosUriTests
        {
            [Test]
            public void WhenCalled_ThenReturnsUri()
            {
                var expected = new Uri($"http://{ValidIpAddress}:{SonosUri.PortNumber}/{ValidPath}");

                var sut = new SonosUri(ValidIpAddress, ValidPath);

                var result = sut.ToUri();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}