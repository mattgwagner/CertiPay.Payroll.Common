param (
	## The build target, i.e. Build, Rebuild, Clean
	[string]$Target = 'Build',

	## The build configuration, i.e. Debug/Release
	[string]$Configuration = 'Debug'
)

$ErrorActionPreference = "Stop"

$Here = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"

$SolutionRoot = (Split-Path -parent $Here)

$SolutionFile = Join-Path $SolutionRoot "CertiPay.Payroll.Common"

# Bootstap ensures we have what we need to build the project

$DotNet = "${env:ProgramFiles}\dotnet\dotnet.exe"

# Build the solution, packaging the files if requested

# dotnet.exe build "C:\Users\Administrator\Documents\GitHub\certipay.payroll.common\CertiPay.Payroll.Common" --configuration Debug --no-dependencies --no-incremental

Write-Output "Running build target $Target for $Configuration"

& $DotNet build $SolutionFile --configuration $Configuration

EXIT $LASTEXITCODE