| README.md |
|:---|

<div align="center">

![Cake.ExcelDnaPack](asset/cake-exceldnapack-logo.png)

</div>

<h1 align="center">Cake.ExcelDnaPack</h1>
<div align="center">

Addin for the [Cake](https://cakebuild.net) build automation system that enables you to use [ExcelDnaPack](https://github.com/augustoproiete/ExcelDnaPack-NuGet) for packing Excel-DNA addins into a single .xll file. Cake.ExcelDnaPack targets .NET 5.0, .NET Standard 2.0 and .NET Framework 4.6.1, and runs on Windows.

[![NuGet Version](https://img.shields.io/nuget/v/Cake.ExcelDnaPack.svg?color=blue&style=flat-square)](https://www.nuget.org/packages/Cake.ExcelDnaPack/) [![Stack Overflow Cake Build](https://img.shields.io/badge/stack%20overflow-cakebuild-orange.svg?style=flat-square)](http://stackoverflow.com/questions/tagged/cakebuild) [![Stack Overflow Excel-DNA](https://img.shields.io/badge/stack%20overflow-excel--dna-orange.svg?style=flat-square)](http://stackoverflow.com/questions/tagged/excel-dna)

</div>

## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

## Getting started :rocket:

This addin exposes the functionality of [ExcelDnaPack](https://github.com/augustoproiete/ExcelDnaPack-NuGet) to the Cake DSL by being a very thin wrapper around its command line interface; this means that you can use Cake.ExcelDnaPack in the same way as you would normally use [ExcelDnaPack](https://github.com/augustoproiete/ExcelDnaPack-NuGet#exceldnapack-usage), but with a Cake-friendly interface.

First of all, you need make the ExcelDnaPack tool available to your Cake build process by using the [`tool`](http://cakebuild.net/docs/writing-builds/preprocessor-directives#tool-directive) directive:

```csharp
#tool "nuget:?package=ExcelDnaPack&version=1.5.1"
```

_Make sure the `&version=` attribute references the [latest version of ExcelDnaPack](https://www.nuget.org/packages/ExcelDnaPack/) available on [nuget.org](https://www.nuget.org)_.

Then, you need to load Cake.ExcelDnaPack in your build script by using the [`addin`](http://cakebuild.net/docs/writing-builds/preprocessor-directives#add-in-directive) directive:

```csharp
#addin "nuget:?package=Cake.ExcelDnaPack&version=2.0.0"
```

_Make sure the `&version=` attribute references the [latest version of Cake.ExcelDnaPack](https://www.nuget.org/packages/Cake.ExcelDnaPack/) compatible with the Cake runner that you are using. Check the [compatibility table](#compatibility) to see which version of Cake.ExcelDnaPack to choose__.

Finally, call `ExcelDnaPack()` in order to pack all the files that compose your Excel-DNA addin into a single file:

```csharp
#tool "nuget:?package=ExcelDnaPack&version=1.5.1"
#addin "nuget:?package=Cake.ExcelDnaPack&version=2.0.0"

Task("Example")
    .Does(context =>
{
    ExcelDnaPack("MyAddin.dna");
});

RunTarget("Example");
```

## ExcelDnaPack settings you can customize

| Property              | Type            | Description                                                                       |
| --------------------- | --------------- | --------------------------------------------------------------------------------- |
| DnaFilePath           | [`FilePath`][1] | The path to the primary .dna file for the Excel-DNA add-in. e.g. `MyAddin.dna`    |
| PromptBeforeOverwrite | `bool?`         | Enable interactive prompt to overwrite the output .xll file, if it already exists |
| NoCompression         | `bool?`         | Disable compression (LZMA) of resources                                           |
| NoMultiThreading      | `bool?`         | Disable multi-threading to ensure deterministic order of packing                  |
| OutputXllFilePath     | [`FilePath`][1] | The output path for the packed .xll file                                          |

[1]: https://cakebuild.net/api/Cake.Core.IO/FilePath/ "Cake.Core.IO.FilePath"

By default, the `ExcelDnaPack` tool prompts the user before overwriting an existing `.xll` output file unless the `/Y` argument is specified. Because `Cake.ExcelDnaPack` is designed to be used in build scenarios (usually non-interactive) it sets `/Y` by default, to overwrite the output `.xll` file if it already exists, in order to suppress the interactive prompt. To change this behavior set `PromptBeforeOverwrite` to `true`.

For more details on how `ExcelDnaPack` works,  check its [documentation](https://github.com/augustoproiete/ExcelDnaPack-NuGet#usage).

### Using Cake.ExcelDnaPack with custom settings

You can define your settings using an instance of `ExcelDnaPackSettings`, for example:

```csharp
var settings = new ExcelDnaPackSettings
{
    DnaFilePath = @"C:\MyProject\MyAddin.dna",
    PromptBeforeOverwrite = true,
    NoCompression = true,
    NoMultiThreading = true,
    OutputXllFilePath = @"C:\MyProject\MyAddin-SingleFile.xll",
};

ExcelDnaPack(settings);
```

Alternatively, you can define your settings using Cake's configurator pattern:

```csharp
ExcelDnaPack(@"C:\MyProject\MyAddin.dna", settings => settings
    .PromptBeforeOverwrite()
    .NoCompression()
    .NoMultiThreading()
    .SetOutputXllFilePath(@"C:\MyProject\MyAddin-SingleFile.xll")
);
```

## Compatibility

Cake.ExcelDnaPack is compatible with all [Cake runners](https://cakebuild.net/docs/running-builds/runners/), and below you can find which version of Cake.ExcelDnaPack you should use based on the version of the Cake runner you're using.

| Cake runner     | Cake.ExcelDnaPack | Cake addin directive                                      |
|:---------------:|:-----------------:| --------------------------------------------------------- |
| 2.0.0 or higher | 2.0.0 or higher   | `#addin "nuget:?package=Cake.ExcelDnaPack&version=2.0.0"` |
| 1.0.0 - 1.3.0   | 1.0.0 - 1.0.1     | `#addin "nuget:?package=Cake.ExcelDnaPack&version=1.0.1"` |
| 0.33.0 - 0.38.5 | 0.1.0             | `#addin "nuget:?package=Cake.ExcelDnaPack&version=0.1.0"` |
| < 0.33.0        | _N/A_             | _(not supported)_                                         |

## Discussion

For questions and to discuss ideas & feature requests, use the [GitHub discussions on the Cake GitHub repository](https://github.com/cake-build/cake/discussions), under the [Extension Q&A](https://github.com/cake-build/cake/discussions/categories/extension-q-a) category.

[![Join in the discussion on the Cake repository](https://img.shields.io/badge/GitHub-Discussions-green?logo=github)](https://github.com/cake-build/cake/discussions)

## Release History

Click on the [Releases](https://github.com/cake-contrib/Cake.ExcelDnaPack/releases) tab on GitHub.

---

_Copyright &copy; 2021-2022 C. Augusto Proiete & Contributors - Provided under the [MIT License](LICENSE)._
