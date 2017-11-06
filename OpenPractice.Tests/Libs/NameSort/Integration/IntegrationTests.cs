using System;
using Xunit;
using System.Collections.Generic;

namespace Integration
{
    public class IntegrationTests
    {
        private static System.Diagnostics.Process _name_sorter;

        public IntegrationTests()
        {
            // build is running for every example... remove and only run once
            if (_name_sorter == null) {
                System.Console.WriteLine($".. :: BUILDING RELEASE :: ..");
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
        public void ProgramPrintsUsageWithoutArgs()
        {
            _name_sorter.StartInfo.Arguments = "";
            _name_sorter.Start();
            string output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.Matches("usage information", output);
        }

        [Fact]
        public void ProgramProcessesEmptyFile()
        {
            string[] blank_line = { "" };
            System.IO.File.WriteAllLines(@"blank.txt", blank_line);
            _name_sorter.StartInfo.Arguments = "blank.txt";
            _name_sorter.Start();
            string console_output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.Equal("", console_output);
            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(blank_line, output_file_lines);
            System.IO.File.Delete(@"blank.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }

        [Theory]
        [InlineData("01-empty-file")]
        [InlineData("02-single-first-name-only")]
        [InlineData("03-single-full-name")]
        [InlineData("04-two-names-in-order")]
        [InlineData("05-two-names-reversed")]
        [InlineData("06-provided-example")]
        public void ProgramProcessesExampleFiles(string example_file)
        {
            string[] expected_output = System.IO.File.ReadAllLines($"../../../../../../../OpenPractice/Demos/name-sorter/examples/{example_file}-expected-output.txt");
            // append -expected-output for results
            System.Console.WriteLine($":: example_file: {example_file}");
            System.Console.WriteLine($"::    expected_output: {String.Join(" -> ", expected_output)}");
        }

    }
}
