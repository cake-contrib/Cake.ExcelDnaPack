#region Copyright 2021 C. Augusto Proiete & Contributors
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
using Cake.Core.Diagnostics;
using Cake.Testing.Fixtures;

namespace Cake.ExcelDnaPack.Tests.Support
{
    internal sealed class ExcelDnaPackToolFixture : ToolFixture<ExcelDnaPackSettings>
    {
        public ExcelDnaPackToolFixture(ICakeLog log)
            : base("ExcelDnaPack.exe")
        {
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ICakeLog Log { get; }

        protected override void RunTool()
        {
            var tool = new ExcelDnaPackTool(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Run(Settings);
        }
    }
}
