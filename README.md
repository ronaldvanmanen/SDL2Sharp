# SDL2Sharp

SDL2Sharp provides SDL2 bindings written in C#.

[![.NET](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/dotnet.yml)

## Table of Contents

* [Code of Conduct](#code-of-conduct)
* [License](#license)

### Code of Conduct

This project has adopted the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/version/2/0/code_of_conduct/). For more information see the [Contributor Convenant FAQ](https://www.contributor-covenant.org/faq/).

### License

Copyright (c) Ronald van Manen. All rights reserved.
Licensed under the z-lib license.
See [LICENSE](LICENSE) in the project root for license information.

### Languages and Frameworks

SDL2Sharp uses C# as its primary development language and .NET 5 as its primary target framework.

### Building

SDL2Sharp requires the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) and can be built simply with `dotnet build -c Release`.

You can reproduce what the CI environment does by running `./scripts/cibuild.cmd` on Windows.
This will download the required .NET SDK locally and use that to build the repo; it will also run through all available actions in the appropriate order.

There are also several build scripts in the repository root. On Windows these scripts end with `.cmd` and expect arguments with a `-` prefix.
By default, each script performs only the action specified in its name (i.e. `restore` only restores, `build` only builds, `test` only tests, and `pack` only packs). You can specify additional actions to be run by passing that name as an argument to the script (e.g. `build.cmd -restore` will perform a package restore and build; `test.cmd -pack` will run tests and package artifacts).
Certain actions are dependent on a previous action having been run at least once. `build` depends on `restore`, `test` depends on `build`, and `pack` depends on `build`. This means the recommended first time action is `build -restore`.

You can see any additional options that are available by passing `-help` on Windows.
