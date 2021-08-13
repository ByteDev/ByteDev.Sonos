#addin "nuget:?package=Cake.Incubator&version=6.0.0"
#addin "nuget:?package=Cake.Powershell&version=1.0.1"
#tool "nuget:?package=NUnit.ConsoleRunner&version=3.12.0"
#tool "nuget:?package=GitVersion.CommandLine&version=5.6.10"
#load "ByteDev.Utilities.cake"

var solutionName = "ByteDev.Sonos";
var projName = "ByteDev.Sonos";

// var solutionFilePath = "../" + solutionName + ".sln";
var solutionFilePath = "../ByteDev.Sonos-build.sln";

var nuspecFilePath = projName + ".nuspec";

var target = Argument("target", "Default");

var artifactsDirectory = Directory("../artifacts");
var nugetDirectory = artifactsDirectory + Directory("NuGet");

var configuration = GetBuildConfiguration();

Information("Configurtion: " + configuration);


Task("Clean")
    .Does(() =>
	{
		CleanDirectory(artifactsDirectory);
	
		CleanBinDirectories();
		CleanObjDirectories();
	});

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
		var settings = new NuGetRestoreSettings
		{
			Source = new[] { "https://api.nuget.org/v3/index.json" }
		};

		NuGetRestore(solutionFilePath, settings);
    });

Task("Build")
	.IsDependentOn("Restore")
    .Does(() =>
	{	
		var settings = new DotNetCoreBuildSettings()
        {
            Configuration = configuration
        };

        DotNetCoreBuild(solutionFilePath, settings);
	});

Task("UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
	{
		var settings = new DotNetCoreTestSettings()
		{
			Configuration = configuration,
			NoBuild = true
		};

		DotNetCoreUnitTests(settings);
	});
	
Task("CreateNuGetPackages")
    .IsDependentOn("UnitTests")
    .Does(() =>
    {
		var nugetVersion = GetNuGetVersion();

		var nugetSettings = new NuGetPackSettings 
		{
			Version = nugetVersion,
			OutputDirectory = nugetDirectory
		};
                
		NuGetPack(nuspecFilePath, nugetSettings);
    });

   
Task("Default")
    .IsDependentOn("CreateNuGetPackages");

RunTarget(target);
