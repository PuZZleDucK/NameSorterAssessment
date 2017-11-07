using System;
using System.Linq;

namespace NameSort
{
    public class NameSorter
    {
        public static string ProgramUsageText()
        {
            return $"name-sort program usage information:\n {System.AppDomain.CurrentDomain.FriendlyName} <list-to-be-sorted>";
        }

        public string[] SortNames(string[] unsorted_names)
        {
            return unsorted_names.OrderBy(name =>
            {
                string[] persons_names = name.Split(' ');
                if(persons_names.Length > 4)
                {
                  // ERR out here... invalid name
                  System.Console.WriteLine($"Malformed name detected: {persons_names}");
                }
                // also ERR on "A name must have at least 1 given name" if possible
                string last_name = persons_names.Last();
                string other_names = String.Join(" ", persons_names.Take(persons_names.Length - 1).ToArray());
                return last_name + " " + other_names;
            }).ToArray(); ;
        }
    }
}
