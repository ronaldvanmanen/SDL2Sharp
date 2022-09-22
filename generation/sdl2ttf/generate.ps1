$allPackages = (dotnet list ..\..\sources\SDL2Sharp.Interop\SDL2Sharp.Interop.csproj package)

$libsdl2Package = $allPackages | Select-String -Pattern '^ +> libsdl2 +'
$libsdl2VersionFound = $libsdl2Package -match '^ +> libsdl2 +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)'
if ($libsdl2VersionFound)
{
  $libsdl2Version = $Matches.resolvedVersion
}
else
{
  throw "libsdl2 version not found"
}

$libsdl2ttfPackage = $allPackages | Select-String -Pattern '^ +> libsdl2ttf +'
$libsdl2ttfVersionFound = $libsdl2ttfPackage -match '^ +> libsdl2ttf +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)'
if ($libsdl2ttfVersionFound)
{
  $libsdl2ttfVersion = $Matches.resolvedVersion
}
else
{
  throw "libsdl2ttf version not found"
}

& dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp" --file-directory "$HOME\.nuget\packages\libsdl2ttf\$libsdl2ttfVersion\lib\native\include" --include-directory "$HOME\.nuget\packages\libsdl2\$libsdl2Version\lib\native\include"
