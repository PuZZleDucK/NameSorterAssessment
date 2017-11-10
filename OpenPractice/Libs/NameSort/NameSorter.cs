using System;
using System.Linq;
using Helpers;

namespace NameSort
{
    public class NameSorter : SortInterface
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
                if(persons_names.Length > 4 || persons_names.Length == 0)
                {
                  Console.Error.WriteLine($"Malformed or invalid name detected: '{name}'");
                }
                string last_name = persons_names.Last();
                string other_names = String.Join(" ", persons_names.Take(persons_names.Length - 1).ToArray());
                return last_name + " " + other_names;
            }).ToArray(); ;
        }
    }
}
