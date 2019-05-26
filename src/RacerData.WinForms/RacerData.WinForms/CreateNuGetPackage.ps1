# Copy file to project directory
# Add post-build event to project: powershell.exe $(ProjectDir)CreateNuGetPackage.ps1 -name $(TargetName) -version 1.0.8 -projectDir $(ProjectDir)

Param (
	[Parameter(Mandatory=$true)][string]$name,
	[Parameter(Mandatory=$true)][string]$assembly,
	[Parameter(Mandatory=$true)][string]$projectDir
)

$fullVersion = (Get-Item $assembly).VersionInfo.FileVersion
$version = $fullVersion.Substring(0, $fullVersion.LastIndexOf('.'))

$localPackageFolder = (Join-Path $projectDir "package\")

Get-ChildItem -Path $localPackageFolder -Include *.nupkg -File -Recurse | foreach { $_.Delete()}

nuget pack "$projectDir$name.nuspec" -Version $version -OutputDirectory $localPackageFolder -IncludeReferencedProjects

$packageFile = Get-ChildItem -Path $localPackageFolder -Name

$packageFilePath = (Join-Path $localPackageFolder $packageFile)

nuget add $packageFilePath -Source C:\Users\Rob\source\repos\RacerData\packages\
