#region Copyright 2021-2022 C. Augusto Proiete & Contributors
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
using Cake.Core.IO;

namespace Cake.ExcelDnaPack
{
    /// <summary>
    /// Extensions for <see cref="ExcelDnaPackSettings" />.
    /// </summary>
    public static class ExcelDnaPackSettingsExtensions
    {
        /// <summary>
        /// Set the path to the primary .dna file for the Excel-DNA add-in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="dnaFilePath">The path to the primary .dna file for the Excel-DNA add-in</param>
        /// <returns>The <paramref name="settings" /> instance with <see cref="ExcelDnaPackSettings.DnaFilePath" /> set to <paramref name="dnaFilePath" />.</returns>
        public static ExcelDnaPackSettings SetDnaFilePath(this ExcelDnaPackSettings settings, FilePath dnaFilePath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.DnaFilePath = dnaFilePath;

            return settings;
        }

        /// <summary>
        /// Enable interactive prompt to overwrite the output .xll file, if it already exists.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings" /> instance with <see cref="ExcelDnaPackSettings.PromptBeforeOverwrite" /> set to <see langword="true" />.</returns>
        public static ExcelDnaPackSettings PromptBeforeOverwrite(this ExcelDnaPackSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.PromptBeforeOverwrite = true;

            return settings;
        }

        /// <summary>
        /// Disable compression (LZMA) of resources
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings" /> instance with <see cref="ExcelDnaPackSettings.NoCompression" /> set to <see langword="true" />.</returns>
        public static ExcelDnaPackSettings NoCompression(this ExcelDnaPackSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.NoCompression = true;

            return settings;
        }

        /// <summary>
        /// Disable multi-threading to ensure deterministic order of packing
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings" /> instance with <see cref="ExcelDnaPackSettings.NoMultiThreading" /> set to <see langword="true" />.</returns>
        public static ExcelDnaPackSettings NoMultiThreading(this ExcelDnaPackSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.NoMultiThreading = true;

            return settings;
        }

        /// <summary>
        /// Set the output path for the packed .xll file. Default is <see cref="ExcelDnaPackSettings.DnaFilePath" />-packed.xll.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="outputXllFilePath">The output path for the packed .xll file.</param>
        /// <returns>The <paramref name="settings" /> instance with <see cref="ExcelDnaPackSettings.OutputXllFilePath" /> set to <paramref name="outputXllFilePath" />.</returns>
        public static ExcelDnaPackSettings SetOutputXllFilePath(this ExcelDnaPackSettings settings, FilePath outputXllFilePath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.OutputXllFilePath = outputXllFilePath;

            return settings;
        }
    }
}
