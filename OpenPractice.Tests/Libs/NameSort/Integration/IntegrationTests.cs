using System;
using Xunit;

namespace Integration
{
    public class IntegrationTests
    {
        [Fact]
        public void ProgramPrintsUsageWithoutArgs()
        {
            System.Diagnostics.Process name_sorter_proc = new System.Diagnostics.Process();
            name_sorter_proc.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            name_sorter_proc.StartInfo.RedirectStandardOutput = true;
            name_sorter_proc.Start();
            string output = name_sorter_proc.StandardOutput.ReadToEnd();
            name_sorter_proc.WaitForExit();
            Assert.Matches("usage information", output);
        }

        [Fact]
        public void ProgramProcessesEmptyFile()
        {
            System.Diagnostics.Process name_sorter_proc = new System.Diagnostics.Process();
            name_sorter_proc.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            string[] blank_line = { "" };
            System.IO.File.WriteAllLines(@"blank.txt", blank_line);
            name_sorter_proc.StartInfo.Arguments = "../../../../../../../OpenPractice.Tests/Libs/NameSort/Integration/bin/Debug/netcoreapp2.0/blank.txt";
            name_sorter_proc.StartInfo.RedirectStandardOutput = true;
            name_sorter_proc.Start();
            string output = name_sorter_proc.StandardOutput.ReadToEnd();
            name_sorter_proc.WaitForExit();
            Assert.Equal("", output);
            // read file output file assert too
        }
    }
}
