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
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.ExcelDnaPack.Tests.Support;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Cake.ExcelDnaPack.Tests
{
    public sealed class ExcelDnaPackToolTests
    {
        private readonly ICakeLog _log;

        public ExcelDnaPackToolTests(ITestOutputHelper testOutputHelper)
        {
            _log = new XUnitLogger(testOutputHelper);
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings = null,
            };

            fixture.Invoking(f => f.Run())
                .Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().Be("settings");
        }

        [Fact]
        public void Should_Throw_If_DnaFilePath_Is_Null()
        {
            var fixture = new ExcelDnaPackToolFixture(_log);

            fixture.Invoking(f => f.Run())
                .Should().ThrowExactly<CakeException>()
                .And.Message.Should().Be($"{nameof(ExcelDnaPackSettings.DnaFilePath)} setting is required");
        }

        [Fact]
        public void Should_Add_Required_DnaFilePath_and_Disable_PromptBeforeOverwrite_By_Default()
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings =
                {
                    DnaFilePath = "MyAddin.dna",
                },
            };

            var result = fixture.Run();

            Assert.Equal(@"""MyAddin.dna"" /Y", result.Args);
        }

        [Theory]
        [InlineData(true, "")]
        [InlineData(false, " /Y")]
        [InlineData(null, " /Y")]
        public void Should_Add_OverwriteXllIfExists_To_Arguments_If_true(bool? promptBeforeOverwrite, string expected)
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings =
                {
                    DnaFilePath = "MyAddin.dna",
                    PromptBeforeOverwrite = promptBeforeOverwrite,
                },
            };

            var result = fixture.Run();

            Assert.Equal($@"""MyAddin.dna""{expected}", result.Args);
        }

        [Theory]
        [InlineData(true, " /NoCompression")]
        [InlineData(false, "")]
        [InlineData(null, "")]
        public void Should_Add_NoCompression_To_Arguments_If_true(bool? noCompression, string expected)
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings =
                {
                    DnaFilePath = "MyAddin.dna",
                    NoCompression = noCompression,
                },
            };

            var result = fixture.Run();

            Assert.Equal($@"""MyAddin.dna"" /Y{expected}", result.Args);
        }

        [Theory]
        [InlineData(true, " /NoMultiThreading")]
        [InlineData(false, "")]
        [InlineData(null, "")]
        public void Should_Add_NoMultiThreading_To_Arguments_If_true(bool? noMultiThreading, string expected)
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings =
                {
                    DnaFilePath = "MyAddin.dna",
                    NoMultiThreading = noMultiThreading,
                },
            };

            var result = fixture.Run();

            Assert.Equal($@"""MyAddin.dna"" /Y{expected}", result.Args);
        }

        [Theory]
        [InlineData("MyAddin-packed.xll", @" /O ""MyAddin-packed.xll""")]
        [InlineData(null, "")]
        public void Should_Add_OutputXllFilePath_To_Arguments_If_true(string outputXllFilePath, string expected)
        {
            var fixture = new ExcelDnaPackToolFixture(_log)
            {
                Settings =
                {
                    DnaFilePath = "MyAddin.dna",
                    OutputXllFilePath = outputXllFilePath,
                },
            };

            var result = fixture.Run();

            Assert.Equal($@"""MyAddin.dna"" /Y{expected}", result.Args);
        }
    }
}
