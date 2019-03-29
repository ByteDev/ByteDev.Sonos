[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Sonos.svg)](https://www.nuget.org/packages/ByteDev.Sonos)

# ByteDev.Sonos

Set of classes and tools to help control Sonos devices.

## Installation

ByteDev.Sonos has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Sonos is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Sonos`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Sonos/).

## Code

The repo can be cloned from git bash:

`git clone https://github.com/ByteDev/ByteDev.Sonos`

## Usage

At the highest level there are two main classes in the ByteDev.Sonos assembly: `SonosController` and `SonosDeviceService`.

### SonosController

SonosController allows you to control the speaker, aspects of it's queue, and operations on it's current track.

```csharp
SonosController controller = new SonosControllerFactory().Create("192.168.1.100");

SonosVolume volume = await controller.GetVolumeAsync();

volume.Increase(10);

await controller.SetVolumeAsync(volume);
```

### SonosDeviceService

SonosDeviceService allows you to get details about a particular Sonos device and even restart the device.

```csharp
var service = new SonosDeviceService();

var sonosDevice = await service.GetDeviceAsync("192.168.1.100");

var httpResponseMessage = await service.RebootAsync("192.168.1.100");
```
