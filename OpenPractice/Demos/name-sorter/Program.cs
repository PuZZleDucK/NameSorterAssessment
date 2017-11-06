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
            // System.Console.WriteLine(":: ");
            if (System.IO.File.Exists(args[0]))
            {
                // System.Console.WriteLine($":: reading {args[0]}");
                string[] unsorted_names = System.IO.File.ReadAllLines(args[0]);
                System.IO.File.WriteAllLines(@"sorted-names-list.txt", unsorted_names);

            }
        }
    }
}
