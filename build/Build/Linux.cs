// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.IO;
using System.Runtime.InteropServices;

static partial class Linux
{
    private static bool IsLinux => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    public static bool IsUbuntu => IsDistroAndVersion("ubuntu");

    public static bool IsUbuntu1604 => IsDistroAndVersion("ubuntu", 16, 4);

    public static bool IsUbuntu1604OrHigher => IsDistroAndVersionOrHigher("ubuntu", 16, 4);

    public static bool IsUbuntu1804 => IsDistroAndVersion("ubuntu", 18, 04);

    public static bool IsUbuntu2004 => IsDistroAndVersion("ubuntu", 20, 04);

    private static Version ToVersion(string versionString)
    {
        // In some distros/versions we cannot discover the distro version; return something valid.
        // Pick a high version number, since this seems to happen on newer distros.
        if (string.IsNullOrEmpty(versionString))
        {
            versionString = new Version(int.MaxValue, int.MaxValue).ToString();
        }

        try
        {
            if (versionString.Contains('.'))
            {
                return new Version(versionString);
            }

            // minor version is required by Version
            // let's default it to 0
            return new Version(int.Parse(versionString), 0);
        }
        catch (Exception exc)
        {
            throw new FormatException($"Failed to parse version string: '{versionString}'", exc);
        }
    }

    private static DistroInfo GetDistroInfo()
    {
        var result = new DistroInfo();

        if (File.Exists("/etc/os-release"))
        {
            foreach (var line in File.ReadAllLines("/etc/os-release"))
            {
                if (line.StartsWith("ID=", StringComparison.Ordinal))
                {
                    result.Id = line[3..].Trim('"', '\'');
                }
                else if (line.StartsWith("VERSION_ID=", StringComparison.Ordinal))
                {
                    result.VersionId = ToVersion(line[11..].Trim('"', '\''));
                }
            }
        }

        result.Id ??= "Linux";
        result.VersionId ??= ToVersion(string.Empty);
        return result;
    }

    private static bool IsDistroAndVersion(string distroId, int major = -1, int minor = -1, int build = -1, int revision = -1)
    {
        return IsDistroAndVersion(distro => distro == distroId, major, minor, build, revision);
    }

    private static bool IsDistroAndVersionOrHigher(string distroId, int major = -1, int minor = -1, int build = -1, int revision = -1)
    {
        return IsDistroAndVersionOrHigher(distro => distro == distroId, major, minor, build, revision);
    }

    private static bool IsDistroAndVersion(Predicate<string> distroPredicate, int major = -1, int minor = -1, int build = -1, int revision = -1)
    {
        if (IsLinux)
        {
            var distroInfo = GetDistroInfo();
            if (distroPredicate(distroInfo.Id) && VersionEquivalentTo(major, minor, build, revision, distroInfo.VersionId))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsDistroAndVersionOrHigher(Predicate<string> distroPredicate, int major = -1, int minor = -1, int build = -1, int revision = -1)
    {
        if (IsLinux)
        {
            var distroInfo = GetDistroInfo();
            if (distroPredicate(distroInfo.Id) && VersionEquivalentToOrHigher(major, minor, build, revision, distroInfo.VersionId))
            {
                return true;
            }
        }

        return false;
    }

    private static bool VersionEquivalentTo(int major, int minor, int build, int revision, Version actualVersionId)
    {
        return (major == -1 || major == actualVersionId.Major)
            && (minor == -1 || minor == actualVersionId.Minor)
            && (build == -1 || build == actualVersionId.Build)
            && (revision == -1 || revision == actualVersionId.Revision);
    }

    private static bool VersionEquivalentToOrHigher(int major, int minor, int build, int revision, Version actualVersionId)
    {
        return
            VersionEquivalentTo(major, minor, build, revision, actualVersionId) ||
                actualVersionId.Major > major ||
                    (actualVersionId.Major == major && (actualVersionId.Minor > minor ||
                        (actualVersionId.Minor == minor && (actualVersionId.Build > build ||
                            (actualVersionId.Build == build && (actualVersionId.Revision > revision ||
                                (actualVersionId.Revision == revision)))))));
    }

    private struct DistroInfo
    {
        public string Id { get; set; }

        public Version VersionId { get; set; }
    }
}
