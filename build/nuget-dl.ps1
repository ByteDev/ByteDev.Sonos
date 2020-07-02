# Downloads the lastest version of nuget.exe

$sourceNugetExe = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$targetNugetExe = ".\nuget.exe"

Invoke-WebRequest $sourceNugetExe -OutFile $targetNugetExe

Write-Output "Downloaded latest nuget.exe"

# Print the version details of nuget.exe
& .\nuget.exe help | select -First 1