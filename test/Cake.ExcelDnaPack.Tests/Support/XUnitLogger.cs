﻿#region Copyright 2021-2022 C. Augusto Proiete & Contributors
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
using Xunit.Abstractions;

namespace Cake.ExcelDnaPack.Tests.Support
{
    internal class XUnitLogger : ICakeLog
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public XUnitLogger(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
            Verbosity = Verbosity.Diagnostic;
        }

        public void Write(Verbosity verbosity, LogLevel level, string format, params object[] args)
        {
            if ((int)verbosity <= (int)Verbosity)
            {
                _testOutputHelper.WriteLine($"[{level}] {format}", args);
            }
        }

        public Verbosity Verbosity { get; set; }
    }
}
