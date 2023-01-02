#region Copyright 2021-2023 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.ExcelDnaPack
{
    /// <summary>
    /// ExcelDnaPack aliases
    /// </summary>
    [CakeAliasCategory("ExcelDnaPack")]
    [CakeNamespaceImport("Cake.ExcelDnaPack")]
    public static class ExcelDnaPackAliases
    {
        /// <summary>
        /// Run the ExcelDnaPack tool with default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dnaFilePath">The path to the primary .dna file for the Excel-DNA add-in.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack("MyAddin.dna");
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("ExcelDnaPack")]
        public static void ExcelDnaPack(this ICakeContext context, FilePath dnaFilePath)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (dnaFilePath is null)
            {
                throw new ArgumentNullException(nameof(dnaFilePath));
            }

            var settings = new ExcelDnaPackSettings
            {
                DnaFilePath = dnaFilePath,
            };

            context.ExcelDnaPack(settings);
        }

        /// <summary>
        /// Run the ExcelDnaPack tool using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="dnaFilePath">The path to the primary .dna file for the Excel-DNA add-in.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Enable interactive prompt to overwrite the output .xll file, if it already exists</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack("MyAddin.dna", settings => settings
        ///     .PromptBeforeOverwrite()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable compression (LZMA) of resources (e.g. `/NoCompression`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack("MyAddin.dna", settings => settings
        ///     .NoCompression()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable multi-threading to ensure deterministic order of packing (e.g. `/NoMultiThreading`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack("MyAddin.dna", settings => settings
        ///     .NoMultiThreading()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>The output path for the packed .xll file (e.g. `/O MyAddin-x86-packed.xll`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack("MyAddin.dna", settings => settings
        ///     .SetOutputXllFilePath("MyAddin-x86-packed.xll")
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("ExcelDnaPack")]
        public static void ExcelDnaPack(this ICakeContext context, FilePath dnaFilePath, Action<ExcelDnaPackSettings> configurator)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (dnaFilePath is null)
            {
                throw new ArgumentNullException(nameof(dnaFilePath));
            }

            if (configurator is null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new ExcelDnaPackSettings
            {
                DnaFilePath = dnaFilePath,
            };

            configurator(settings);

            context.ExcelDnaPack(settings);
        }

        /// <summary>
        /// Run the ExcelDnaPack tool using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Enable interactive prompt to overwrite the output .xll file, if it already exists</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack(settings => settings
        ///     .SetDnaFilePath("MyAddin.dna")
        ///     .PromptBeforeOverwrite()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable compression (LZMA) of resources (e.g. `/NoCompression`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack(settings => settings
        ///     .SetDnaFilePath("MyAddin.dna")
        ///     .NoCompression()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable multi-threading to ensure deterministic order of packing (e.g. `/NoMultiThreading`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack(settings => settings
        ///     .SetDnaFilePath("MyAddin.dna")
        ///     .NoMultiThreading()
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// <para>The output path for the packed .xll file (e.g. `/O MyAddin-x86-packed.xll`)</para>
        /// <code>
        /// <![CDATA[
        /// ExcelDnaPack(settings => settings
        ///     .SetDnaFilePath("MyAddin.dna")
        ///     .SetOutputXllFilePath("MyAddin-x86-packed.xll")
        /// );
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("ExcelDnaPack")]
        public static void ExcelDnaPack(this ICakeContext context, Action<ExcelDnaPackSettings> configurator)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator is null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new ExcelDnaPackSettings();
            configurator(settings);

            context.ExcelDnaPack(settings);
        }

        /// <summary>
        /// Run the ExcelDnaPack tool using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Enable interactive prompt to overwrite the output .xll file, if it already exists</para>
        /// <code>
        /// <![CDATA[
        /// var settings = new ExcelDnaPackSettings
        /// {
        ///     DnaFilePath = "MyAddin.dna",
        ///     PromptBeforeOverwrite = true,
        /// };
        /// 
        /// ExcelDnaPack(settings);
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable compression (LZMA) of resources (e.g. `/NoCompression`)</para>
        /// <code>
        /// <![CDATA[
        /// var settings = new ExcelDnaPackSettings
        /// {
        ///     DnaFilePath = "MyAddin.dna",
        ///     NoCompression = true,
        /// };
        /// 
        /// ExcelDnaPack(settings);
        /// // ...
        /// ]]>
        /// </code>
        /// <para>Disable multi-threading to ensure deterministic order of packing (e.g. `/NoMultiThreading`)</para>
        /// <code>
        /// <![CDATA[
        /// var settings = new ExcelDnaPackSettings
        /// {
        ///     DnaFilePath = "MyAddin.dna",
        ///     NoMultiThreading = true,
        /// };
        /// 
        /// ExcelDnaPack(settings);
        /// // ...
        /// ]]>
        /// </code>
        /// <para>The output path for the packed .xll file (e.g. `/O MyAddin-x86-packed.xll`)</para>
        /// <code>
        /// <![CDATA[
        /// var settings = new ExcelDnaPackSettings
        /// {
        ///     DnaFilePath = "MyAddin.dna",
        ///     OutputXllFilePath = "MyAddin-x86-packed.xll",
        /// };
        /// 
        /// ExcelDnaPack(settings);
        /// // ...
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("ExcelDnaPack")]
        public static void ExcelDnaPack(this ICakeContext context, ExcelDnaPackSettings settings)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddInInformation.LogVersionInformation(context.Log);

            var excelDnaPack = new ExcelDnaPackTool(context.FileSystem, context.Environment, context.ProcessRunner,
                context.Tools, context.Log);

            excelDnaPack.Run(settings);
        }
    }
}
