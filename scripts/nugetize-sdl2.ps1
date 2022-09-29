function Create-Directory([string] $Path) {
  if (!(Test-Path -Path $Path)) {
    New-Item -Path $Path -Force -ItemType "Directory" | Out-Null
  }
}

function Copy-File([string] $Path, [string] $Destination, [switch] $Force) {
  Create-Directory $Destination

  if ($Force) {
    Copy-Item -Path $Path -Destination $Destination -Force
  } else {
    Copy-Item -Path $Path -Destination $Destination
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

  $LatestRelease = Invoke-RestMethod -Headers @{ 'Accept'='application/vnd.github+json'} -Uri https://api.github.com/repos/libsdl-org/SDL/releases/latest
  $LatestVersion = $LatestRelease.name
  $LatestAsset = $LatestRelease.assets |? { $_.name -Like "SDL2-devel-*-VC.zip" }
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
    Write-Host "Downloading SDL2 development libraries version '$LatestVersion' from '$BrowserDownloadUrl'..." -ForegroundColor Yellow
    Invoke-WebRequest -Uri $BrowserDownloadUrl -OutFile $ZipDownloadPath
  }

  Write-Host "Extracting SDL2 development libraries to '$DownloadsDir'..." -ForegroundColor Yellow
  $ExpandedFiles = Expand-Archive -Path $ZipDownloadPath -DestinationPath $DownloadsDir -Force -Verbose *>&1

  Write-Host "Staging SDL2 development libraries to '$StagingDir'..." -ForegroundColor Yellow
  Copy-Item -Path $PackagesDir\libsdl2 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2.runtime.win-x64 -Destination $StagingDir -Force -Recurse
  Copy-Item -Path $PackagesDir\libsdl2.runtime.win-x86 -Destination $StagingDir -Force -Recurse
  $ExpandedFiles | Foreach-Object {
    if ($_.message -match "Created '(.*)'.*") {
      $ExpandedFile = $Matches[1]
        
      if ($ExpandedFile -like '*\include\*.h') {
        Write-Host "Staging include file '$ExpandedFile'..."
        Copy-File -Path $ExpandedFile -Destination "$StagingDir\libsdl2\lib\native\include" -Force
      }
      elseif ($ExpandedFile -like '*\lib\x64\*.dll') {
        Write-Host "Staging x64 lib '$ExpandedFile'..."
        Copy-File -Path $ExpandedFile -Destination "$StagingDir\libsdl2.runtime.win-x64\runtimes\win-x64\native" -Force
      }
      elseif ($ExpandedFile -like '*\lib\x86\*.dll') {
        Write-Host "Staging x86 lib '$ExpandedFile'..."
        Copy-File -Path $ExpandedFile -Destination "$StagingDir\libsdl2.runtime.win-x86\runtimes\win-x86\native" -Force
      }
    }
  }

  $RuntimeContent = Get-Content "$StagingDir\libsdl2\runtime.json" -Raw
  $RuntimeContent = $RuntimeContent.replace('$version$', $PackageVersion)
  Set-Content "$StagingDir\libsdl2\runtime.json" $RuntimeContent

  & nuget pack "$StagingDir\libsdl2\libsdl2.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2.nuspec'"
  }
  
  & nuget pack "$StagingDir\libsdl2.runtime.win-x64\libsdl2.runtime.win-x64.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2.runtime.win-x64.nuspec'"
  }
  
  & nuget pack "$StagingDir\libsdl2.runtime.win-x86\libsdl2.runtime.win-x86.nuspec" -Properties version=$PackageVersion -OutputDirectory "$ArtifactsPkgDir"
  if ($LastExitCode -ne 0) {
    throw "'nuget pack' failed for 'libsdl2.runtime.win-x86.nuspec'"
  }
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
