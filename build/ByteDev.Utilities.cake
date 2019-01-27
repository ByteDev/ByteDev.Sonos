string GetBuildConfiguration()
{
	if(HasArgument("Configuration"))
	{
		return Argument<string>("Configuration");
	}

	return EnvironmentVariable("Configuration") != null ? 
		EnvironmentVariable("Configuration") : 
		"Release";
}

string GetNuGetVersion()
{
	var settings = new GitVersionSettings
	{
		OutputType = GitVersionOutput.Json
	};

	GitVersion versionInfo = GitVersion(settings);

	Information("GitVersion:");
	Information(versionInfo.Dump<GitVersion>());

	return versionInfo.NuGetVersion;
}

void CleanObjDirectories()
{
	var objSrcDirs = GetDirectories("../src/**/obj");
	
	CleanDirectories(objSrcDirs);
}

void CleanBinDirectories()
{	
	var binSrcDirs = GetDirectories("../src/**/bin");

	CleanDirectories(binSrcDirs);
}

FilePathCollection GetUnitTestProjFiles()
{
	return GetFiles("../src/*.UnitTests/**/*.csproj");
}

FilePathCollection GetIntTestProjFiles()
{
	return GetFiles("../src/*.IntTests/**/*.csproj");
}

void DotNetCoreTests(FilePathCollection projects, DotNetCoreTestSettings settings)
{
	foreach(var project in projects)
	{
		DotNetCoreTest(project.FullPath, settings);
	}
}

void DotNetCoreUnitTests(DotNetCoreTestSettings settings)
{
	var projects = GetUnitTestProjFiles();

	DotNetCoreTests(projects, settings);
}

void DotNetCoreIntTests(DotNetCoreTestSettings settings)
{
	var projects = GetIntTestProjFiles();

	DotNetCoreTests(projects, settings);
}

