# Publishes all nuget packages (.nupkg files) in a folder to nuget.org

$nupkgExten = ".nupkg"
$nupkgFileFolder = "../artifacts/NuGet/"
$nugetExe = ".\tools\nuget.exe"

$dir = get-childitem $nupkgFileFolder
$files = $dir | where {$_.extension -eq $nupkgExten} 

if($files.Count -eq 0) {
    Write-Output "No $nupkgExten files could be found."
    exit
}

$count = $files.Count

Write-Output "$count $nupkgExten files found:"

foreach($file in $files) {
    Write-Output $file.Name
}

Write-Output ""
$key = Read-Host -Prompt "Please enter nuget.org API key"

foreach($file in $files) {
    $filePath = $nupkgFileFolder + $file.Name

    Write-Output ""
    Write-Output "Publishing '$filePath' to nuget.org API..."
	
    & $nugetExe push $filePath $key -Source https://api.nuget.org/v3/index.json

    if($LASTEXITCODE -eq 0) {
        Write-Output "Publish '$filePath' successful."
    }
    else {
        Write-Output "Publish '$filePath' unsuccessful."
    }
}