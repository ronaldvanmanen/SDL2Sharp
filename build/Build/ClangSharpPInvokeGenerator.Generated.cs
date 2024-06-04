// Generated from https://github.com/ronaldvanmanen/nuke/blob/master/source/Nuke.Common/Tools/ClangSharpPInvokeGenerator/ClangSharpPInvokeGenerator.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.ClangSharpPInvokeGenerator;

/// <summary>
///   <p>ClangSharp P/Invoke Binding Generator is a tool for generating strongly-typed safe bindings written in C# for .NET and Mono.</p>
///   <p>For more details, visit the <a href="https://github.com/dotnet/clangsharp/">official website</a>.</p>
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(ClangSharpPInvokeGeneratorPackageId)]
public partial class ClangSharpPInvokeGeneratorTasks
    : IRequireNuGetPackage
{
    public const string ClangSharpPInvokeGeneratorPackageId = "ClangSharpPInvokeGenerator";
    /// <summary>
    ///   Path to the ClangSharpPInvokeGenerator executable.
    /// </summary>
    public static string ClangSharpPInvokeGeneratorPath =>
        ToolPathResolver.TryGetEnvironmentExecutable("CLANGSHARPPINVOKEGENERATOR_EXE") ??
        NuGetToolPathResolver.GetPackageExecutable("ClangSharpPInvokeGenerator", "ClangSharpPInvokeGenerator.dll");
    public static Action<OutputType, string> ClangSharpPInvokeGeneratorLogger { get; set; } = ProcessTasks.DefaultLogger;
    public static Action<ToolSettings, IProcess> ClangSharpPInvokeGeneratorExitHandler { get; set; } = CustomExitHandler;
    /// <summary>
    ///   <p>ClangSharp P/Invoke Binding Generator is a tool for generating strongly-typed safe bindings written in C# for .NET and Mono.</p>
    ///   <p>For more details, visit the <a href="https://github.com/dotnet/clangsharp/">official website</a>.</p>
    /// </summary>
    public static IReadOnlyCollection<Output> ClangSharpPInvokeGenerator(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Action<IProcess> exitHandler = null)
    {
        using var process = ProcessTasks.StartProcess(ClangSharpPInvokeGeneratorPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger ?? ClangSharpPInvokeGeneratorLogger);
        (exitHandler ?? (p => ClangSharpPInvokeGeneratorExitHandler.Invoke(null, p))).Invoke(process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>ClangSharp P/Invoke Binding Generator is a tool for generating strongly-typed safe bindings written in C# for .NET and Mono.</p>
    ///   <p>For more details, visit the <a href="https://github.com/dotnet/clangsharp/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></li>
    ///     <li><c>--config</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></li>
    ///     <li><c>--define-macro</c> via <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></li>
    ///     <li><c>--exclude</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></li>
    ///     <li><c>--file</c> via <see cref="ClangSharpPInvokeGeneratorSettings.File"/></li>
    ///     <li><c>--file-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></li>
    ///     <li><c>--headerFile</c> via <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></li>
    ///     <li><c>--include</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></li>
    ///     <li><c>--include-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></li>
    ///     <li><c>--language</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Language"/></li>
    ///     <li><c>--libraryPath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.LibraryPath"/></li>
    ///     <li><c>--methodClassName</c> via <see cref="ClangSharpPInvokeGeneratorSettings.MethodClassName"/></li>
    ///     <li><c>--namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Namespace"/></li>
    ///     <li><c>--nativeTypeNamesToStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.NativeTypeNamesToStrip"/></li>
    ///     <li><c>--output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Output"/></li>
    ///     <li><c>--output-mode</c> via <see cref="ClangSharpPInvokeGeneratorSettings.OutputMode"/></li>
    ///     <li><c>--prefixStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></li>
    ///     <li><c>--remap</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></li>
    ///     <li><c>--std</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Std"/></li>
    ///     <li><c>--test-output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.TestOutput"/></li>
    ///     <li><c>--traverse</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></li>
    ///     <li><c>--with-access-specifier</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></li>
    ///     <li><c>--with-attribute</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></li>
    ///     <li><c>--with-callconv</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></li>
    ///     <li><c>--with-class</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></li>
    ///     <li><c>--with-guid</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></li>
    ///     <li><c>--with-librarypath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></li>
    ///     <li><c>--with-manual-import</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></li>
    ///     <li><c>--with-namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></li>
    ///     <li><c>--with-packing</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></li>
    ///     <li><c>--with-setlasterror</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></li>
    ///     <li><c>--with-suppressgctransition</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></li>
    ///     <li><c>--with-transparent-struct</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></li>
    ///     <li><c>--with-type</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></li>
    ///     <li><c>--with-using</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> ClangSharpPInvokeGenerator(ClangSharpPInvokeGeneratorSettings toolSettings = null)
    {
        toolSettings = toolSettings ?? new ClangSharpPInvokeGeneratorSettings();
        using var process = ProcessTasks.StartProcess(toolSettings);
        toolSettings.ProcessExitHandler.Invoke(toolSettings, process.AssertWaitForExit());
        return process.Output;
    }
    /// <summary>
    ///   <p>ClangSharp P/Invoke Binding Generator is a tool for generating strongly-typed safe bindings written in C# for .NET and Mono.</p>
    ///   <p>For more details, visit the <a href="https://github.com/dotnet/clangsharp/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></li>
    ///     <li><c>--config</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></li>
    ///     <li><c>--define-macro</c> via <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></li>
    ///     <li><c>--exclude</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></li>
    ///     <li><c>--file</c> via <see cref="ClangSharpPInvokeGeneratorSettings.File"/></li>
    ///     <li><c>--file-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></li>
    ///     <li><c>--headerFile</c> via <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></li>
    ///     <li><c>--include</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></li>
    ///     <li><c>--include-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></li>
    ///     <li><c>--language</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Language"/></li>
    ///     <li><c>--libraryPath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.LibraryPath"/></li>
    ///     <li><c>--methodClassName</c> via <see cref="ClangSharpPInvokeGeneratorSettings.MethodClassName"/></li>
    ///     <li><c>--namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Namespace"/></li>
    ///     <li><c>--nativeTypeNamesToStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.NativeTypeNamesToStrip"/></li>
    ///     <li><c>--output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Output"/></li>
    ///     <li><c>--output-mode</c> via <see cref="ClangSharpPInvokeGeneratorSettings.OutputMode"/></li>
    ///     <li><c>--prefixStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></li>
    ///     <li><c>--remap</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></li>
    ///     <li><c>--std</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Std"/></li>
    ///     <li><c>--test-output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.TestOutput"/></li>
    ///     <li><c>--traverse</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></li>
    ///     <li><c>--with-access-specifier</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></li>
    ///     <li><c>--with-attribute</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></li>
    ///     <li><c>--with-callconv</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></li>
    ///     <li><c>--with-class</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></li>
    ///     <li><c>--with-guid</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></li>
    ///     <li><c>--with-librarypath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></li>
    ///     <li><c>--with-manual-import</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></li>
    ///     <li><c>--with-namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></li>
    ///     <li><c>--with-packing</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></li>
    ///     <li><c>--with-setlasterror</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></li>
    ///     <li><c>--with-suppressgctransition</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></li>
    ///     <li><c>--with-transparent-struct</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></li>
    ///     <li><c>--with-type</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></li>
    ///     <li><c>--with-using</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></li>
    ///   </ul>
    /// </remarks>
    public static IReadOnlyCollection<Output> ClangSharpPInvokeGenerator(Configure<ClangSharpPInvokeGeneratorSettings> configurator)
    {
        return ClangSharpPInvokeGenerator(configurator(new ClangSharpPInvokeGeneratorSettings()));
    }
    /// <summary>
    ///   <p>ClangSharp P/Invoke Binding Generator is a tool for generating strongly-typed safe bindings written in C# for .NET and Mono.</p>
    ///   <p>For more details, visit the <a href="https://github.com/dotnet/clangsharp/">official website</a>.</p>
    /// </summary>
    /// <remarks>
    ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
    ///   <ul>
    ///     <li><c>--additional</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></li>
    ///     <li><c>--config</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></li>
    ///     <li><c>--define-macro</c> via <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></li>
    ///     <li><c>--exclude</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></li>
    ///     <li><c>--file</c> via <see cref="ClangSharpPInvokeGeneratorSettings.File"/></li>
    ///     <li><c>--file-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></li>
    ///     <li><c>--headerFile</c> via <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></li>
    ///     <li><c>--include</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></li>
    ///     <li><c>--include-directory</c> via <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></li>
    ///     <li><c>--language</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Language"/></li>
    ///     <li><c>--libraryPath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.LibraryPath"/></li>
    ///     <li><c>--methodClassName</c> via <see cref="ClangSharpPInvokeGeneratorSettings.MethodClassName"/></li>
    ///     <li><c>--namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Namespace"/></li>
    ///     <li><c>--nativeTypeNamesToStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.NativeTypeNamesToStrip"/></li>
    ///     <li><c>--output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Output"/></li>
    ///     <li><c>--output-mode</c> via <see cref="ClangSharpPInvokeGeneratorSettings.OutputMode"/></li>
    ///     <li><c>--prefixStrip</c> via <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></li>
    ///     <li><c>--remap</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></li>
    ///     <li><c>--std</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Std"/></li>
    ///     <li><c>--test-output</c> via <see cref="ClangSharpPInvokeGeneratorSettings.TestOutput"/></li>
    ///     <li><c>--traverse</c> via <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></li>
    ///     <li><c>--with-access-specifier</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></li>
    ///     <li><c>--with-attribute</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></li>
    ///     <li><c>--with-callconv</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></li>
    ///     <li><c>--with-class</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></li>
    ///     <li><c>--with-guid</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></li>
    ///     <li><c>--with-librarypath</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></li>
    ///     <li><c>--with-manual-import</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></li>
    ///     <li><c>--with-namespace</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></li>
    ///     <li><c>--with-packing</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></li>
    ///     <li><c>--with-setlasterror</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></li>
    ///     <li><c>--with-suppressgctransition</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></li>
    ///     <li><c>--with-transparent-struct</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></li>
    ///     <li><c>--with-type</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></li>
    ///     <li><c>--with-using</c> via <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></li>
    ///   </ul>
    /// </remarks>
    public static IEnumerable<(ClangSharpPInvokeGeneratorSettings Settings, IReadOnlyCollection<Output> Output)> ClangSharpPInvokeGenerator(CombinatorialConfigure<ClangSharpPInvokeGeneratorSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
    {
        return configurator.Invoke(ClangSharpPInvokeGenerator, ClangSharpPInvokeGeneratorLogger, degreeOfParallelism, completeOnFailure);
    }
}
#region ClangSharpPInvokeGeneratorSettings
/// <summary>
///   Used within <see cref="ClangSharpPInvokeGeneratorTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public partial class ClangSharpPInvokeGeneratorSettings : ToolSettings
{
    /// <summary>
    ///   Path to the ClangSharpPInvokeGenerator executable.
    /// </summary>
    public override string ProcessToolPath => base.ProcessToolPath ?? ClangSharpPInvokeGeneratorTasks.ClangSharpPInvokeGeneratorPath;
    public override Action<OutputType, string> ProcessLogger => base.ProcessLogger ?? ClangSharpPInvokeGeneratorTasks.ClangSharpPInvokeGeneratorLogger;
    public override Action<ToolSettings, IProcess> ProcessExitHandler => base.ProcessExitHandler ?? ClangSharpPInvokeGeneratorTasks.ClangSharpPInvokeGeneratorExitHandler;
    /// <summary>
    ///   An argument to pass to Clang when parsing the input files.
    /// </summary>
    public virtual IReadOnlyList<string> Additional => AdditionalInternal.AsReadOnly();
    internal List<string> AdditionalInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A configuration option that controls how the bindings are generated.
    /// </summary>
    public virtual IReadOnlyList<ClangSharpPInvokeGeneratorConfigOption> Config => ConfigInternal.AsReadOnly();
    internal List<ClangSharpPInvokeGeneratorConfigOption> ConfigInternal { get; set; } = new List<ClangSharpPInvokeGeneratorConfigOption>();
    /// <summary>
    ///   Define <macro> to <value> (or 1 if <value> omitted).
    /// </summary>
    public virtual IReadOnlyList<string> DefineMacro => DefineMacroInternal.AsReadOnly();
    internal List<string> DefineMacroInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A declaration name to exclude from binding generation.
    /// </summary>
    public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
    internal List<string> ExcludeInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A file to parse and generate bindings for.
    /// </summary>
    public virtual IReadOnlyList<string> File => FileInternal.AsReadOnly();
    internal List<string> FileInternal { get; set; } = new List<string>();
    /// <summary>
    ///   The base path for files to parse.
    /// </summary>
    public virtual IReadOnlyList<string> FileDirectory => FileDirectoryInternal.AsReadOnly();
    internal List<string> FileDirectoryInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A file which contains the header to prefix every generated file with.
    /// </summary>
    public virtual IReadOnlyList<string> HeaderFile => HeaderFileInternal.AsReadOnly();
    internal List<string> HeaderFileInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A declaration name to include in binding generation.
    /// </summary>
    public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
    internal List<string> IncludeInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Add directory to include search path.
    /// </summary>
    public virtual IReadOnlyList<string> IncludeDirectory => IncludeDirectoryInternal.AsReadOnly();
    internal List<string> IncludeDirectoryInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Treat subsequent input files as having type <language>.
    /// </summary>
    public virtual string Language { get; internal set; }
    /// <summary>
    ///   The string to use in the <c>DllImport</c> attribute used when generating bindings.
    /// </summary>
    public virtual string LibraryPath { get; internal set; }
    /// <summary>
    ///   The name of the static class that will contain the generated method bindings.
    /// </summary>
    public virtual string MethodClassName { get; internal set; }
    /// <summary>
    ///   The namespace in which to place the generated bindings.
    /// </summary>
    public virtual string Namespace { get; internal set; }
    /// <summary>
    ///   The contents to strip from the generated NativeTypeName attributes.
    /// </summary>
    public virtual string NativeTypeNamesToStrip { get; internal set; }
    /// <summary>
    ///   The mode describing how the information collected from the headers are presented in the resultant bindings.
    /// </summary>
    public virtual ClangSharpPInvokeGeneratorOutputMode OutputMode { get; internal set; }
    /// <summary>
    ///   The output location to write the generated bindings to.
    /// </summary>
    public virtual string Output { get; internal set; }
    /// <summary>
    ///   The prefix to strip from the generated method bindings.
    /// </summary>
    public virtual IReadOnlyList<string> PrefixStrip => PrefixStripInternal.AsReadOnly();
    internal List<string> PrefixStripInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A declaration name to be remapped to another name during binding generation.
    /// </summary>
    public virtual IReadOnlyList<string> Remap => RemapInternal.AsReadOnly();
    internal List<string> RemapInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Language standard to compile for.
    /// </summary>
    public virtual string Std { get; internal set; }
    /// <summary>
    ///   The output location to write the generated tests to.
    /// </summary>
    public virtual string TestOutput { get; internal set; }
    /// <summary>
    ///   A file name included either directly or indirectly by -f that should be traversed during binding generation.
    /// </summary>
    public virtual IReadOnlyList<string> Traverse => TraverseInternal.AsReadOnly();
    internal List<string> TraverseInternal { get; set; } = new List<string>();
    /// <summary>
    ///   An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithAccessSpecifier => WithAccessSpecifierInternal.AsReadOnly();
    internal List<string> WithAccessSpecifierInternal { get; set; } = new List<string>();
    /// <summary>
    ///   An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithAttribute => WithAttributeInternal.AsReadOnly();
    internal List<string> WithAttributeInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A calling convention to be used for the given declaration during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithCallConv => WithCallConvInternal.AsReadOnly();
    internal List<string> WithCallConvInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithClass => WithClassInternal.AsReadOnly();
    internal List<string> WithClassInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A GUID to be used for the given declaration during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithGuid => WithGuidInternal.AsReadOnly();
    internal List<string> WithGuidInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A library path to be used for the given declaration during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithLibraryPath => WithLibraryPathInternal.AsReadOnly();
    internal List<string> WithLibraryPathInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A remapped function name to be treated as a manual import during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithManualImport => WithManualImportInternal.AsReadOnly();
    internal List<string> WithManualImportInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithNamespace => WithNamespaceInternal.AsReadOnly();
    internal List<string> WithNamespaceInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithPacking => WithPackingInternal.AsReadOnly();
    internal List<string> WithPackingInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithSetLastError => WithSetLastErrorInternal.AsReadOnly();
    internal List<string> WithSetLastErrorInternal { get; set; } = new List<string>();
    /// <summary>
    ///   Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithSuppressGCTransition => WithSuppressGCTransitionInternal.AsReadOnly();
    internal List<string> WithSuppressGCTransitionInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithTransparentStruct => WithTransparentStructInternal.AsReadOnly();
    internal List<string> WithTransparentStructInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A type to be used for the given enum declaration during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithType => WithTypeInternal.AsReadOnly();
    internal List<string> WithTypeInternal { get; set; } = new List<string>();
    /// <summary>
    ///   A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.
    /// </summary>
    public virtual IReadOnlyList<string> WithUsing => WithUsingInternal.AsReadOnly();
    internal List<string> WithUsingInternal { get; set; } = new List<string>();
    protected override Arguments ConfigureProcessArguments(Arguments arguments)
    {
        arguments
          .Add("--additional {value}", Additional)
          .Add("--config {value}", Config)
          .Add("--define-macro {value}", DefineMacro)
          .Add("--exclude {value}", Exclude)
          .Add("--file {value}", File)
          .Add("--file-directory {value}", FileDirectory)
          .Add("--headerFile {value}", HeaderFile)
          .Add("--include {value}", Include)
          .Add("--include-directory {value}", IncludeDirectory)
          .Add("--language {value}", Language)
          .Add("--libraryPath {value}", LibraryPath)
          .Add("--methodClassName {value}", MethodClassName)
          .Add("--namespace {value}", Namespace)
          .Add("--nativeTypeNamesToStrip {value}", NativeTypeNamesToStrip)
          .Add("--output-mode {value}", OutputMode)
          .Add("--output {value}", Output)
          .Add("--prefixStrip {value}", PrefixStrip)
          .Add("--remap {value}", Remap)
          .Add("--std {value}", Std)
          .Add("--test-output {value}", TestOutput)
          .Add("--traverse {value}", Traverse)
          .Add("--with-access-specifier {value}", WithAccessSpecifier)
          .Add("--with-attribute {value}", WithAttribute)
          .Add("--with-callconv {value}", WithCallConv)
          .Add("--with-class {value}", WithClass)
          .Add("--with-guid {value}", WithGuid)
          .Add("--with-librarypath {value}", WithLibraryPath)
          .Add("--with-manual-import {value}", WithManualImport)
          .Add("--with-namespace {value}", WithNamespace)
          .Add("--with-packing {value}", WithPacking)
          .Add("--with-setlasterror {value}", WithSetLastError)
          .Add("--with-suppressgctransition {value}", WithSuppressGCTransition)
          .Add("--with-transparent-struct {value}", WithTransparentStruct)
          .Add("--with-type {value}", WithType)
          .Add("--with-using {value}", WithUsing);
        return base.ConfigureProcessArguments(arguments);
    }
}
#endregion
#region ClangSharpPInvokeGeneratorSettingsExtensions
/// <summary>
///   Used within <see cref="ClangSharpPInvokeGeneratorTasks"/>.
/// </summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ClangSharpPInvokeGeneratorSettingsExtensions
{
    #region Additional
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/> to a new list</em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T SetAdditional<T>(this T toolSettings, params string[] additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalInternal = additional.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/> to a new list</em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T SetAdditional<T>(this T toolSettings, IEnumerable<string> additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalInternal = additional.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T AddAdditional<T>(this T toolSettings, params string[] additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalInternal.AddRange(additional);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T AddAdditional<T>(this T toolSettings, IEnumerable<string> additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalInternal.AddRange(additional);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T ClearAdditional<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.AdditionalInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T RemoveAdditional<T>(this T toolSettings, params string[] additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(additional);
        toolSettings.AdditionalInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Additional"/></em></p>
    ///   <p>An argument to pass to Clang when parsing the input files.</p>
    /// </summary>
    [Pure]
    public static T RemoveAdditional<T>(this T toolSettings, IEnumerable<string> additional) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(additional);
        toolSettings.AdditionalInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Config
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Config"/> to a new list</em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T SetConfig<T>(this T toolSettings, params ClangSharpPInvokeGeneratorConfigOption[] config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigInternal = config.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Config"/> to a new list</em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T SetConfig<T>(this T toolSettings, IEnumerable<ClangSharpPInvokeGeneratorConfigOption> config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigInternal = config.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T AddConfig<T>(this T toolSettings, params ClangSharpPInvokeGeneratorConfigOption[] config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigInternal.AddRange(config);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T AddConfig<T>(this T toolSettings, IEnumerable<ClangSharpPInvokeGeneratorConfigOption> config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigInternal.AddRange(config);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T ClearConfig<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ConfigInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T RemoveConfig<T>(this T toolSettings, params ClangSharpPInvokeGeneratorConfigOption[] config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<ClangSharpPInvokeGeneratorConfigOption>(config);
        toolSettings.ConfigInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Config"/></em></p>
    ///   <p>A configuration option that controls how the bindings are generated.</p>
    /// </summary>
    [Pure]
    public static T RemoveConfig<T>(this T toolSettings, IEnumerable<ClangSharpPInvokeGeneratorConfigOption> config) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<ClangSharpPInvokeGeneratorConfigOption>(config);
        toolSettings.ConfigInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region DefineMacro
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/> to a new list</em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T SetDefineMacro<T>(this T toolSettings, params string[] defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DefineMacroInternal = defineMacro.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/> to a new list</em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T SetDefineMacro<T>(this T toolSettings, IEnumerable<string> defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DefineMacroInternal = defineMacro.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T AddDefineMacro<T>(this T toolSettings, params string[] defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DefineMacroInternal.AddRange(defineMacro);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T AddDefineMacro<T>(this T toolSettings, IEnumerable<string> defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DefineMacroInternal.AddRange(defineMacro);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T ClearDefineMacro<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.DefineMacroInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T RemoveDefineMacro<T>(this T toolSettings, params string[] defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(defineMacro);
        toolSettings.DefineMacroInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.DefineMacro"/></em></p>
    ///   <p>Define <macro> to <value> (or 1 if <value> omitted).</p>
    /// </summary>
    [Pure]
    public static T RemoveDefineMacro<T>(this T toolSettings, IEnumerable<string> defineMacro) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(defineMacro);
        toolSettings.DefineMacroInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Exclude
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/> to a new list</em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExcludeInternal = exclude.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/> to a new list</em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExcludeInternal = exclude.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExcludeInternal.AddRange(exclude);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExcludeInternal.AddRange(exclude);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T ClearExclude<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.ExcludeInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(exclude);
        toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Exclude"/></em></p>
    ///   <p>A declaration name to exclude from binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(exclude);
        toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region File
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.File"/> to a new list</em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T SetFile<T>(this T toolSettings, params string[] file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileInternal = file.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.File"/> to a new list</em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T SetFile<T>(this T toolSettings, IEnumerable<string> file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileInternal = file.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.File"/></em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T AddFile<T>(this T toolSettings, params string[] file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileInternal.AddRange(file);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.File"/></em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T AddFile<T>(this T toolSettings, IEnumerable<string> file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileInternal.AddRange(file);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.File"/></em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T ClearFile<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.File"/></em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T RemoveFile<T>(this T toolSettings, params string[] file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(file);
        toolSettings.FileInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.File"/></em></p>
    ///   <p>A file to parse and generate bindings for.</p>
    /// </summary>
    [Pure]
    public static T RemoveFile<T>(this T toolSettings, IEnumerable<string> file) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(file);
        toolSettings.FileInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region FileDirectory
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/> to a new list</em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T SetFileDirectory<T>(this T toolSettings, params string[] fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileDirectoryInternal = fileDirectory.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/> to a new list</em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T SetFileDirectory<T>(this T toolSettings, IEnumerable<string> fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileDirectoryInternal = fileDirectory.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T AddFileDirectory<T>(this T toolSettings, params string[] fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileDirectoryInternal.AddRange(fileDirectory);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T AddFileDirectory<T>(this T toolSettings, IEnumerable<string> fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileDirectoryInternal.AddRange(fileDirectory);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T ClearFileDirectory<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.FileDirectoryInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T RemoveFileDirectory<T>(this T toolSettings, params string[] fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(fileDirectory);
        toolSettings.FileDirectoryInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.FileDirectory"/></em></p>
    ///   <p>The base path for files to parse.</p>
    /// </summary>
    [Pure]
    public static T RemoveFileDirectory<T>(this T toolSettings, IEnumerable<string> fileDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(fileDirectory);
        toolSettings.FileDirectoryInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region HeaderFile
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/> to a new list</em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T SetHeaderFile<T>(this T toolSettings, params string[] headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HeaderFileInternal = headerFile.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/> to a new list</em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T SetHeaderFile<T>(this T toolSettings, IEnumerable<string> headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HeaderFileInternal = headerFile.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T AddHeaderFile<T>(this T toolSettings, params string[] headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HeaderFileInternal.AddRange(headerFile);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T AddHeaderFile<T>(this T toolSettings, IEnumerable<string> headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HeaderFileInternal.AddRange(headerFile);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T ClearHeaderFile<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.HeaderFileInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T RemoveHeaderFile<T>(this T toolSettings, params string[] headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(headerFile);
        toolSettings.HeaderFileInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.HeaderFile"/></em></p>
    ///   <p>A file which contains the header to prefix every generated file with.</p>
    /// </summary>
    [Pure]
    public static T RemoveHeaderFile<T>(this T toolSettings, IEnumerable<string> headerFile) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(headerFile);
        toolSettings.HeaderFileInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Include
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Include"/> to a new list</em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetInclude<T>(this T toolSettings, params string[] include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeInternal = include.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Include"/> to a new list</em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeInternal = include.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddInclude<T>(this T toolSettings, params string[] include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeInternal.AddRange(include);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeInternal.AddRange(include);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T ClearInclude<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveInclude<T>(this T toolSettings, params string[] include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(include);
        toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Include"/></em></p>
    ///   <p>A declaration name to include in binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(include);
        toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region IncludeDirectory
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/> to a new list</em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T SetIncludeDirectory<T>(this T toolSettings, params string[] includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeDirectoryInternal = includeDirectory.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/> to a new list</em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T SetIncludeDirectory<T>(this T toolSettings, IEnumerable<string> includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeDirectoryInternal = includeDirectory.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T AddIncludeDirectory<T>(this T toolSettings, params string[] includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeDirectoryInternal.AddRange(includeDirectory);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T AddIncludeDirectory<T>(this T toolSettings, IEnumerable<string> includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeDirectoryInternal.AddRange(includeDirectory);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T ClearIncludeDirectory<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.IncludeDirectoryInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T RemoveIncludeDirectory<T>(this T toolSettings, params string[] includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(includeDirectory);
        toolSettings.IncludeDirectoryInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.IncludeDirectory"/></em></p>
    ///   <p>Add directory to include search path.</p>
    /// </summary>
    [Pure]
    public static T RemoveIncludeDirectory<T>(this T toolSettings, IEnumerable<string> includeDirectory) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(includeDirectory);
        toolSettings.IncludeDirectoryInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Language
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Language"/></em></p>
    ///   <p>Treat subsequent input files as having type <language>.</p>
    /// </summary>
    [Pure]
    public static T SetLanguage<T>(this T toolSettings, string language) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Language = language;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.Language"/></em></p>
    ///   <p>Treat subsequent input files as having type <language>.</p>
    /// </summary>
    [Pure]
    public static T ResetLanguage<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Language = null;
        return toolSettings;
    }
    #endregion
    #region LibraryPath
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.LibraryPath"/></em></p>
    ///   <p>The string to use in the <c>DllImport</c> attribute used when generating bindings.</p>
    /// </summary>
    [Pure]
    public static T SetLibraryPath<T>(this T toolSettings, string libraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LibraryPath = libraryPath;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.LibraryPath"/></em></p>
    ///   <p>The string to use in the <c>DllImport</c> attribute used when generating bindings.</p>
    /// </summary>
    [Pure]
    public static T ResetLibraryPath<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.LibraryPath = null;
        return toolSettings;
    }
    #endregion
    #region MethodClassName
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.MethodClassName"/></em></p>
    ///   <p>The name of the static class that will contain the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T SetMethodClassName<T>(this T toolSettings, string methodClassName) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MethodClassName = methodClassName;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.MethodClassName"/></em></p>
    ///   <p>The name of the static class that will contain the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T ResetMethodClassName<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.MethodClassName = null;
        return toolSettings;
    }
    #endregion
    #region Namespace
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Namespace"/></em></p>
    ///   <p>The namespace in which to place the generated bindings.</p>
    /// </summary>
    [Pure]
    public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = @namespace;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.Namespace"/></em></p>
    ///   <p>The namespace in which to place the generated bindings.</p>
    /// </summary>
    [Pure]
    public static T ResetNamespace<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Namespace = null;
        return toolSettings;
    }
    #endregion
    #region NativeTypeNamesToStrip
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.NativeTypeNamesToStrip"/></em></p>
    ///   <p>The contents to strip from the generated NativeTypeName attributes.</p>
    /// </summary>
    [Pure]
    public static T SetNativeTypeNamesToStrip<T>(this T toolSettings, string nativeTypeNamesToStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NativeTypeNamesToStrip = nativeTypeNamesToStrip;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.NativeTypeNamesToStrip"/></em></p>
    ///   <p>The contents to strip from the generated NativeTypeName attributes.</p>
    /// </summary>
    [Pure]
    public static T ResetNativeTypeNamesToStrip<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.NativeTypeNamesToStrip = null;
        return toolSettings;
    }
    #endregion
    #region OutputMode
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.OutputMode"/></em></p>
    ///   <p>The mode describing how the information collected from the headers are presented in the resultant bindings.</p>
    /// </summary>
    [Pure]
    public static T SetOutputMode<T>(this T toolSettings, ClangSharpPInvokeGeneratorOutputMode outputMode) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputMode = outputMode;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.OutputMode"/></em></p>
    ///   <p>The mode describing how the information collected from the headers are presented in the resultant bindings.</p>
    /// </summary>
    [Pure]
    public static T ResetOutputMode<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.OutputMode = null;
        return toolSettings;
    }
    #endregion
    #region Output
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Output"/></em></p>
    ///   <p>The output location to write the generated bindings to.</p>
    /// </summary>
    [Pure]
    public static T SetOutput<T>(this T toolSettings, string output) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = output;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.Output"/></em></p>
    ///   <p>The output location to write the generated bindings to.</p>
    /// </summary>
    [Pure]
    public static T ResetOutput<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Output = null;
        return toolSettings;
    }
    #endregion
    #region PrefixStrip
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/> to a new list</em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T SetPrefixStrip<T>(this T toolSettings, params string[] prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PrefixStripInternal = prefixStrip.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/> to a new list</em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T SetPrefixStrip<T>(this T toolSettings, IEnumerable<string> prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PrefixStripInternal = prefixStrip.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T AddPrefixStrip<T>(this T toolSettings, params string[] prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PrefixStripInternal.AddRange(prefixStrip);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T AddPrefixStrip<T>(this T toolSettings, IEnumerable<string> prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PrefixStripInternal.AddRange(prefixStrip);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T ClearPrefixStrip<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.PrefixStripInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T RemovePrefixStrip<T>(this T toolSettings, params string[] prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(prefixStrip);
        toolSettings.PrefixStripInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.PrefixStrip"/></em></p>
    ///   <p>The prefix to strip from the generated method bindings.</p>
    /// </summary>
    [Pure]
    public static T RemovePrefixStrip<T>(this T toolSettings, IEnumerable<string> prefixStrip) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(prefixStrip);
        toolSettings.PrefixStripInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Remap
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/> to a new list</em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetRemap<T>(this T toolSettings, params string[] remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemapInternal = remap.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/> to a new list</em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetRemap<T>(this T toolSettings, IEnumerable<string> remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemapInternal = remap.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddRemap<T>(this T toolSettings, params string[] remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemapInternal.AddRange(remap);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddRemap<T>(this T toolSettings, IEnumerable<string> remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemapInternal.AddRange(remap);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T ClearRemap<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.RemapInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveRemap<T>(this T toolSettings, params string[] remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(remap);
        toolSettings.RemapInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Remap"/></em></p>
    ///   <p>A declaration name to be remapped to another name during binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveRemap<T>(this T toolSettings, IEnumerable<string> remap) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(remap);
        toolSettings.RemapInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region Std
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Std"/></em></p>
    ///   <p>Language standard to compile for.</p>
    /// </summary>
    [Pure]
    public static T SetStd<T>(this T toolSettings, string std) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Std = std;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.Std"/></em></p>
    ///   <p>Language standard to compile for.</p>
    /// </summary>
    [Pure]
    public static T ResetStd<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.Std = null;
        return toolSettings;
    }
    #endregion
    #region TestOutput
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.TestOutput"/></em></p>
    ///   <p>The output location to write the generated tests to.</p>
    /// </summary>
    [Pure]
    public static T SetTestOutput<T>(this T toolSettings, string testOutput) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestOutput = testOutput;
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Resets <see cref="ClangSharpPInvokeGeneratorSettings.TestOutput"/></em></p>
    ///   <p>The output location to write the generated tests to.</p>
    /// </summary>
    [Pure]
    public static T ResetTestOutput<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestOutput = null;
        return toolSettings;
    }
    #endregion
    #region Traverse
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/> to a new list</em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetTraverse<T>(this T toolSettings, params string[] traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TraverseInternal = traverse.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/> to a new list</em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T SetTraverse<T>(this T toolSettings, IEnumerable<string> traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TraverseInternal = traverse.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddTraverse<T>(this T toolSettings, params string[] traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TraverseInternal.AddRange(traverse);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T AddTraverse<T>(this T toolSettings, IEnumerable<string> traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TraverseInternal.AddRange(traverse);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T ClearTraverse<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TraverseInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveTraverse<T>(this T toolSettings, params string[] traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(traverse);
        toolSettings.TraverseInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.Traverse"/></em></p>
    ///   <p>A file name included either directly or indirectly by -f that should be traversed during binding generation.</p>
    /// </summary>
    [Pure]
    public static T RemoveTraverse<T>(this T toolSettings, IEnumerable<string> traverse) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(traverse);
        toolSettings.TraverseInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithAccessSpecifier
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/> to a new list</em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithAccessSpecifier<T>(this T toolSettings, params string[] withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAccessSpecifierInternal = withAccessSpecifier.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/> to a new list</em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithAccessSpecifier<T>(this T toolSettings, IEnumerable<string> withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAccessSpecifierInternal = withAccessSpecifier.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithAccessSpecifier<T>(this T toolSettings, params string[] withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAccessSpecifierInternal.AddRange(withAccessSpecifier);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithAccessSpecifier<T>(this T toolSettings, IEnumerable<string> withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAccessSpecifierInternal.AddRange(withAccessSpecifier);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithAccessSpecifier<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAccessSpecifierInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithAccessSpecifier<T>(this T toolSettings, params string[] withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withAccessSpecifier);
        toolSettings.WithAccessSpecifierInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithAccessSpecifier"/></em></p>
    ///   <p>An access specifier to be used with the given qualified or remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithAccessSpecifier<T>(this T toolSettings, IEnumerable<string> withAccessSpecifier) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withAccessSpecifier);
        toolSettings.WithAccessSpecifierInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithAttribute
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/> to a new list</em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithAttribute<T>(this T toolSettings, params string[] withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAttributeInternal = withAttribute.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/> to a new list</em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithAttribute<T>(this T toolSettings, IEnumerable<string> withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAttributeInternal = withAttribute.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithAttribute<T>(this T toolSettings, params string[] withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAttributeInternal.AddRange(withAttribute);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithAttribute<T>(this T toolSettings, IEnumerable<string> withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAttributeInternal.AddRange(withAttribute);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithAttribute<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithAttributeInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithAttribute<T>(this T toolSettings, params string[] withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withAttribute);
        toolSettings.WithAttributeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithAttribute"/></em></p>
    ///   <p>An attribute to be added to the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithAttribute<T>(this T toolSettings, IEnumerable<string> withAttribute) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withAttribute);
        toolSettings.WithAttributeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithCallConv
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/> to a new list</em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithCallConv<T>(this T toolSettings, params string[] withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithCallConvInternal = withCallConv.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/> to a new list</em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithCallConv<T>(this T toolSettings, IEnumerable<string> withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithCallConvInternal = withCallConv.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithCallConv<T>(this T toolSettings, params string[] withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithCallConvInternal.AddRange(withCallConv);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithCallConv<T>(this T toolSettings, IEnumerable<string> withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithCallConvInternal.AddRange(withCallConv);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithCallConv<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithCallConvInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithCallConv<T>(this T toolSettings, params string[] withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withCallConv);
        toolSettings.WithCallConvInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithCallConv"/></em></p>
    ///   <p>A calling convention to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithCallConv<T>(this T toolSettings, IEnumerable<string> withCallConv) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withCallConv);
        toolSettings.WithCallConvInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithClass
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/> to a new list</em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithClass<T>(this T toolSettings, params string[] withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithClassInternal = withClass.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/> to a new list</em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithClass<T>(this T toolSettings, IEnumerable<string> withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithClassInternal = withClass.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithClass<T>(this T toolSettings, params string[] withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithClassInternal.AddRange(withClass);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithClass<T>(this T toolSettings, IEnumerable<string> withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithClassInternal.AddRange(withClass);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithClass<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithClassInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithClass<T>(this T toolSettings, params string[] withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withClass);
        toolSettings.WithClassInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithClass"/></em></p>
    ///   <p>A class to be used for the given remapped constant or function declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithClass<T>(this T toolSettings, IEnumerable<string> withClass) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withClass);
        toolSettings.WithClassInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithGuid
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/> to a new list</em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithGuid<T>(this T toolSettings, params string[] withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithGuidInternal = withGuid.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/> to a new list</em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithGuid<T>(this T toolSettings, IEnumerable<string> withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithGuidInternal = withGuid.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithGuid<T>(this T toolSettings, params string[] withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithGuidInternal.AddRange(withGuid);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithGuid<T>(this T toolSettings, IEnumerable<string> withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithGuidInternal.AddRange(withGuid);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithGuid<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithGuidInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithGuid<T>(this T toolSettings, params string[] withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withGuid);
        toolSettings.WithGuidInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithGuid"/></em></p>
    ///   <p>A GUID to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithGuid<T>(this T toolSettings, IEnumerable<string> withGuid) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withGuid);
        toolSettings.WithGuidInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithLibraryPath
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/> to a new list</em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithLibraryPath<T>(this T toolSettings, params string[] withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithLibraryPathInternal = withLibraryPath.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/> to a new list</em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithLibraryPath<T>(this T toolSettings, IEnumerable<string> withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithLibraryPathInternal = withLibraryPath.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithLibraryPath<T>(this T toolSettings, params string[] withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithLibraryPathInternal.AddRange(withLibraryPath);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithLibraryPath<T>(this T toolSettings, IEnumerable<string> withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithLibraryPathInternal.AddRange(withLibraryPath);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithLibraryPath<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithLibraryPathInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithLibraryPath<T>(this T toolSettings, params string[] withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withLibraryPath);
        toolSettings.WithLibraryPathInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithLibraryPath"/></em></p>
    ///   <p>A library path to be used for the given declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithLibraryPath<T>(this T toolSettings, IEnumerable<string> withLibraryPath) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withLibraryPath);
        toolSettings.WithLibraryPathInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithManualImport
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/> to a new list</em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithManualImport<T>(this T toolSettings, params string[] withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithManualImportInternal = withManualImport.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/> to a new list</em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithManualImport<T>(this T toolSettings, IEnumerable<string> withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithManualImportInternal = withManualImport.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithManualImport<T>(this T toolSettings, params string[] withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithManualImportInternal.AddRange(withManualImport);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithManualImport<T>(this T toolSettings, IEnumerable<string> withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithManualImportInternal.AddRange(withManualImport);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithManualImport<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithManualImportInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithManualImport<T>(this T toolSettings, params string[] withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withManualImport);
        toolSettings.WithManualImportInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithManualImport"/></em></p>
    ///   <p>A remapped function name to be treated as a manual import during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithManualImport<T>(this T toolSettings, IEnumerable<string> withManualImport) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withManualImport);
        toolSettings.WithManualImportInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithNamespace
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/> to a new list</em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithNamespace<T>(this T toolSettings, params string[] withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithNamespaceInternal = withNamespace.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/> to a new list</em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithNamespace<T>(this T toolSettings, IEnumerable<string> withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithNamespaceInternal = withNamespace.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithNamespace<T>(this T toolSettings, params string[] withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithNamespaceInternal.AddRange(withNamespace);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithNamespace<T>(this T toolSettings, IEnumerable<string> withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithNamespaceInternal.AddRange(withNamespace);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithNamespace<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithNamespaceInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithNamespace<T>(this T toolSettings, params string[] withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withNamespace);
        toolSettings.WithNamespaceInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithNamespace"/></em></p>
    ///   <p>A namespace to be used for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithNamespace<T>(this T toolSettings, IEnumerable<string> withNamespace) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withNamespace);
        toolSettings.WithNamespaceInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithPacking
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/> to a new list</em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithPacking<T>(this T toolSettings, params string[] withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithPackingInternal = withPacking.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/> to a new list</em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithPacking<T>(this T toolSettings, IEnumerable<string> withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithPackingInternal = withPacking.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithPacking<T>(this T toolSettings, params string[] withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithPackingInternal.AddRange(withPacking);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithPacking<T>(this T toolSettings, IEnumerable<string> withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithPackingInternal.AddRange(withPacking);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithPacking<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithPackingInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithPacking<T>(this T toolSettings, params string[] withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withPacking);
        toolSettings.WithPackingInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithPacking"/></em></p>
    ///   <p>Overrides the <c>StructLayoutAttribute.Pack</c> property for the given type. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithPacking<T>(this T toolSettings, IEnumerable<string> withPacking) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withPacking);
        toolSettings.WithPackingInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithSetLastError
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/> to a new list</em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithSetLastError<T>(this T toolSettings, params string[] withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSetLastErrorInternal = withSetLastError.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/> to a new list</em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithSetLastError<T>(this T toolSettings, IEnumerable<string> withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSetLastErrorInternal = withSetLastError.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithSetLastError<T>(this T toolSettings, params string[] withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSetLastErrorInternal.AddRange(withSetLastError);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithSetLastError<T>(this T toolSettings, IEnumerable<string> withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSetLastErrorInternal.AddRange(withSetLastError);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithSetLastError<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSetLastErrorInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithSetLastError<T>(this T toolSettings, params string[] withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withSetLastError);
        toolSettings.WithSetLastErrorInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithSetLastError"/></em></p>
    ///   <p>Add the <c>SetLastError=true</c> modifier to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithSetLastError<T>(this T toolSettings, IEnumerable<string> withSetLastError) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withSetLastError);
        toolSettings.WithSetLastErrorInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithSuppressGCTransition
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/> to a new list</em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithSuppressGCTransition<T>(this T toolSettings, params string[] withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSuppressGCTransitionInternal = withSuppressGCTransition.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/> to a new list</em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithSuppressGCTransition<T>(this T toolSettings, IEnumerable<string> withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSuppressGCTransitionInternal = withSuppressGCTransition.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithSuppressGCTransition<T>(this T toolSettings, params string[] withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSuppressGCTransitionInternal.AddRange(withSuppressGCTransition);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithSuppressGCTransition<T>(this T toolSettings, IEnumerable<string> withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSuppressGCTransitionInternal.AddRange(withSuppressGCTransition);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithSuppressGCTransition<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithSuppressGCTransitionInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithSuppressGCTransition<T>(this T toolSettings, params string[] withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withSuppressGCTransition);
        toolSettings.WithSuppressGCTransitionInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithSuppressGCTransition"/></em></p>
    ///   <p>Add the <c>SuppressGCTransition</c> calling convention to a given <c>DllImport</c> or <c>UnmanagedFunctionPointer</c>. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithSuppressGCTransition<T>(this T toolSettings, IEnumerable<string> withSuppressGCTransition) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withSuppressGCTransition);
        toolSettings.WithSuppressGCTransitionInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithTransparentStruct
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/> to a new list</em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithTransparentStruct<T>(this T toolSettings, params string[] withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTransparentStructInternal = withTransparentStruct.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/> to a new list</em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithTransparentStruct<T>(this T toolSettings, IEnumerable<string> withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTransparentStructInternal = withTransparentStruct.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithTransparentStruct<T>(this T toolSettings, params string[] withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTransparentStructInternal.AddRange(withTransparentStruct);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithTransparentStruct<T>(this T toolSettings, IEnumerable<string> withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTransparentStructInternal.AddRange(withTransparentStruct);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithTransparentStruct<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTransparentStructInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithTransparentStruct<T>(this T toolSettings, params string[] withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withTransparentStruct);
        toolSettings.WithTransparentStructInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithTransparentStruct"/></em></p>
    ///   <p>A remapped type name to be treated as a transparent wrapper during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithTransparentStruct<T>(this T toolSettings, IEnumerable<string> withTransparentStruct) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withTransparentStruct);
        toolSettings.WithTransparentStructInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithType
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/> to a new list</em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithType<T>(this T toolSettings, params string[] withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTypeInternal = withType.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/> to a new list</em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithType<T>(this T toolSettings, IEnumerable<string> withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTypeInternal = withType.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithType<T>(this T toolSettings, params string[] withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTypeInternal.AddRange(withType);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithType<T>(this T toolSettings, IEnumerable<string> withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTypeInternal.AddRange(withType);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithType<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithTypeInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithType<T>(this T toolSettings, params string[] withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withType);
        toolSettings.WithTypeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithType"/></em></p>
    ///   <p>A type to be used for the given enum declaration during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithType<T>(this T toolSettings, IEnumerable<string> withType) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withType);
        toolSettings.WithTypeInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
    #region WithUsing
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/> to a new list</em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithUsing<T>(this T toolSettings, params string[] withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithUsingInternal = withUsing.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Sets <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/> to a new list</em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T SetWithUsing<T>(this T toolSettings, IEnumerable<string> withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithUsingInternal = withUsing.ToList();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithUsing<T>(this T toolSettings, params string[] withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithUsingInternal.AddRange(withUsing);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Adds values to <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T AddWithUsing<T>(this T toolSettings, IEnumerable<string> withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithUsingInternal.AddRange(withUsing);
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Clears <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T ClearWithUsing<T>(this T toolSettings) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.WithUsingInternal.Clear();
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithUsing<T>(this T toolSettings, params string[] withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withUsing);
        toolSettings.WithUsingInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    /// <summary>
    ///   <p><em>Removes values from <see cref="ClangSharpPInvokeGeneratorSettings.WithUsing"/></em></p>
    ///   <p>A using directive to be included for the given remapped declaration name during binding generation. Supports wildcards.</p>
    /// </summary>
    [Pure]
    public static T RemoveWithUsing<T>(this T toolSettings, IEnumerable<string> withUsing) where T : ClangSharpPInvokeGeneratorSettings
    {
        toolSettings = toolSettings.NewInstance();
        var hashSet = new HashSet<string>(withUsing);
        toolSettings.WithUsingInternal.RemoveAll(x => hashSet.Contains(x));
        return toolSettings;
    }
    #endregion
}
#endregion
#region ClangSharpPInvokeGeneratorConfigOption
/// <summary>
///   Used within <see cref="ClangSharpPInvokeGeneratorTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ClangSharpPInvokeGeneratorConfigOption>))]
public partial class ClangSharpPInvokeGeneratorConfigOption : Enumeration
{
    public static ClangSharpPInvokeGeneratorConfigOption compatible_codegen = (ClangSharpPInvokeGeneratorConfigOption) "compatible-codegen";
    public static ClangSharpPInvokeGeneratorConfigOption default_codegen = (ClangSharpPInvokeGeneratorConfigOption) "default-codegen";
    public static ClangSharpPInvokeGeneratorConfigOption latest_codegen = (ClangSharpPInvokeGeneratorConfigOption) "latest-codegen";
    public static ClangSharpPInvokeGeneratorConfigOption preview_codegen = (ClangSharpPInvokeGeneratorConfigOption) "preview-codegen";
    public static ClangSharpPInvokeGeneratorConfigOption single_file = (ClangSharpPInvokeGeneratorConfigOption) "single-file";
    public static ClangSharpPInvokeGeneratorConfigOption multi_file = (ClangSharpPInvokeGeneratorConfigOption) "multi-file";
    public static ClangSharpPInvokeGeneratorConfigOption unix_types = (ClangSharpPInvokeGeneratorConfigOption) "unix-types";
    public static ClangSharpPInvokeGeneratorConfigOption windows_types = (ClangSharpPInvokeGeneratorConfigOption) "windows-types";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_anonymous_field_helpers = (ClangSharpPInvokeGeneratorConfigOption) "exclude-anonymous-field-helpers";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_com_proxies = (ClangSharpPInvokeGeneratorConfigOption) "exclude-com-proxies";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_default_remappings = (ClangSharpPInvokeGeneratorConfigOption) "exclude-default-remappings";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_empty_records = (ClangSharpPInvokeGeneratorConfigOption) "exclude-empty-records";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_enum_operators = (ClangSharpPInvokeGeneratorConfigOption) "exclude-enum-operators";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_fnptr_codegen = (ClangSharpPInvokeGeneratorConfigOption) "exclude-fnptr-codegen";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_funcs_with_body = (ClangSharpPInvokeGeneratorConfigOption) "exclude-funcs-with-body";
    public static ClangSharpPInvokeGeneratorConfigOption exclude_using_statics_for_enums = (ClangSharpPInvokeGeneratorConfigOption) "exclude-using-statics-for-enums";
    public static ClangSharpPInvokeGeneratorConfigOption explicit_vtbls = (ClangSharpPInvokeGeneratorConfigOption) "explicit-vtbls";
    public static ClangSharpPInvokeGeneratorConfigOption implicit_vtbls = (ClangSharpPInvokeGeneratorConfigOption) "implicit-vtbls";
    public static ClangSharpPInvokeGeneratorConfigOption trimmable_vtbls = (ClangSharpPInvokeGeneratorConfigOption) "trimmable-vtbls";
    public static ClangSharpPInvokeGeneratorConfigOption generate_tests_nunit = (ClangSharpPInvokeGeneratorConfigOption) "generate-tests-nunit";
    public static ClangSharpPInvokeGeneratorConfigOption generate_tests_xunit = (ClangSharpPInvokeGeneratorConfigOption) "generate-tests-xunit";
    public static ClangSharpPInvokeGeneratorConfigOption generate_aggressive_inlining = (ClangSharpPInvokeGeneratorConfigOption) "generate-aggressive-inlining";
    public static ClangSharpPInvokeGeneratorConfigOption generate_callconv_member_function = (ClangSharpPInvokeGeneratorConfigOption) "generate-callconv-member-function";
    public static ClangSharpPInvokeGeneratorConfigOption generate_cpp_attributes = (ClangSharpPInvokeGeneratorConfigOption) "generate-cpp-attributes";
    public static ClangSharpPInvokeGeneratorConfigOption generate_disable_runtime_marshalling = (ClangSharpPInvokeGeneratorConfigOption) "generate-disable-runtime-marshalling";
    public static ClangSharpPInvokeGeneratorConfigOption generate_doc_includes = (ClangSharpPInvokeGeneratorConfigOption) "generate-doc-includes";
    public static ClangSharpPInvokeGeneratorConfigOption generate_file_scoped_namespaces = (ClangSharpPInvokeGeneratorConfigOption) "generate-file-scoped-namespaces";
    public static ClangSharpPInvokeGeneratorConfigOption generate_guid_member = (ClangSharpPInvokeGeneratorConfigOption) "generate-guid-member";
    public static ClangSharpPInvokeGeneratorConfigOption generate_helper_types = (ClangSharpPInvokeGeneratorConfigOption) "generate-helper-types";
    public static ClangSharpPInvokeGeneratorConfigOption generate_macro_bindings = (ClangSharpPInvokeGeneratorConfigOption) "generate-macro-bindings";
    public static ClangSharpPInvokeGeneratorConfigOption generate_marker_interfaces = (ClangSharpPInvokeGeneratorConfigOption) "generate-marker-interfaces";
    public static ClangSharpPInvokeGeneratorConfigOption generate_native_bitfield_attribute = (ClangSharpPInvokeGeneratorConfigOption) "generate-native-bitfield-attribute";
    public static ClangSharpPInvokeGeneratorConfigOption generate_native_inheritance_attribute = (ClangSharpPInvokeGeneratorConfigOption) "generate-native-inheritance-attribute";
    public static ClangSharpPInvokeGeneratorConfigOption generate_setslastsystemerror_attribute = (ClangSharpPInvokeGeneratorConfigOption) "generate-setslastsystemerror-attribute";
    public static ClangSharpPInvokeGeneratorConfigOption generate_template_bindings = (ClangSharpPInvokeGeneratorConfigOption) "generate-template-bindings";
    public static ClangSharpPInvokeGeneratorConfigOption generate_unmanaged_constants = (ClangSharpPInvokeGeneratorConfigOption) "generate-unmanaged-constants";
    public static ClangSharpPInvokeGeneratorConfigOption generate_vtbl_index_attribute = (ClangSharpPInvokeGeneratorConfigOption) "generate-vtbl-index-attribute";
    public static ClangSharpPInvokeGeneratorConfigOption log_exclusions = (ClangSharpPInvokeGeneratorConfigOption) "log-exclusions";
    public static ClangSharpPInvokeGeneratorConfigOption log_potential_typedef_remappings = (ClangSharpPInvokeGeneratorConfigOption) "log-potential-typedef-remappings";
    public static ClangSharpPInvokeGeneratorConfigOption log_visited_files = (ClangSharpPInvokeGeneratorConfigOption) "log-visited-files";
    public static implicit operator ClangSharpPInvokeGeneratorConfigOption(string value)
    {
        return new ClangSharpPInvokeGeneratorConfigOption { Value = value };
    }
}
#endregion
#region ClangSharpPInvokeGeneratorOutputMode
/// <summary>
///   Used within <see cref="ClangSharpPInvokeGeneratorTasks"/>.
/// </summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ClangSharpPInvokeGeneratorOutputMode>))]
public partial class ClangSharpPInvokeGeneratorOutputMode : Enumeration
{
    public static ClangSharpPInvokeGeneratorOutputMode CSharp = (ClangSharpPInvokeGeneratorOutputMode) "CSharp";
    public static ClangSharpPInvokeGeneratorOutputMode Xml = (ClangSharpPInvokeGeneratorOutputMode) "Xml";
    public static implicit operator ClangSharpPInvokeGeneratorOutputMode(string value)
    {
        return new ClangSharpPInvokeGeneratorOutputMode { Value = value };
    }
}
#endregion
