try {
  $PackageList = (dotnet list ..\..\sources\SDL2Sharp.Interop\SDL2Sharp.Interop.csproj package)

  $SDL2PackageName = "SDL2"
  $SDL2Package = $PackageList | Select-String -Pattern "^ +> $SDL2PackageName +"
  $SDL2PackageVersionFound = $SDL2Package -match "^ +> $SDL2PackageName +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)"
  if (-not $SDL2PackageVersionFound)
  {
    throw "$SDL2PackageName version not found"
  }

  $SDL2PackageVersion = $Matches.resolvedVersion

  $SDL2ImagePackageName = 'SDL2_image'
  $SDL2ImagePackage = $PackageList | Select-String -Pattern "^ +> $SDL2ImagePackageName +"
  $SDL2ImagePackageVersionFound = $SDL2ImagePackage -match "^ +> $SDL2ImagePackageName +(?<requestedVersion>[^ ]+) +(?<resolvedVersion>[^ ]+)"
  if (-not $SDL2ImagePackageVersionFound)
  {
    throw "$SDL2ImagePackageName version not found"
  }

  $SDL2ImagePackageVersion = $Matches.resolvedVersion

  & dotnet tool run ClangSharpPInvokeGenerator "@settings.rsp" --file-directory "$HOME\.nuget\packages\$SDL2ImagePackageName\$SDL2ImagePackageVersion\lib\native\include" --include-directory "$HOME\.nuget\packages\$SDL2PackageName\$SDL2PackageVersion\lib\native\include"
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
