using System;
using ByteDev.Sonos.Models;
using NUnit.Framework;

namespace ByteDev.Sonos.UnitTests.Models
{
    [TestFixture]
    public class SonosTimeSpanTests
    {
        [TestFixture]
        public class Constructor : SonosTimeSpanTests
        {
            [Test]
            public void WhenArgIsTimespan_ThenSetProperties()
            {
                var ts = new TimeSpan(1, 2, 3);

                var sut = new SonosTimeSpan(ts);

                Assert.That(sut.Hours, Is.EqualTo(ts.Hours));
                Assert.That(sut.Minutes, Is.EqualTo(ts.Minutes));
                Assert.That(sut.Seconds, Is.EqualTo(ts.Seconds));
            }

            [TestCase(-1, 0, 0)]
            [TestCase(0, -1, 0)]
            [TestCase(0, 0, -1)]
            [TestCase(100, 0, 0)]
            [TestCase(0, 60, 0)]
            [TestCase(0, 0, 60)]
            public void WhenHoursOrMinutesOrSecondsAreInvalid_ThenThrowException(int hours, int minutes, int seconds)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>  new SonosTimeSpan(hours, minutes, seconds));
            }

            [Test]
            public void WhenNoneSpecified_ThenSetToZero()
            {
                var sut = new SonosTimeSpan();

                Assert.That(sut.Hours, Is.EqualTo(0));
                Assert.That(sut.Minutes, Is.EqualTo(0));
                Assert.That(sut.Seconds, Is.EqualTo(0));
            }

            [Test]
            public void WhenOnlySecondsSpecified_ThenSetProperties()
            {
                var sut = new SonosTimeSpan(10);

                Assert.That(sut.Hours, Is.EqualTo(0));
                Assert.That(sut.Minutes, Is.EqualTo(0));
                Assert.That(sut.Seconds, Is.EqualTo(10));
            }

            [Test]
            public void WhenMinutesAndSecondsSpecified_ThenSetProperties()
            {
                var sut = new SonosTimeSpan(3, 10);

                Assert.That(sut.Hours, Is.EqualTo(0));
                Assert.That(sut.Minutes, Is.EqualTo(3));
                Assert.That(sut.Seconds, Is.EqualTo(10));
            }

            [Test]
            public void WhenHoursAndMinutesAndSecondsSpecified_ThenSetProperties()
            {
                var sut = new SonosTimeSpan(1, 3, 10);

                Assert.That(sut.Hours, Is.EqualTo(1));
                Assert.That(sut.Minutes, Is.EqualTo(3));
                Assert.That(sut.Seconds, Is.EqualTo(10));
            }
        }

        [TestFixture]
        public class OverrideToString : SonosTimeSpanTests
        {
            [Test]
            public void WhenCalled_ThenReturnsFormatted()
            {
                var sut = new SonosTimeSpan(1, 2, 3);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("01:02:03"));
            }
        }

        [TestFixture]
        public class ToTimeSpan : SonosTimeSpanTests
        {
            [Test]
            public void WhenCalled_ThenReturnsAsTimespan()
            {
                var sut = new SonosTimeSpan(1, 2, 3);

                var result = sut.ToTimeSpan();

                Assert.That(result.Hours, Is.EqualTo(1));
                Assert.That(result.Minutes, Is.EqualTo(2));
                Assert.That(result.Seconds, Is.EqualTo(3));
            }
        }
    }
}