using System;
using Xunit;
using TestHelpers;

namespace Stress
{
    public class FileCountTests
    {
        private static System.Diagnostics.Process _name_sorter;

        public FileCountTests()
        {
            _name_sorter = SortBuilder.PrepareNameSorterProcess(_name_sorter);
        }

       [Fact]
        public void Handles1000NamesWithoutLoss()
        {
            string[] file_of_names = DataGenerator.Names(1000);
            System.IO.File.WriteAllLines(@"1000.txt", file_of_names);
            _name_sorter.StartInfo.Arguments = "1000.txt";
            _name_sorter.Start();
            string console_output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(file_of_names.Length, output_file_lines.Length);
            Assert.Equal(String.Concat(file_of_names).Length, String.Concat(output_file_lines).Length);
            System.IO.File.Delete(@"1000.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }

        [Fact]
        public void Handles1000000NamesWithoutLoss()
        {
            string[] file_of_names = DataGenerator.Names(1000000);
            System.IO.File.WriteAllLines(@"1000000.txt", file_of_names);
            _name_sorter.StartInfo.Arguments = "1000000.txt";
            _name_sorter.Start();
            string console_output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(file_of_names.Length, output_file_lines.Length);
            Assert.Equal(String.Concat(file_of_names).Length, String.Concat(output_file_lines).Length);
            System.IO.File.Delete(@"1000000.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }
    }
}
