// SDL2Sharp
//
// Copyright (C) 2021 Ronald van Manen <rvanmanen@gmail.com>
//
// This software is provided 'as-is', without any express or implied
// warranty.  In no event will the authors be held liable for any damages
// arising from the use of this software.
// 
// Permission is granted to anyone to use this software for any purpose,
// including commercial applications, and to alter it and redistribute it
// freely, subject to the following restrictions:
//
// 1. The origin of this software must not be misrepresented; you must not
//    claim that you wrote the original software. If you use this software
//    in a product, an acknowledgment in the product documentation would be
//    appreciated but is not required.
// 2. Altered source versions must be plainly marked as such, and must not be
//    misrepresented as being the original software.
// 3. This notice may not be removed or altered from any source distribution.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.PowerShell;
using Nuke.Common.Tools.ClangSharpPInvokeGenerator;
using static System.Runtime.InteropServices.RuntimeInformation;
using static Nuke.Common.IO.HttpTasks;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.Tools.PowerShell.PowerShellTasks;

partial interface ISetup : IBuild
{
    private static readonly Dictionary<Version, string> _downloadUris = new()
    {
        { new Version(4, 5, 1), "https://go.microsoft.com/fwlink/?linkid=321335&clcid=0x409" },
        { new Version(4, 5, 2), "https://go.microsoft.com/fwlink/?linkid=397673&clcid=0x409" },
        { new Version(4, 6),    "https://go.microsoft.com/fwlink/?linkid=2099469" },
        { new Version(4, 6, 1), "https://go.microsoft.com/fwlink/?linkid=2099470" },
        { new Version(4, 6, 2), "https://go.microsoft.com/fwlink/?linkid=2099466" },
        { new Version(4, 7),    "https://go.microsoft.com/fwlink/?linkid=2099465" },
        { new Version(4, 7, 1), "https://go.microsoft.com/fwlink/?linkid=2099382" },
        { new Version(4, 7, 2), "https://go.microsoft.com/fwlink/?linkid=874338" },
        { new Version(4, 8),    "https://go.microsoft.com/fwlink/?linkid=2088517" },
        { new Version(4, 8, 1), "https://go.microsoft.com/fwlink/?linkid=2203306" }
    };

    private Tool Bash => ToolResolver.GetPathTool("bash");

    private Tool Chmod => ToolResolver.GetPathTool("chmod");

    private Tool Echo => ToolResolver.GetPathTool("echo");

    private Tool Sudo => ToolResolver.GetPathTool("sudo");

    public Target Setup => _ => _
        .After<IClean>(target => target.Clean)
        .Produces(ArtifactsDirectory / "log" / "*.*")
        .Executes(() =>
        {
            InstallDotNet();
            InstallAzureArtifactsCredentialProvider();
        });

    private void InstallDotNet()
    {
        var targetFrameworkVersions = GetTargetFrameworkVersions();
        foreach (var version in targetFrameworkVersions.Where(version => version.Major >= 5))
        {
            InstallDotNet(version);
        }

        if (IsOSPlatform(OSPlatform.Windows))
        {
            foreach (var version in targetFrameworkVersions.Where(version => version.Major < 5))
            {
                InstallDotNetFramework(version);
            }
        }

        if (IsOSPlatform(OSPlatform.Linux))
        {
            InstallMono();
        }
    }

    private void InstallDotNet(Version version)
    {
        if (IsOSPlatform(OSPlatform.Windows))
        {
            var script = ArtifactsDirectory / "dotnet-install.ps1";
            HttpDownloadFile("https://dot.net/v1/dotnet-install.ps1", script, clientConfigurator: ConfigureHttpClient);
            var installDirectory = ArtifactsDirectory / "dotnet" / Architecture;

            Serilog.Log.Information($"Install latest release of .NET {version}.");
            PowerShell(settings => settings
                .SetExecutionPolicy("ByPass")
                .SetFile(script)
                .SetFileArguments("-Architecture", Architecture, "-Channel", version.ToString(2), "-InstallDir", installDirectory, "-NoPath", "-Version", "latest")
                .SetProcessEnvironmentVariable("DOTNET_CLI_TELEMETRY_OPTOUT", "1")
                .SetProcessEnvironmentVariable("DOTNET_MULTILEVEL_LOOKUP", "1")
                .SetProcessEnvironmentVariable("DOTNET_SKIP_FIRST_TIME_EXPERIENCE", "1")
            );

            Environment.SetEnvironmentVariable("PATH", $"{installDirectory};{Environment.GetEnvironmentVariable("PATH")}");
            Environment.SetEnvironmentVariable("DOTNET_ROOT", installDirectory);
            Environment.SetEnvironmentVariable("DOTNET_EXE", installDirectory / "dotnet.exe");
        }
        else
        {
            var script = ArtifactsDirectory / "dotnet-install.sh";
            HttpDownloadFile("https://dot.net/v1/dotnet-install.sh", script, clientConfigurator: ConfigureHttpClient);
            Chmod($"+x {script}");
            var installDirectory = ArtifactsDirectory / "dotnet" / Architecture;

            var installCommand = $"{script} --architecture {Architecture} --channel {version} --install-dir {installDirectory} --no-path --version latest";
            var enviromentVariables = new Dictionary<string, string>
                {
                    { "DOTNET_CLI_TELEMETRY_OPTOUT", "1" },
                    { "DOTNET_MULTILEVEL_LOOKUP", "1" },
                    { "DOTNET_SKIP_FIRST_TIME_EXPERIENCE", "1" }
                };
            Serilog.Log.Information($"Install latest version of .NET \"{version}\".");
            Bash(installCommand, environmentVariables: enviromentVariables);

            Environment.SetEnvironmentVariable("PATH", $"{installDirectory}:{Environment.GetEnvironmentVariable("PATH")}");
            Environment.SetEnvironmentVariable("DOTNET_ROOT", installDirectory);
            Environment.SetEnvironmentVariable("DOTNET_EXE", installDirectory / "dotnet");
        }
    }

    private void InstallDotNetFramework(Version version)
    {
        if (IsDotNetFrameworkInstalled(version))
        {
            Serilog.Log.Information($"Microsoft .NET Framework {version} Developer Pack or Targeting Pack is already installed.");
        }
        else
        {
            Serilog.Log.Information($"Download Microsoft .NET Framework {version} Developer Pack.");
            if (!_downloadUris.TryGetValue(version, out var downloadUri))
            {
                throw new PlatformNotSupportedException($"Microsoft .NET Framework {version} Developer Pack configuration is missing.");
            }
            var downloadPath = TemporaryDirectory / $"NDP{version}-DevPack-ENU.exe";
            HttpDownloadFile(downloadUri, downloadPath, clientConfigurator: ConfigureHttpClient);
            Serilog.Log.Information($"Install Microsoft .NET Framework {version} Developer Pack.");
            StartProcess(downloadPath, "/quiet /norestart").WaitForExit();
        }
    }

    private HttpClient ConfigureHttpClient(HttpClient client)
    {
        client.Timeout = TimeSpan.FromMinutes(1);
        return client;
    }

#pragma warning disable CA1416 // Validate platform compatibility
    private bool IsDotNetFrameworkInstalled(Version version)
    {
        var uninstallKeyPaths = new[] {
            @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
            @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
        };
        foreach (var uninstallKeyPath in uninstallKeyPaths)
        {
            using var uninstallKey = Registry.LocalMachine.OpenSubKey(uninstallKeyPath);
            var uninstallSubKeyNames = uninstallKey.GetSubKeyNames();
            foreach (var uninstallSubKeyName in uninstallSubKeyNames)
            {
                using var uninstallSubKey = uninstallKey.OpenSubKey(uninstallSubKeyName);
                var displayName = (string)uninstallSubKey.GetValue("DisplayName");
                if (displayName == $"Microsoft .NET Framework {version} Developer Pack" ||
                    displayName == $"Microsoft .NET Framework {version} Multi-Targeting Pack" ||
                    displayName == $"Microsoft .NET Framework {version} Targeting Pack")
                {
                    return true;
                }
            }
        }
        return false;
    }
#pragma warning restore CA1416 // Validate platform compatibility

    private void InstallMono()
    {
        if (Linux.IsUbuntu1604OrHigher)
        {
            if (Linux.IsUbuntu2004)
            {
                Sudo("apt-get install ca-certificates gnupg");
                Sudo("gpg --homedir /tmp --no-default-keyring --keyring /usr/share/keyrings/mono-official-archive-keyring.gpg --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF");
                Echo("'deb [signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] https://download.mono-project.com/repo/ubuntu stable-focal main' | sudo tee /etc/apt/sources.list.d/mono-official-stable.list");
            }
            else if (Linux.IsUbuntu1804)
            {
                Sudo("apt-get install ca-certificates gnupg");
                Sudo("gpg --homedir /tmp --no-default-keyring --keyring /usr/share/keyrings/mono-official-archive-keyring.gpg --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF");
                Echo("'deb [signed-by=/usr/share/keyrings/mono-official-archive-keyring.gpg] https://download.mono-project.com/repo/ubuntu stable-bionic main' | sudo tee /etc/apt/sources.list.d/mono-official-stable.list");
            }
            else if (Linux.IsUbuntu1604)
            {
                Sudo("apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF");
                Sudo("apt-get install apt-transport-https ca-certificates");
                Echo("'deb https://download.mono-project.com/repo/ubuntu stable-xenial main' | sudo tee /etc/apt/sources.list.d/mono-official-stable.list");
            }

            Sudo("apt-get update");

            Sudo("apt-get install mono-devel");
        }
    }


    private void InstallAzureArtifactsCredentialProvider()
    {
        if (IsOSPlatform(OSPlatform.Windows))
        {
            Serilog.Log.Information($"Install Azure Artifacts Credential Provider");
            PowerShell("iex \"& { $(irm https://aka.ms/install-artifacts-credprovider.ps1) } -AddNetfx\"");
        }
        else
        {
            Serilog.Log.Information($"Install Azure Artifacts Credential Provider");
            StartShell("sh -c \"$(curl -fsSL https://aka.ms/install-artifacts-credprovider.sh)\"");
        };
    }
}
