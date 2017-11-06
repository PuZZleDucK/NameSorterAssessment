using System;
using NameSort;

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
                System.Console.WriteLine(String.Join('\n', sorted_names));
                System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);

            }
        }
    }
}
