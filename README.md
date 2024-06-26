# SDL2Sharp

SDL2Sharp provides SDL2 bindings written in C#.

[![release](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/release.yml/badge.svg)](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/release.yml)
[![test-ubuntu](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/test-ubuntu.yml/badge.svg)](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/test-ubuntu.yml)
[![test-windows](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/test-windows.yml/badge.svg)](https://github.com/ronaldvanmanen/SDL2Sharp/actions/workflows/test-windows.yml)

## Table of Contents

* [Code of Conduct](#code-of-conduct)
* [License](#license)
* [Languages and Frameworks](#languages-and-frameworks)
* [Building](#building)

### Code of Conduct

This project has adopted the [Contributor Covenant Code of Conduct](https://www.contributor-covenant.org/version/2/0/code_of_conduct/). For more information see the [Contributor Convenant FAQ](https://www.contributor-covenant.org/faq/).

### License

Copyright (c) 2021-2024 Ronald van Manen. All rights reserved.
Licensed under the z-lib license.
See [LICENSE](LICENSE) in the project root for license information.

### Languages and Frameworks

SDL2Sharp uses C# as its primary development language and .NET Standard 2.0 as its primary target framework.

### Building

SDL2Sharp requires the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and can be built simply with `dotnet build -c Release`.

You can reproduce what the CI environment does by running `./build.cmd` on Windows or `./build.sh` on Linux.
This will download the required .NET SDKs locally and use that to build the repo; it will also run through all available actions in the appropriate order.

You can see any additional options that are available by passing `--help`.
