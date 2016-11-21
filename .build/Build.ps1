param (
	## The build configuration, i.e. Debug/Release
	[string]$Configuration = 'Debug'
)

$ErrorActionPreference = "Stop"

$Here = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"

$SolutionRoot = (Split-Path -parent $Here)

$DotNet = "${env:ProgramFiles}\dotnet\dotnet.exe"

& $DotNet build */**/project.json --configuration $Configuration

EXIT $LASTEXITCODE