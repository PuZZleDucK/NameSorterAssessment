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
                System.Console.WriteLine(":: NameSorter ::");
                System.Console.WriteLine(NameSorter.ProgramUsageText());
                Environment.Exit(-1);
            }
            if (System.IO.File.Exists(args[0]))
            {
                NameSorter name_sorter = new NameSorter();
                string[] sorted_names = name_sorter.SortNames(System.IO.File.ReadAllLines(args[0]));
                if (Platform.IsPosix)
                {
                    System.Console.WriteLine(String.Join("\n", sorted_names));
                } else {
                    System.Console.WriteLine(String.Join("\r\n", sorted_names));
                }
                System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);
            } else
            {
                System.Console.WriteLine(":: NameSorter ::");
                System.Console.WriteLine(NameSorter.ProgramUsageText());
                System.Console.WriteLine($" The file '{args[0]}' was not found!");
                Environment.Exit(-1);
            }
            Environment.Exit(0);
        }
    }
}
