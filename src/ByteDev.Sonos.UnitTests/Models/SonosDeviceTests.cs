using System;
using ByteDev.Sonos.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.UnitTests.Models
{
    [TestFixture]
    public class SonosDeviceTests
    {
        [Test]
        public void WhenIpAddressIsNull_ThenThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SonosDevice(null));
        }

        [Test]
        public void WhenIpAddressIsEmpty_ThenThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SonosDevice(string.Empty));
        }

        [Test]
        public void WhenIpAddressValid_ThenSet()
        {
            const string ipAddress = "192.168.0.1";

            var sut = new SonosDevice(ipAddress);

            Assert.That(sut.IpAddress, Is.EqualTo(ipAddress));
        }
    }
}