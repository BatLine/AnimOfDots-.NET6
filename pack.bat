@echo off
setlocal
set OUT_DIR=%~dp0nupkgs
if not exist "%OUT_DIR%" mkdir "%OUT_DIR%"

dotnet build AnimOfDots\AnimOfDots.csproj -c Release -p:GeneratePackageOnBuild=false
dotnet build AnimOfDots.WPF\AnimOfDots.WPF.csproj -c Release -p:GeneratePackageOnBuild=false

dotnet pack AnimOfDots\AnimOfDots.csproj -c Release -o "%OUT_DIR%" --no-build
dotnet pack AnimOfDots.WPF\AnimOfDots.WPF.csproj -c Release -o "%OUT_DIR%" --no-build

echo Packages written to %OUT_DIR%
endlocal
pause