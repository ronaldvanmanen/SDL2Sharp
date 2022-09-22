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

$libsdl2imagePackage = $allPackages | Select-String -Pattern '^ +> libsdl2image +'
$libsdl2imageVersionFound = $libsdl2imagePackage -match '^ +> libsdl2image +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)'
if ($libsdl2imageVersionFound)
{
  $libsdl2imageVersion = $Matches.resolvedVersion
}
else
{
  throw "libsdl2image version not found"
}

& dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp" --file-directory "$HOME\.nuget\packages\libsdl2image\$libsdl2imageVersion\lib\native\include" --include-directory "$HOME\.nuget\packages\libsdl2\$libsdl2Version\lib\native\include"
