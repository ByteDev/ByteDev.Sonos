using System.Threading.Tasks;
using ByteDev.Sonos.Testing;
using ByteDev.Sonos.Upnp.Services;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.IntTests.Services
{
    [TestFixture]
    public class RenderingControlServiceTest
    {
        private RenderingControlService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new RenderingControlService(TestSpeaker.IpAddress);
        }

        [TestFixture]
        public class GetVolumeAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnVolume()
            {
                var result = await _sut.GetVolumeAsync();

                Assert.That(result, Is.GreaterThanOrEqualTo(0));
                Assert.That(result, Is.LessThanOrEqualTo(100));
            }
        }

        [TestFixture]
        public class SetVolumeAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenWithinValidRange_ThenSetVolume()
            {
                const int expected = 20;

                await _sut.SetVolumeAsync(expected);

                var result = await _sut.GetVolumeAsync();

                Assert.That(result, Is.EqualTo(expected));
            }
        }

        [TestFixture]
        public class GetBassAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnBass()
            {
                var result = await _sut.GetBassAsync();

                Assert.That(result, Is.GreaterThanOrEqualTo(-10));
                Assert.That(result, Is.LessThanOrEqualTo(10));
            }
        }

        [TestFixture]
        public class SetBassAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenWithinValidRange_ThenSetBass()
            {
                await _sut.SetBassAsync(-10);

                var result = await _sut.GetBassAsync();

                Assert.That(result, Is.EqualTo(-10));
            }
        }

        [TestFixture]
        public class GetTrebleAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenSpeakerExists_ThenReturnTreble()
            {
                var result = await _sut.GetTrebleAsync();

                Assert.That(result, Is.GreaterThanOrEqualTo(-10));
                Assert.That(result, Is.LessThanOrEqualTo(10));
            }
        }

        [TestFixture]
        public class SetTrebleAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenWithinValidRange_ThenSetTreble()
            {
                const int value = 10;

                await _sut.SetTrebleAsync(value);

                var result = await _sut.GetTrebleAsync();

                Assert.That(result, Is.EqualTo(value));
            }
        }
        
        [TestFixture]
        public class GetIsMuteEnabledAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenSpeakerNotMuted_ThenReturnFalse()
            {
                var result = await _sut.GetIsMuteEnabledAsync();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class SetMuteAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenMuteIsFalse_ThenSpeakerIsNotMuted()
            {
                await _sut.SetMuteAsync(false);

                var result = await _sut.GetIsMuteEnabledAsync();

                Assert.That(result, Is.False);
            }

            [Test]
            public async Task WhenMuteIsTrue_ThenSpeakerIsMuted()
            {
                await _sut.SetMuteAsync(true);

                var result = await _sut.GetIsMuteEnabledAsync();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class GetIsLoudnessEnabledAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenLoudnessEnabled_ThenReturnTrue()
            {
                var result = await _sut.GetIsLoudnessEnabledAsync();

                Assert.That(result, Is.True);
            }
        }
        
        [TestFixture]
        public class SetLoudnessAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenSetLoudnessToFalse_ThenLoudnessIsDisabled()
            {
                await _sut.SetLoudnessAsync(false);

                var result = await _sut.GetIsLoudnessEnabledAsync();

                Assert.That(result, Is.False);
            }

            [Test]
            public async Task WhenSetLoudnessToTrue_ThenLoudnessIsEnabled()
            {
                await _sut.SetLoudnessAsync(true);

                var result = await _sut.GetIsLoudnessEnabledAsync();

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class GetIsHeadphoneConnectedAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenHeadphonesNotConnected_ThenReturnFalse()
            {
                var result = await _sut.GetIsHeadphoneConnectedAsync();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class GetEqAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenWithDialogLevel_ThenReturnIsEnabled()
            {
                var result = await _sut.GetEqAsync(EqType.DialogLevel);

                Assert.That(result, Is.True);
            }

            [Test]
            public async Task WhenWithNightMode_ThenReturnIsDisabled()
            {
                var result = await _sut.GetEqAsync(EqType.NightMode);

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class SetEqAsync : RenderingControlServiceTest
        {
            [Test]
            public async Task WhenWithDialogLevel_AndDisable_ThenIsDisabled()
            {
                await _sut.SetEqAsync(EqType.DialogLevel, false);

                var result = await _sut.GetEqAsync(EqType.DialogLevel);

                Assert.That(result, Is.False);
            }

            [Test]
            public async Task WhenWithDialogLevel_AndEnable_ThenIsEnabled()
            {
                await _sut.SetEqAsync(EqType.DialogLevel, true);

                var result = await _sut.GetEqAsync(EqType.DialogLevel);

                Assert.That(result, Is.True);
            }

            [Test]
            public async Task WhenWithNightMode_AndDisable_ThenIsDisabled()
            {
                await _sut.SetEqAsync(EqType.NightMode, false);

                var result = await _sut.GetEqAsync(EqType.NightMode);

                Assert.That(result, Is.False);
            }

            [Test]
            public async Task WhenWithNightMode_AndEnable_ThenIsEnabled()
            {
                await _sut.SetEqAsync(EqType.NightMode, true);

                var result = await _sut.GetEqAsync(EqType.NightMode);

                Assert.That(result, Is.True);
            }
        }
    }
}