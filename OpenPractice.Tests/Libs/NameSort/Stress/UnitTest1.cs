using System;
using Xunit;

namespace Stress
{
    public class StressTests
    {
        private static System.Diagnostics.Process _name_sorter;

        public StressTests()
        {
            if (_name_sorter == null) {
                System.Diagnostics.Process _name_sort_builder;
                _name_sort_builder = new System.Diagnostics.Process();
                _name_sort_builder.StartInfo.FileName = @"dotnet";
                _name_sort_builder.StartInfo.Arguments = "publish -c Release -r ubuntu.14.04-x64 ../../../../../../../OpenPractice/Demos/name-sorter";
                _name_sort_builder.Start();
                _name_sort_builder.WaitForExit();
            }
            _name_sorter = new System.Diagnostics.Process();
            _name_sorter.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            _name_sorter.StartInfo.RedirectStandardOutput = true;
        }

        [Fact]
        public void NotSoStressful()
        {
            _name_sorter.StartInfo.Arguments = "";
            _name_sorter.Start();
            string output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.Equal("usage information", output);
        }
    }
}
