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
            name_sorter_proc.StartInfo.FileName = @"dotnet";
            name_sorter_proc.StartInfo.Arguments = "run --project ../../../../../../../OpenPractice/Demos/name-sorter/";
            // name_sorter_proc.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
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
            // name_sorter_proc.StartInfo.FileName = @"dotnet";
            // name_sorter_proc.StartInfo.Arguments = "run --project ../../../../../../../OpenPractice/Demos/name-sorter/ blank.txt";
            name_sorter_proc.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            name_sorter_proc.StartInfo.Arguments = "blank.txt";
            string[] blank_line = { "" };
            System.IO.File.WriteAllLines(@"blank.txt", blank_line);
            name_sorter_proc.StartInfo.Arguments = "blank.txt";
            name_sorter_proc.StartInfo.RedirectStandardOutput = true;
            name_sorter_proc.Start();
            string console_output = name_sorter_proc.StandardOutput.ReadToEnd();
            name_sorter_proc.WaitForExit();
            System.IO.File.Delete(@"blank.txt");
            Assert.Equal("", console_output);
            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(blank_line, output_file_lines);
            System.IO.File.Delete(@"sorted-names-list.txt");
        }
    }
}
