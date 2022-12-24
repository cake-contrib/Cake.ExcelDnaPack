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

using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.ExcelDnaPack
{
    /// <summary>
    /// Contains settings used by <see cref="ExcelDnaPackTool" />.
    /// </summary>
    public class ExcelDnaPackSettings : ToolSettings
    {
        /// <summary>
        /// The path to the primary .dna file for the Excel-DNA add-in.
        /// </summary>
        public FilePath DnaFilePath { get; set; }

        /// <summary>
        /// Enable interactive prompt to overwrite the output .xll file, if it already exists.
        /// Defaults to <see langword="false" /> if <see langword="null" />.
        /// </summary>
        public bool? PromptBeforeOverwrite { get; set; }

        /// <summary>
        /// Disable compression (LZMA) of resources.
        /// </summary>
        public bool? NoCompression { get; set; }

        /// <summary>
        /// Disable multi-threading to ensure deterministic order of packing.
        /// </summary>
        public bool? NoMultiThreading { get; set; }

        /// <summary>
        /// The output path for the packed .xll file. Default is <see cref="DnaFilePath" />-packed.xll.
        /// </summary>
        public FilePath OutputXllFilePath { get; set; }
    }
}
