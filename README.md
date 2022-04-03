[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Sonos?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Sonos/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Sonos.svg)](https://www.nuget.org/packages/ByteDev.Sonos)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Sonos/blob/master/LICENSE)

# ByteDev.Sonos

Set of classes and tools to help control Sonos devices.

## Installation

ByteDev.Sonos has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Sonos is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Sonos`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Sonos/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Sonos/blob/master/docs/RELEASE-NOTES.md).

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

### Sonos API Documentation

https://svrooij.io/sonos-api-docs/