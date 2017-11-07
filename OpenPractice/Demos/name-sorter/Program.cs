using System;
using NameSort;
using Helpers;

namespace name_sorter
{
    class Program
    {
       static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                // No argument given... print help and error out.
                System.Console.WriteLine(":: NameSorter ::");
                System.Console.WriteLine(NameSorter.ProgramUsageText());
                Environment.Exit(-1);
            }
            if (System.IO.File.Exists(args[0]))
            {
                var name_sorter = new NameSorter();
                string[] sorted_names = name_sorter.SortNames(System.IO.File.ReadAllLines(args[0]));
                System.Console.WriteLine(String.Join(Platform.Delimiter, sorted_names));
                System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);
            } else {
                // Invalid file given... print help and error out.
                System.Console.WriteLine(":: NameSorter ::");
                System.Console.WriteLine(NameSorter.ProgramUsageText());
                System.Console.WriteLine($" The file '{args[0]}' was not found!");
                Environment.Exit(-1);
            }
            Environment.Exit(0);
        }
    }
}
