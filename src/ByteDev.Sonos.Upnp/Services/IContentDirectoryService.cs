using System.Threading.Tasks;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Upnp.Services
{
    public interface IContentDirectoryService
    {
        Task RefreshShareIndexAsync();
        Task<string> GetLastIndexChangeAsync();
        Task<bool> GetShareIndexInProgressAsync();
        Task<BrowseResponse> BrowseAsync(int startIndex = 0, int requestedCount = 100);
    }
}