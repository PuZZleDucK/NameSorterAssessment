using System;
using NameSort;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
          if(args.Length == 0)
          {
            NameSorter.ProgramUsageText();
          }
        }
    }
}
