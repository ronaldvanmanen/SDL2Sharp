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
using System.Runtime.InteropServices;
using NuGet.Configuration;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitVersion;
using static System.Runtime.InteropServices.RuntimeInformation;
using static System.Runtime.InteropServices.Architecture;

interface IBuild : INukeBuild
{
    [Solution]
    public Solution Solution => TryGetValue(() => Solution);

    [GitVersion]
    public GitVersion GitVersion => TryGetValue(() => GitVersion);

    [Parameter("Configuration to build. Default is 'Debug' (local) or 'Release' (server).")]
    public Configuration Configuration => IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Platform architecture to use for testing. Default is the processor architecture of the underlying operating system.")]
    public string Architecture => OSArchitecture switch
    {
        X86 => "x86",
        X64 => "x64",
        Arm => "arm",
        Arm64 => "arm64",
        S390x => "s390x",
        Ppc64le => "ppc64le",
        _ => throw new PlatformNotSupportedException(),
    };

    public string RuntimeIdentifier
    {
        get
        {
            if (IsOSPlatform(OSPlatform.Linux))
            {
                return $"linux-{Architecture}";
            }
            if (IsOSPlatform(OSPlatform.OSX))
            {
                return $"osx-{Architecture}";
            }
            if (IsOSPlatform(OSPlatform.Windows))
            {
                return $"win-{Architecture}";
            }
            throw new PlatformNotSupportedException();
        }
    }

    public AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";

    public AbsolutePath GlobalPackagesFolder => AbsolutePath.Create(SettingsUtility.GetGlobalPackagesFolder(Settings.LoadDefaultSettings(null)));

}
