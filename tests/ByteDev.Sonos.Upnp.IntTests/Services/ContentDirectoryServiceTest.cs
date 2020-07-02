using System.Threading.Tasks;
using ByteDev.Sonos.Testing;
using ByteDev.Sonos.Upnp.Services;
using NUnit.Framework;

namespace ByteDev.Sonos.Upnp.IntTests.Services
{
    [TestFixture]
    public class ContentDirectoryServiceTest
    {
        private ContentDirectoryService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ContentDirectoryService(TestSpeaker.IpAddress);
        }

        [TestFixture]
        public class RefreshShareIndexAsync : ContentDirectoryServiceTest
        {
            [Test]
            public async Task WhenHasLibrary_ThenRefresh()
            {
                await _sut.RefreshShareIndexAsync();
            }
        }

        [TestFixture]
        public class GetShareIndexInProgressAsync : ContentDirectoryServiceTest
        {
            [Test]
            public async Task WhenIndexNotInProgress_ThenReturnFalse()
            {
                var result = await _sut.GetShareIndexInProgressAsync();

                Assert.That(result, Is.False);
            }
        }

        [TestFixture]
        public class GetLastIndexChangeAsync : ContentDirectoryServiceTest
        {
            [Test]
            public async Task WhenHasLibrary_ThenGetDateTimeLastIndex()
            {
                var result = await _sut.GetLastIndexChangeAsync();

                Assert.That(result.Length, Is.GreaterThan(0));
            }
        }

        [TestFixture]
        public class BrowseAsync : ContentDirectoryServiceTest
        {
            [Test]
            public async Task WhenQueueHasItems_ThenReturnsItemDetails()
            {
                var result = await _sut.BrowseAsync();

                Assert.That(result.NumberReturned, Is.GreaterThan(0));
                Assert.That(result.TotalMatches, Is.GreaterThan(0));
                Assert.That(result.Items.Count, Is.GreaterThan(0));
            }
        }
    }
}