﻿using System.Threading.Tasks;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Upnp.Services
{
    public interface IAvTransportService
    {
        Task StopAsync();
        Task PauseAsync();
        Task PlayAsync(int playSpeed = 1);
        Task NextTrackAsync();
        Task PreviousTrackAsync();

        Task SeekAsync(SeekUnit seekUnit, string position);

        Task ClearQueueAsync();
        Task RemoveTrackFromQueueAsync(QueueItemId queueItemId);
        Task AddTrackToQueueAsync(string enqueuedUri, string enqueuedUriMetaData,  EnqueueAsNextType next);
        Task AddSpotifyTrackToQueueAsync(string spotifyId);
        Task SetPlayModeAsync(PlayMode playMode);

        /// <summary>
        /// Get information about media
        /// </summary>
        Task<GetMediaInfoResponse> GetMediaInfoAsync();

        /// <summary>
        /// Gets current track info
        /// </summary>
        Task<GetPositionInfoResponse> GetPositionInfoAsync();

        /// <summary>
        /// Get status about the player
        /// </summary>
        Task<GetTransportInfoResponse> GetTransportInfoAsync();

        /// <summary>
        /// Get PlayMode about player
        /// </summary>
        Task<GetTransportSettingsResponse> GetTransportSettingsAsync();
    }
}