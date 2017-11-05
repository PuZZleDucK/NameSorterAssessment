using System;
using NameSort;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("NameSorter");
            if (args.Length == 0)
            {
                System.Console.WriteLine(NameSorter.ProgramUsageText());
            }
        }
    }
}
