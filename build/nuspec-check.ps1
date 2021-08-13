# ==============================
# Check a nuspec file has the required dependencies listed based on a .NET project file
#
# Script assumes proj file is in new .NET format
# ==============================

param(
    [Parameter(Position=0,Mandatory=1)]
    [string]$projFile,                      # Path to the .csproj file
    [Parameter(Position=1,Mandatory=1)]
    [string]$nuspecFile                     # Path to the nuspec file
)

# ==============================

function CheckParams()
{
    if (-Not(Test-Path $projFile))
    {
        Write-Error "Project file $projFile does not exist"
        exit
    }

    if (-Not(Test-Path $nuspecFile))
    {
        Write-Error "Nuspec file $nuspecFile does not exist"
        exit
    }
}

function WriteHeader()
{
    Write-Output ""
    Write-Output "========================================"
    Write-Output "Nuspec file checker"
    Write-Output "========================================"
    Write-Output ""
    Write-Output "Project file: $projFile"
    Write-Output "Nuspec file: $nuspecFile"
    Write-Output ""
    Write-Output "Checking project PackageReferences exist in .nuspec file..."
    Write-Output ""    
}

function WriteStatus($foundStatus, $packageName, $packageVersion)
{
    switch ($foundStatus)
    {
        0 { Write-Output "$packageName $packageVersion - found" }
        1 { Write-Error "$packageName $packageVersion - wrong version!" }
        2 { Write-Error "$packageName $packageVersion - not found!" }
    }
}

# ==============================

WriteHeader
CheckParams

[XML]$projXml = Get-Content $projFile

[XML]$nuspecXml = Get-Content $nuspecFile
$namespace = $nuspecXml.DocumentElement.NamespaceURI
$nuspecNs = New-Object System.Xml.XmlNamespaceManager($nuspecXml.NameTable)
$nuspecNs.AddNamespace("ns", $namespace)

$errorCount = 0

$projXml.SelectNodes("//PackageReference") | foreach {
    
    # 0 = Found, 1 = Name found (wrong version), 2 = Not found
    $foundStatus = 2

    $projName = $_.Include
    $projVersion = $_.Version

    $nuspecXml.SelectNodes("//ns:dependency", $nuspecNs) | foreach {
        $nuspecName = $_.id
        $nuspecVersion = $_.version

        if ($projName -eq $nuspecName)
        {
            $foundStatus = 1

            if ($projVersion -eq $nuspecVersion)
            {
                $foundStatus = 0
            }
        }
    }

    if ($foundStatus -ne 0)
    {
        $errorCount++
    }

    WriteStatus $foundStatus $projName $projVersion
} 

Write-Output ""
Write-Output "$errorCount errors."
