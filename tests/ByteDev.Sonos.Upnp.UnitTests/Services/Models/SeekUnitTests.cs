using System;
using ByteDev.Sonos.Upnp.Services.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.UnitTests.Services.Models
{
    [TestFixture]
    public class SeekUnitTests
    {
        [Test]
        public void WhenConstructedWithInvalidSeekUnitType_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new SeekUnit((SeekUnitType) 9));
        }

        [Test]
        public void WhenConstructedWithInvalidStringValid_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new SeekUnit("NOT_VALID"));
        }

        [Test]
        public void WhenConstructedWithSeekUnitTypeTime_ThenSetProperties()
        {
            var sut = new SeekUnit(SeekUnitType.Time);

            Assert.That(sut.Type, Is.EqualTo(SeekUnitType.Time));
            Assert.That(sut.Value, Is.EqualTo("REL_TIME"));
        }

        [Test]
        public void WhenConstructedWithSeekUnitTypeTrackNumber_ThenSetProperties()
        {
            var sut = new SeekUnit(SeekUnitType.TrackNumber);

            Assert.That(sut.Type, Is.EqualTo(SeekUnitType.TrackNumber));
            Assert.That(sut.Value, Is.EqualTo("TRACK_NR"));
        }

        [Test]
        public void WhenConstructedWithStringTime_ThenSetProperties()
        {
            var sut = new SeekUnit("REL_TIME");

            Assert.That(sut.Type, Is.EqualTo(SeekUnitType.Time));
            Assert.That(sut.Value, Is.EqualTo("REL_TIME"));
        }

        [Test]
        public void WhenConstructedWithStringTrackNumber_ThenSetProperties()
        {
            var sut = new SeekUnit("TRACK_NR");

            Assert.That(sut.Type, Is.EqualTo(SeekUnitType.TrackNumber));
            Assert.That(sut.Value, Is.EqualTo("TRACK_NR"));
        }
    }
}