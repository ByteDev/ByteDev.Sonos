using System;
using ByteDev.Sonos.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.UnitTests.Models
{
    [TestFixture]
    public class SonosVolumeTests
    {
        [TestFixture]
        public class Constructor : SonosVolumeTests
        {
            [Test]
            public void WhenVolumeLessThanZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new SonosVolume(-1));
            }

            [Test]
            public void WhenVolumeGreaterThanOneHundred_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new SonosVolume(101));
            }

            [Test]
            public void WhenVolumeNotSpecified_ThenSetValueToZero()
            {
                var sut = new SonosVolume();

                Assert.That(sut.Value, Is.Zero);
            }

            [Test]
            public void WhenVolumeSpecifiedIsValid_ThenSetValue()
            {
                var sut = new SonosVolume(10);

                Assert.That(sut.Value, Is.EqualTo(10));
            }
        }

        [TestFixture]
        public class Increase : SonosVolumeTests
        {
            [Test]
            public void WhenIncrease_ThenSetToExistingPlusIncrease()
            {
                var sut = new SonosVolume(50);

                sut.Increase(15);

                Assert.That(sut.Value, Is.EqualTo(65));
            }

            [Test]
            public void WhenIncreasePlusExistingGoesOverMax_ThenSetToMax()
            {
                var sut = new SonosVolume(50);

                sut.Increase(51);

                Assert.That(sut.Value, Is.EqualTo(SonosVolume.MaxVolume));
            }

            [Test]
            public void WhenIncreaseAmountIsLessThanZero_ThenThrowException()
            {
                var sut = new SonosVolume(50);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Increase(-1));
            }
        }

        [TestFixture]
        public class Decrease : SonosVolumeTests
        {
            [Test]
            public void WhenDecrease_ThenSetToExistingMinusDecrease()
            {
                var sut = new SonosVolume(50);

                sut.Decrease(20);

                Assert.That(sut.Value, Is.EqualTo(30));
            }

            [Test]
            public void WhenDecreaseMinusExistingGoesUnderMin_ThenSetToMin()
            {
                var sut = new SonosVolume(20);

                sut.Decrease(21);

                Assert.That(sut.Value, Is.EqualTo(SonosVolume.MinVolume));
            }

            [Test]
            public void WhenDecreaseAmountIsLessThanZero_ThenThrowException()
            {
                var sut = new SonosVolume(50);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.Decrease(-1));
            }
        }
    }
}