using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NuGet.Configuration;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Pack);

    [Solution]
    readonly Solution Solution;

    [GitVersion]
    readonly GitVersion GitVersion;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    AbsolutePath GlobalPackagesFolder => AbsolutePath.Create(SettingsUtility.GetGlobalPackagesFolder(Settings.LoadDefaultSettings(null)));

    Target RestoreTools => _ => _
        .Executes(() =>
        {
            DotNetToolRestore();
        });

    [UsedImplicitly]
    Target Generate => _ => _
        .DependsOn(RestoreTools)
        .Executes(() =>
        {
            var headerFile = RootDirectory / "generation" / "header.txt";
            var outputDirectory = RootDirectory / "sources" / "SDL2Sharp.Interop";
            var testOutputDirectory = RootDirectory / "tests" / "SDL2Sharp.Interop.UnitTests";

            const string packageId = "SDL2";
            var packageReferenceVersion = Solution.AllProjects
                .Select(e => e.GetPackageReferenceVersion(packageId))
                .Single(e => e is not null);
            var fileDirectory = GlobalPackagesFolder / packageId / packageReferenceVersion / "lib" / "native" / "include";

            var argumentList = new List<string>
            {
                $"tool",
                $"run",
                $"ClangSharpPInvokeGenerator",
                $"--config",
                $"compatible-codegen",
                $"generate-aggressive-inlining",
                $"generate-macro-bindings",
                $"generate-tests-xunit",
                $"multi-file",
                $"--headerFile",
                $"{headerFile}",
                $"--namespace",
                $"SDL2Sharp.Interop",
                $"--output",
                $"{outputDirectory}",
                $"--test-output",
                $"{testOutputDirectory}",
                $"--with-type",
                $"SDL_EventType=uint",
                $"SDL_PixelFormatEnum=uint",
                $"SDL_RendererFlags=uint"
            };

            argumentList.AddRange(
                [
                    $"--exclude",
                    $"__builtin_add_overflow",
                    $"__builtin_mul_overflow",
                    $"_SDL_HAS_BUILTIN",
                    $"_SDL_size_add_overflow_builtin",
                    $"_SDL_size_mul_overflow_builtin",
                    $"SDL_abs",
                    $"SDL_acos",
                    $"SDL_acosf",
                    $"SDL_arraysize",
                    $"SDL_asin",
                    $"SDL_asinf",
                    $"SDL_asprintf",
                    $"SDL_atan",
                    $"SDL_atan2",
                    $"SDL_atan2f",
                    $"SDL_atanf",
                    $"SDL_atof",
                    $"SDL_atoi",
                    $"SDL_AUDIO_BITSIZE",
                    $"SDL_AUDIO_ISBIGENDIAN",
                    $"SDL_AUDIO_ISFLOAT",
                    $"SDL_AUDIO_ISINT",
                    $"SDL_AUDIO_ISLITTLEENDIAN",
                    $"SDL_AUDIO_ISSIGNED",
                    $"SDL_AUDIO_ISUNSIGNED",
                    $"SDL_BITSPERPIXEL",
                    $"SDL_bsearch",
                    $"SDL_BUTTON",
                    $"SDL_BYTESPERPIXEL",
                    $"SDL_ceil",
                    $"SDL_ceilf",
                    $"SDL_clamp",
                    $"SDL_COMPILE_TIME_ASSERT",
                    $"SDL_const_cast",
                    $"SDL_copyp",
                    $"SDL_copysign",
                    $"SDL_copysignf",
                    $"SDL_cos",
                    $"SDL_cosf",
                    $"SDL_crc16",
                    $"SDL_crc32",
                    $"SDL_DEFINE_PIXELFORMAT",
                    $"SDL_DEFINE_PIXELFOURCC",
                    $"SDL_EncloseFPoints",
                    $"SDL_EnclosePoints",
                    $"SDL_exp",
                    $"SDL_expf",
                    $"SDL_fabs",
                    $"SDL_fabsf",
                    $"SDL_floor",
                    $"SDL_floorf",
                    $"SDL_fmod",
                    $"SDL_fmodf",
                    $"SDL_FOURCC",
                    $"SDL_FRectEmpty",
                    $"SDL_FRectEquals",
                    $"SDL_FRectEqualsEpsilon",
                    $"SDL_getenv",
                    $"SDL_GetEventState",
                    $"SDL_HasIntersection",
                    $"SDL_HasIntersectionF",
                    $"SDL_iconv_utf8_locale",
                    $"SDL_iconv_utf8_ucs2",
                    $"SDL_iconv_utf8_ucs4",
                    $"SDL_iconv_wchar_utf8",
                    $"SDL_IN_BYTECAP",
                    $"SDL_INOUT_Z_CAP",
                    $"SDL_IntersectFRect",
                    $"SDL_IntersectFRectAndLine",
                    $"SDL_IntersectRect",
                    $"SDL_IntersectRectAndLine",
                    $"SDL_InvalidParamError",
                    $"SDL_isalnum",
                    $"SDL_isalpha",
                    $"SDL_isblank",
                    $"SDL_iscntrl",
                    $"SDL_isdigit",
                    $"SDL_isgraph",
                    $"SDL_islower",
                    $"SDL_ISPIXELFORMAT_ALPHA",
                    $"SDL_ISPIXELFORMAT_ARRAY",
                    $"SDL_ISPIXELFORMAT_FOURCC",
                    $"SDL_ISPIXELFORMAT_INDEXED",
                    $"SDL_ISPIXELFORMAT_PACKED",
                    $"SDL_isprint",
                    $"SDL_ispunct",
                    $"SDL_isspace",
                    $"SDL_isupper",
                    $"SDL_isxdigit",
                    $"SDL_itoa",
                    $"SDL_lltoa",
                    $"SDL_LoadBMP",
                    $"SDL_LoadWAV",
                    $"SDL_log",
                    $"SDL_Log",
                    $"SDL_log10",
                    $"SDL_log10f",
                    $"SDL_LogCritical",
                    $"SDL_LogDebug",
                    $"SDL_LogError",
                    $"SDL_logf",
                    $"SDL_LogGetOutputFunction",
                    $"SDL_LogGetPriority",
                    $"SDL_LogInfo",
                    $"SDL_LogMessage",
                    $"SDL_LogMessageV",
                    $"SDL_LogResetPriorities",
                    $"SDL_LogSetAllPriority",
                    $"SDL_LogSetOutputFunction",
                    $"SDL_LogSetPriority",
                    $"SDL_LogVerbose",
                    $"SDL_LogWarn",
                    $"SDL_lround",
                    $"SDL_lroundf",
                    $"SDL_ltoa",
                    $"SDL_MAX_LOG_MESSAGE",
                    $"SDL_max",
                    $"SDL_memcmp",
                    $"SDL_memcpy",
                    $"SDL_memcpy4",
                    $"SDL_memmove",
                    $"SDL_memset",
                    $"SDL_memset4",
                    $"SDL_min",
                    $"SDL_MUSTLOCK",
                    $"SDL_OUT_BYTECAP",
                    $"SDL_OUT_CAP",
                    $"SDL_OUT_Z_BYTECAP",
                    $"SDL_OUT_Z_CAP",
                    $"SDL_OutOfMemory",
                    $"SDL_PIXELFLAG",
                    $"SDL_PIXELLAYOUT",
                    $"SDL_PIXELORDER",
                    $"SDL_PIXELTYPE",
                    $"SDL_PointInFRect",
                    $"SDL_PointInRect",
                    $"SDL_pow",
                    $"SDL_powf",
                    $"SDL_PRINTF_VARARG_FUNC",
                    $"SDL_qsort",
                    $"SDL_RectEmpty",
                    $"SDL_RectEquals",
                    $"SDL_reinterpret_cast",
                    $"SDL_round",
                    $"SDL_roundf",
                    $"SDL_SaveBMP",
                    $"SDL_scalbn",
                    $"SDL_scalbnf",
                    $"SDL_SCANCODE_TO_KEYCODE",
                    $"SDL_SCANF_VARARG_FUNC",
                    $"SDL_setenv",
                    $"SDL_sin",
                    $"SDL_sinf",
                    $"SDL_size_add_overflow",
                    $"SDL_size_mul_overflow",
                    $"SDL_snprintf",
                    $"SDL_sqrt",
                    $"SDL_sqrtf",
                    $"SDL_sscanf",
                    $"SDL_stack_alloc",
                    $"SDL_stack_free",
                    $"SDL_static_cast",
                    $"SDL_strcasecmp",
                    $"SDL_strchr",
                    $"SDL_strcmp",
                    $"SDL_strdup",
                    $"SDL_STRINGIFY_ARG",
                    $"SDL_strlcat",
                    $"SDL_strlcpy",
                    $"SDL_strlen",
                    $"SDL_strlwr",
                    $"SDL_strncasecmp",
                    $"SDL_strncmp",
                    $"SDL_strrchr",
                    $"SDL_strrev",
                    $"SDL_strstr",
                    $"SDL_strtod",
                    $"SDL_strtokr",
                    $"SDL_strtol",
                    $"SDL_strtoll",
                    $"SDL_strtoul",
                    $"SDL_strtoull",
                    $"SDL_strupr",
                    $"SDL_TABLESIZE",
                    $"SDL_tan",
                    $"SDL_tanf",
                    $"SDL_tolower",
                    $"SDL_toupper",
                    $"SDL_trunc",
                    $"SDL_truncf",
                    $"SDL_uitoa",
                    $"SDL_ulltoa",
                    $"SDL_ultoa",
                    $"SDL_UnionFRect",
                    $"SDL_UnionRect",
                    $"SDL_Unsupported",
                    $"SDL_utf8strlcpy",
                    $"SDL_utf8strlen",
                    $"SDL_utf8strnlen",
                    $"SDL_vasprintf",
                    $"SDL_VERSION_ATLEAST",
                    $"SDL_VERSION",
                    $"SDL_VERSIONNUM",
                    $"SDL_vsnprintf",
                    $"SDL_vsscanf",
                    $"SDL_wcscasecmp",
                    $"SDL_wcscmp",
                    $"SDL_wcsdup",
                    $"SDL_wcslcat",
                    $"SDL_wcslcpy",
                    $"SDL_wcslen",
                    $"SDL_wcsncasecmp",
                    $"SDL_wcsncmp",
                    $"SDL_wcsstr",
                    $"SDL_WINDOWPOS_CENTERED_DISPLAY",
                    $"SDL_WINDOWPOS_ISCENTERED",
                    $"SDL_WINDOWPOS_ISUNDEFINED",
                    $"SDL_WINDOWPOS_UNDEFINED_DISPLAY",
                    $"SDL_zero",
                    $"SDL_zeroa",
                    $"SDL_zerop",
                    $"--file",
                    $"SDL.h",
                    $"SDL_audio.h",
                    $"SDL_blendmode.h",
                    $"SDL_error.h",
                    $"SDL_events.h",
                    $"SDL_guid.h",
                    $"SDL_hints.h",
                    $"SDL_joystick.h",
                    $"SDL_keyboard.h",
                    $"SDL_keycode.h",
                    $"SDL_log.h",
                    $"SDL_mouse.h",
                    $"SDL_pixels.h",
                    $"SDL_rect.h",
                    $"SDL_render.h",
                    $"SDL_rwops.h",
                    $"SDL_scancode.h",
                    $"SDL_stdinc.h",
                    $"SDL_surface.h",
                    $"SDL_system.h",
                    $"SDL_version.h",
                    $"SDL_video.h",
                    $"--libraryPath",
                    $"SDL2",
                    $"--methodClassName",
                    $"SDL",
                    $"--prefixStrip",
                    $"SDL_",
                    $"--file-directory",
                    $"{fileDirectory}"
                ]
            );

            // NOTE: ArgumentStringHandler assumes our arguments must be double qouted because we
            // pass our arguments as a single string. To prevent this from happening we explicity
            // create an ArgumentStringHandler and append our arguments as a string literal.
            var argumentString = string.Join(' ', argumentList);
            ArgumentStringHandler arguments = "";
            arguments.AppendLiteral(argumentString);

            DotNet(arguments);
        });

    [UsedImplicitly]
    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            DotNetClean(settings => settings
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetVerbosity(Verbosity.ToDotNetVerbosity()));
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(settings => settings
                .SetProjectFile(Solution)
                .SetProperty("NuGetInteractive", IsLocalBuild ? "true" : "false")
                .SetProcessArgumentConfigurator(arguments =>
                {
                    if (IsLocalBuild)
                    {
                        arguments.Add("--interactive");
                    }
                    return arguments;
                })
                .SetVerbosity(Verbosity.ToDotNetVerbosity()));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(settings => settings
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetVersion(GitVersion.NuGetVersionV2)
                .SetNoRestore(true)
                .SetVerbosity(Verbosity.ToDotNetVerbosity()));
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(settings => settings
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetNoRestore(true)
                .SetNoBuild(true)
                .SetVerbosity(Verbosity.ToDotNetVerbosity())
                .SetProcessArgumentConfigurator(_ => _.Add(" -- RunConfiguration.DisableAppDomain=true")));
        });

    Target Pack => _ => _
        .DependsOn(Test)
        .Executes(() =>
        {
            DotNetPack(settings => settings
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetVersion(GitVersion.NuGetVersionV2)
                .SetNoBuild(true)
                .SetNoRestore(true)
                .SetVerbosity(Verbosity.ToDotNetVerbosity()));
        });
}

static class VerbosityExtensions
{
    public static DotNetVerbosity ToDotNetVerbosity(this Verbosity verbosity)
    {
        return verbosity switch
        {
            Verbosity.Quiet => DotNetVerbosity.quiet,
            Verbosity.Minimal => DotNetVerbosity.minimal,
            Verbosity.Normal => DotNetVerbosity.normal,
            Verbosity.Verbose => DotNetVerbosity.diagnostic,
            _ => throw new ArgumentException($"Unknown verbosity {verbosity}"),
        };
    }
}