$BaseDir = Split-Path (Resolve-Path $MyInvocation.MyCommand.Path)

mkdir "$BaseDir\Artifacts" -Force

& "$BaseDir\.NuGet\NuGet.exe" Pack CertiPay.Payroll.Common.nuspec -Properties Configuration=Release -OutputDirectory "$BaseDir\artifacts\"