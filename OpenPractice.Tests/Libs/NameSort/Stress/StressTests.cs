using System;
using Xunit;
using System.Text;

namespace Stress
{
    public class StressTests
    {
        private static System.Diagnostics.Process _name_sorter;
        private static Random random;
        private static string name_characters;

        public StressTests()
        {
            random = new Random();
            name_characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.,()_'";
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

        private string GenerateName(int max_characters_in_name)
        {
            StringBuilder name = new StringBuilder();
            int name_count = random.Next(4)+1;
            for (int i = 0; i < name_count; i++)
            {
                int character_count = random.Next(max_characters_in_name)+1;
                for (int j = 0; j < character_count; j++)
                {
                    name.Append(name_characters[random.Next(name_characters.Length)]);
                }
                if(i < (name_count - 1))
                {
                    name.Append(" ");
                }
            }
            return name.ToString();
        }

        private string[] GenerateNames(int name_count, int max_characters_in_name = 100)
        {
            string[] random_names = new string[name_count];
            for(var i = 0; i < name_count; i++)
            {
                random_names[i] = GenerateName(max_characters_in_name);
            }
            return random_names;
        }

        [Fact]
        public void HandlesLongNamesWithoutLoss()
        {
            string[] file_of_names = GenerateNames(20, 2000000);
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
        public void Handles1000NamesWithoutLoss()
        {
            string[] file_of_names = GenerateNames(1000);
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
            string[] file_of_names = GenerateNames(1000000);
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

        [Fact]
        public void Handles2000000NamesWithoutLoss()
        {
            string[] file_of_names = GenerateNames(2000000);
            System.IO.File.WriteAllLines(@"2000000.txt", file_of_names);
            _name_sorter.StartInfo.Arguments = "2000000.txt";
            _name_sorter.Start();
            string console_output = _name_sorter.StandardOutput.ReadToEnd();
            _name_sorter.WaitForExit();
            Assert.True(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output_file_lines = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.Equal(file_of_names.Length, output_file_lines.Length);
            Assert.Equal(String.Concat(file_of_names).Length, String.Concat(output_file_lines).Length);
            System.IO.File.Delete(@"2000000.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }

        [Fact]
        public void Handles100FilesWithoutLoss()
        {
            for(int i =0; i < 100; i++)
            {
                string[] file_of_names = GenerateNames(1000);
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
            }
            System.IO.File.Delete(@"sorted-names-list.txt");
        }
    }
}
