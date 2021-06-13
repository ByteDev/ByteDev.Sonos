using System;
using ByteDev.Sonos.Models;
using ByteDev.Sonos.Upnp.Services;
using ByteDev.Sonos.Upnp.Services.Models;

namespace ByteDev.Sonos.Console
{
    public class SonosOperations
    {
        private const int DefaultInterval = 10000;

        private readonly string _ipAddress;
        private readonly SonosController _sonosController;
        
        public SonosOperations(string ipAddress)
        {
            _ipAddress = ipAddress;
            _sonosController = CreateSonosController(_ipAddress);
        }

        public SonosVolume GetVolume()
        {
            return _sonosController.GetVolumeAsync().Result;
        }

        public void SetVolume(int value)
        {
            _sonosController.SetVolumeAsync(new SonosVolume(value)).Wait();
        }

        public void SetVolumeForever(int value)
        {
            var newVolume = new SonosVolume(value);
            
            Print($"Forcing volume to {newVolume.Value} on {_ipAddress}");

            var setCounter = 0;

            while (true)
            {
                var currentVolume = _sonosController.GetVolumeAsync().Result;

                Print($"Volume is {currentVolume.Value}");

                if (currentVolume.Value != newVolume.Value)
                {
                    _sonosController.SetVolumeAsync(newVolume).Wait();
                    setCounter++;
                    Print($"Set volume to {newVolume.Value} ({setCounter} times)");
                }
                System.Threading.Thread.Sleep(DefaultInterval);
            }
        }

        public bool GetIsPlaying()
        {
            return _sonosController.GetIsPlayingAsync().Result;
        }

        public void Play()
        {
            _sonosController.PlayAsync().Wait();
        }

        public void Stop()
        {
            _sonosController.StopAsync().Wait();
        }

        public void StopForever()
        {
            Print($"Forcing stop on {_ipAddress}");

            var setCounter = 0;

            while (true)
            {
                var isPlaying = GetIsPlaying();

                Print($"IsPlaying: {isPlaying}");

                if (isPlaying)
                {
                    _sonosController.StopAsync().Wait();
                    setCounter++;
                    Print($"Stopped device ({setCounter} times)");
                }
                System.Threading.Thread.Sleep(DefaultInterval);
            }
        }

        public void SetPlayMode(string value)
        {
            //PlayMode mode = new PlayMode(PlayModeType.RepeatOne); 
            PlayMode mode = new PlayMode(value); 

            _sonosController.SetPlayModeAsync(mode).Wait(); 
        }

        private SonosController CreateSonosController(string ipAddress)
        {
            return new SonosController(new AvTransportService(ipAddress),
                new RenderingControlService(ipAddress),
                new ContentDirectoryService(ipAddress));
        }

        private static void Print(string message)
        {
            System.Console.WriteLine($"{DateTime.Now} {message}");
        }
    }
}