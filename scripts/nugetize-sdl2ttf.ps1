function Create-Directory([string[]] $Path) {
  if (!(Test-Path -Path $Path)) {
    New-Item -Path $Path -Force -ItemType "Directory" | Out-Null
  }
}

try {
  $RepoRoot = Join-Path -Path $PSScriptRoot -ChildPath ".."

  $PackagesDir = Join-Path -Path $RepoRoot -ChildPath "packages"

  $ArtifactsDir = Join-Path -Path $RepoRoot -ChildPath "artifacts"
  Create-Directory -Path $ArtifactsDir

  $ArtifactsPkgDir = Join-Path $ArtifactsDir -ChildPath "pkg"
  Create-Directory -Path $ArtifactsPkgDir

  $StagingDir = Join-Path -Path $RepoRoot -ChildPath "staging"
  Create-Directory $StagingDir

  $DownloadsDir = Join-Path -Path $RepoRoot -ChildPath "downloads"
  Create-Directory -Path $DownloadsDir

  $Releases = Invoke-WebRequest https://www.libsdl.org/projects/SDL_ttf/release/ -UseBasicParsing

  $Hrefs = $Releases.Links.href |? { $_ -like "SDL2_ttf-devel-*-VC.zip" }
  $LatestHref = ($Hrefs | Sort-Object -Descending {[System.Version]($_ | Select-String '((?:\d{1,3}\.){2}\d{1,3})').Matches[0].Groups[1].Value})[0]
  $LatestVersion = ($LatestHref | Select-String '((?:\d{1,3}\.){2}\d{1,3})').Matches[0].Groups[1].Value
  $ZipDownloadPath = Join-Path $DownloadsDir $LatestHref
  $DownloadPath = Join-Path -Path $DownloadsDir -ChildPath "SDL2_ttf-$LatestVersion"

  $PackageVersion = $LatestVersion

  if ($env:GITHUB_RUN_ID) {
    if (-not $env:EXCLUDE_RUN_ID_FROM_PACKAGE) {
      $PackageVersion = "$LatestVersion-$($env:GITHUB_RUN_ID)"
    }
  }

  if (!(Test-Path $DownloadPath))
  {
    if (!(Test-Path $ZipDownloadPath)) {
      Write-Host "Downloading SDL2_TTF development libraries version $LatestVersion to $ZipDownloadPath..." -ForegroundColor Yellow
      (New-Object System.Net.WebClient).DownloadFile("https://www.libsdl.org/projects/SDL_ttf/release/SDL2_ttf-devel-$LatestVersion-VC.zip", $ZipDownloadPath)
    }

    Write-Host "Extracting SDL2_TTF development libraries version $LatestVersion..." -ForegroundColor Yellow
    Expand-Archive -Path $ZipDownloadPath -DestinationPath $DownloadsDir -Force
  }

  Copy-Item -Path $PackagesDir\libsdl2ttf -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2ttf.runtime.win-x64 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2ttf.runtime.win-x86 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path "$DownloadPath\include" -Destination "$StagingDir\libsdl2ttf" -Force -Recurse
  Copy-Item -Path "$DownloadPath\lib\x64\SDL2_ttf.dll" -Destination "$StagingDir\libsdl2ttf.runtime.win-x64" -Force
  Copy-Item -Path "$DownloadPath\lib\x86\SDL2_ttf.dll" -Destination "$StagingDir\libsdl2ttf.runtime.win-x86" -Force

  $RuntimeContent = Get-Content "$StagingDir\libsdl2ttf\runtime.json" -Raw
  $RuntimeContent = $RuntimeContent.replace('$version$', $PackageVersion)
  Set-Content "$StagingDir\libsdl2ttf\runtime.json" $RuntimeContent

  & nuget pack "$StagingDir\libsdl2ttf\libsdl2ttf.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2ttf.nuspec'"
  }

  & nuget pack "$StagingDir\libsdl2ttf.runtime.win-x64\libsdl2ttf.runtime.win-x64.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2ttf.runtime.win-x64.nuspec'"
  }

  & nuget pack "$StagingDir\libsdl2ttf.runtime.win-x86\libsdl2ttf.runtime.win-x86.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2ttf.runtime.win-x86.nuspec'"
  }
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
