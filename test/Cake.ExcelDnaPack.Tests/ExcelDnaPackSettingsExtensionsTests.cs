// Copyright 2021 C. Augusto Proiete & Contributors
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

using Cake.Core.IO;
using FluentAssertions;
using Xunit;

namespace Cake.ExcelDnaPack.Tests
{
    public sealed class ExcelDnaPackSettingsExtensionsTests
    {
        [Fact]
        public void Should_Set_DnaFilePath_via_SetDnaFilePath()
        {
            var settings = new ExcelDnaPackSettings()
                .SetDnaFilePath("MyAddin.dna");

            settings.DnaFilePath.FullPath.Should().Be(FilePath.FromString("MyAddin.dna").FullPath);
        }

        [Fact]
        public void Should_Set_PromptBeforeOverwrite_via_PromptBeforeOverwrite()
        {
            var settings = new ExcelDnaPackSettings()
                .PromptBeforeOverwrite();

            settings.PromptBeforeOverwrite.Should().Be(true);
        }

        [Fact]
        public void Should_Set_NoCompression_via_NoCompression()
        {
            var settings = new ExcelDnaPackSettings()
                .NoCompression();

            settings.NoCompression.Should().Be(true);
        }

        [Fact]
        public void Should_Set_NoMultiThreading_via_NoMultiThreading()
        {
            var settings = new ExcelDnaPackSettings()
                .NoMultiThreading();

            settings.NoMultiThreading.Should().Be(true);
        }

        [Fact]
        public void Should_Set_OutputXllFilePath_via_SetOutputXllFilePath()
        {
            var settings = new ExcelDnaPackSettings()
                .SetOutputXllFilePath("MyAddin-packed.xll");

            settings.OutputXllFilePath.FullPath.Should().Be(FilePath.FromString("MyAddin-packed.xll").FullPath);
        }
    }
}
