using System;
using System.Linq;
using NameSort;
using Helpers;

namespace name_sorter
{
    class Program
    {
       static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // No argument given... print help and error out.
                System.Console.WriteLine(":: NameSorter ::");
                System.Console.WriteLine(NameSorter.ProgramUsageText());
                Environment.Exit(-1);
            }
            SortInterface name_sorter = null;
            InputInterface name_source = new FileInput();
            string[] name_list = null;
            // process flags
            if(args.Any("--desc".Contains))
            {
                name_sorter = new NameSorterReverse();
            } else {
                name_sorter = new NameSorter();
            }
 
            if(args.Any("--ifile".Contains))
            {
                string file_name = args[Array.IndexOf(args, "--ifile")+1];
                name_list = name_source.GetNames(file_name);
            }
            // catch origional program behaviour
            if( name_list == null ) {
                name_list = name_source.GetNames(args[0]);
            }
            string[] sorted_names = name_sorter.SortNames(name_list);
            System.Console.WriteLine(String.Join(Platform.Delimiter, sorted_names));
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);
           
 

            //old and crusty now
            if (args.Length == 1 && System.IO.File.Exists(args[0]))
            {
            } else {
                        // This should be in output module:
                // System.Console.WriteLine(":: NameSorter ::");
                // System.Console.WriteLine(NameSorter.ProgramUsageText());
                // System.Console.WriteLine($" The file '{args[0]}' was not found!");
                // Environment.Exit(-1);
            }
            Environment.Exit(0);
        }
    }
}
