function Create-Directory([string[]] $Path) {
  if (!(Test-Path -Path $Path)) {
    New-Item -Path $Path -Force -ItemType "Directory" | Out-Null
  }
}

function Copy-File([string[]] $Path, [string] $Destination, [switch] $Force) {
  if (!(Test-Path -Path $Destination)) {
    New-Item -Path $Destination -Force:$Force -ItemType "Directory" | Out-Null
  }
  Copy-Item -Path $Path -Destination $Destination -Force:$Force
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

  $LatestRelease = Invoke-RestMethod -Headers @{ 'Accept'='application/vnd.github+json'} -Uri https://api.github.com/repos/libsdl-org/SDL_ttf/releases/latest
  $LatestVersion = $LatestRelease.name
  $LatestAsset = $LatestRelease.assets |? { $_.name -Like "SDL2_ttf-devel-*-VC.zip" }
  $LatestAssetName = $LatestAsset.name
  $BrowserDownloadUrl = $LatestAsset.browser_download_url

  $PackageVersion = $LatestVersion

  if ($env:GITHUB_RUN_ID) {
    if (-not $env:EXCLUDE_RUN_ID_FROM_PACKAGE) {
      $PackageVersion = "$LatestVersion-$($env:GITHUB_RUN_ID)"
    }
  }

  $ZipDownloadPath = Join-Path $DownloadsDir $LatestAssetName

  if (!(Test-Path $ZipDownloadPath)) {
    Write-Host "Downloading SDL2_ttf development libraries version '$LatestVersion' from '$BrowserDownloadUrl'..." -ForegroundColor Yellow
    Invoke-WebRequest -Uri $BrowserDownloadUrl -OutFile $ZipDownloadPath
  }

  Write-Host "Extracting SDL2_ttf development libraries to '$DownloadsDir'..." -ForegroundColor Yellow
  $ExpandedFiles = Expand-Archive -Path $ZipDownloadPath -DestinationPath $DownloadsDir -Force -Verbose *>&1

  Write-Host "Staging SDL2_ttf development libraries to '$StagingDir'..." -ForegroundColor Yellow
  Copy-Item -Path $PackagesDir\libsdl2ttf -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2ttf.runtime.win-x64 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2ttf.runtime.win-x86 -Destination $StagingDir -Force -Recurse

  $ExpandedFiles | Foreach-Object {
    if ($_.message -match "Created '(.*)'.*") {
      $ExpandedFile = $Matches[1]
        
      if (($ExpandedFile -like '*\CHANGES.txt') -or
          ($ExpandedFile -like '*\LICENSE.txt') -or
          ($ExpandedFile -like '*\README.txt')) {
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf -Force
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x64 -Force
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x86 -Force
      }
      elseif ($ExpandedFile -like '*\docs\*.md') {
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf\docs -Force
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x64\docs -Force
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x86\docs -Force
      }
      elseif ($ExpandedFile -like '*\include\*.h') {
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf\lib\native\include -Force
      }
      elseif (($ExpandedFile -like '*\lib\x64\*.dll') -or ($ExpandedFile -like '*\lib\x64\*.txt')) {
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x64\runtimes\win-x64\native -Force
      }
      elseif (($ExpandedFile -like '*\lib\x86\*.dll') -or ($ExpandedFile -like '*\lib\x86\*.txt')) {
        Copy-File -Path $ExpandedFile -Destination $StagingDir\libsdl2ttf.runtime.win-x86\runtimes\win-x86\native -Force
      }
    }
  }

  Write-Host "Replace variable `$version`$ in runtime.json with value '$PackageVersion'..." -ForegroundColor Yellow
  $RuntimeContent = Get-Content "$StagingDir\libsdl2ttf\runtime.json" -Raw
  $RuntimeContent = $RuntimeContent.replace('$version$', $PackageVersion)
  Set-Content $StagingDir\libsdl2ttf\runtime.json $RuntimeContent

  Write-Host "Build 'libsdl2ttf' package..." -ForegroundColor Yellow
  & nuget pack $StagingDir\libsdl2ttf\libsdl2ttf.nuspec -Properties version=$PackageVersion -OutputDirectory $ArtifactsPkgDir
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2ttf.nuspec'"
  }

  Write-Host "Build 'libsdl2ttf.runtime.win-x64' package..." -ForegroundColor Yellow
  & nuget pack $StagingDir\libsdl2ttf.runtime.win-x64\libsdl2ttf.runtime.win-x64.nuspec -Properties version=$PackageVersion -OutputDirectory $ArtifactsPkgDir
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2ttf.runtime.win-x64.nuspec'"
  }

  Write-Host "Build 'libsdl2ttf.runtime.win-x86' package..." -ForegroundColor Yellow
  & nuget pack $StagingDir\libsdl2ttf.runtime.win-x86\libsdl2ttf.runtime.win-x86.nuspec -Properties version=$PackageVersion -OutputDirectory $ArtifactsPkgDir
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
