using System;
using ByteDev.Sonos.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.UnitTests.Models
{
    [TestFixture]
    public class SonosTrebleTests
    {
        [Test]
        public void WhenValueIsValid_ThenSet()
        {
            var sut = new SonosTreble(5);

            Assert.That(sut.Value, Is.EqualTo(5));
        }

        [Test]
        public void WhenValueNotSpecified_ThenSetsValueToZero()
        {
            var sut = new SonosTreble();

            Assert.That(sut.Value, Is.EqualTo(0));
        }

        [Test]
        public void WhenValueIsLowerThanMin_ThenThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SonosTreble(SonosTreble.MinTreble - 1));
        }

        [Test]
        public void WhenValueIsGreaterThanMax_ThenThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SonosTreble(SonosTreble.MaxTreble + 1));
        }
    }
}