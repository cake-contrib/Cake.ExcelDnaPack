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
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.ExcelDnaPack
{
    /// <summary>
    /// ExcelDnaPack tool.
    /// </summary>
    public class ExcelDnaPackTool : Tool<ExcelDnaPackSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelDnaPackTool" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public ExcelDnaPackTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, ICakeLog log)
            : base(fileSystem, environment, processRunner, tools)
        {
            CakeLog = log ?? throw new ArgumentNullException(nameof(log));
        }
        
        /// <summary>
        /// Cake log instance.
        /// </summary>
        public ICakeLog CakeLog { get; }

        /// <summary>
        /// Run the ExcelDnaPack tool using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Run(ExcelDnaPackSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            CakeLog.Verbose("Executing {0} tool", GetToolName());

            EnsureSettingsAreValid(settings);

            var args = GetArguments(settings);
            var processSettings = new ProcessSettings();

            Run(settings, args, processSettings, postAction: null);
        }

        /// <inheritdoc />
        protected override string GetToolName()
        {
            return "ExcelDnaPack";
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new [] { "ExcelDnaPack.exe" };
        }

        private static void EnsureSettingsAreValid(ExcelDnaPackSettings settings)
        {
            if (settings.DnaFilePath is null)
            {
                throw new CakeException($"{nameof(settings.DnaFilePath)} setting is required");
            }
        }

        private ProcessArgumentBuilder GetArguments(ExcelDnaPackSettings settings)
        {
            var args = new ProcessArgumentBuilder();

            AppendDnaFilePath(args, settings);
            AppendDisablePromptBeforeOverwrite(args, settings);
            AppendNoCompression(args, settings);
            AppendNoMultiThreading(args, settings);
            AppendOutputXllFilePath(args, settings);

            CakeLog.Verbose("{0} arguments: [{1}]", GetToolName(), args.RenderSafe());

            return args;
        }

        private static void AppendDnaFilePath(ProcessArgumentBuilder args, ExcelDnaPackSettings settings)
        {
            if (settings.DnaFilePath is null)
            {
                return;
            }

            args.AppendQuoted(settings.DnaFilePath.FullPath);
        }

        private static void AppendDisablePromptBeforeOverwrite(ProcessArgumentBuilder args, ExcelDnaPackSettings settings)
        {
            // We inverted ExcelDnaPack's default here which is to always display the interactive prompt unless /Y is specified
            if (settings.PromptBeforeOverwrite.GetValueOrDefault(false))
            {
                return;
            }

            args.Append("/Y");
        }

        private static void AppendNoCompression(ProcessArgumentBuilder args, ExcelDnaPackSettings settings)
        {
            if (!settings.NoCompression.GetValueOrDefault(false))
            {
                return;
            }

            args.Append("/NoCompression");
        }

        private static void AppendNoMultiThreading(ProcessArgumentBuilder args, ExcelDnaPackSettings settings)
        {
            if (!settings.NoMultiThreading.GetValueOrDefault(false))
            {
                return;
            }

            args.Append("/NoMultiThreading");
        }

        private static void AppendOutputXllFilePath(ProcessArgumentBuilder args, ExcelDnaPackSettings settings)
        {
            if (settings.OutputXllFilePath is null)
            {
                return;
            }

            args.Append("/O");
            args.AppendQuoted(settings.OutputXllFilePath.FullPath);
        }
    }
}
