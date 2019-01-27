# ByteDev.Sonos

Set of classes and tools to help control Sonos devices.

## Usage

At the highest level there are two main classes in the ByteDev.Sonos assembly: `SonosController` and `SonosDeviceService`.

## SonosController

SonosController allows you to control the speaker, aspects of it's queue, and operations on it's current track.

```csharp
SonosController controller = new SonosControllerFactory().Create("192.168.1.100");

SonosVolume volume = await controller.GetVolumeAsync();

volume.Increase(10);

await controller.SetVolumeAsync(volume);
```

## SonosDeviceService

```csharp
var service = new SonosDeviceService();

var httpMessage = await service.RebootAsync("192.168.1.100");
```
