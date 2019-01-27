using System;
using ByteDev.Sonos.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.UnitTests.Models
{
    [TestFixture]
    public class SonosTrackNumberTests
    {
        [Test]
        public void WhenNumberNotSpecfied_ThenSetToOne()
        {
            var sut = new SonosTrackNumber();

            Assert.That(sut.Value, Is.EqualTo(1));
        }

        [Test]
        public void WhenNumerIsSpecfied_ThenSet()
        {
            var sut = new SonosTrackNumber(5);

            Assert.That(sut.Value, Is.EqualTo(5));
        }

        [Test]
        public void WhenNumberIsLessThanOne_ThenThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SonosTrackNumber(0));
        }
    }
}