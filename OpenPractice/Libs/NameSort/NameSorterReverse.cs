using System;
using System.Linq;
using Helpers;

namespace NameSort
{
    public class NameSorterReverse : SortInterface
    {
        public string[] SortNames(string[] unsorted_names)
        {
            return unsorted_names.OrderByDescending(name =>
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
