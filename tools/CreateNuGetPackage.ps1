# Add post-build event to project: powershell.exe $(SolutionDir)..\..\tools\CreateNuGetPackage.ps1 -name $(TargetName) -assembly "$(TargetPath)" -projectDir $(ProjectDir)

Param (
	[Parameter(Mandatory=$true)][string]$name,
	[Parameter(Mandatory=$true)][string]$assembly,
	[Parameter(Mandatory=$true)][string]$projectDir
)

$fullVersion = (Get-Item $assembly).VersionInfo.FileVersion
$version = $fullVersion.Substring(0, $fullVersion.LastIndexOf('.'))

# up 3 directories from project, then down to 'packages'
$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$packagesDir  = Join-Path -Path $scriptDir -ChildPath ..\packages\

$localPackageFolder = (Join-Path $projectDir "package\")

Get-ChildItem -Path $localPackageFolder -Include *.nupkg -File -Recurse | foreach { $_.Delete()}

nuget pack "$projectDir$name.nuspec" -Version $version -OutputDirectory $localPackageFolder -IncludeReferencedProjects | Out-Null

$packageFile = Get-ChildItem -Path $localPackageFolder -Name

$packageFilePath = (Join-Path $localPackageFolder $packageFile)



nuget add $packageFilePath -Source C:\Users\Rob\source\repos\RacerData\packages\
