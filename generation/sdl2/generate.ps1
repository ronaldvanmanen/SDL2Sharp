$allPackages = (dotnet list ..\..\sources\SDL2Sharp.Interop\SDL2Sharp.Interop.csproj package)
$libsdl2Package = $allPackages | Select-String -Pattern '^ +> libsdl2 +'
$libsdl2VersionFound = $libsdl2Package -match '^ +> libsdl2 +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)'
if (-not $libsdl2VersionFound)
{
  throw "libsdl2 version not found"
}

$libsdl2Version = $Matches.resolvedVersion

& dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp" --file-directory "$HOME\.nuget\packages\libsdl2\$libsdl2Version\lib\native\include"
