using System;
using System.Linq;

namespace NameSort
{
    public class NameSorter
    {
        public static string ProgramUsageText()
        {
            return $"usage information:\n {System.AppDomain.CurrentDomain.FriendlyName} <list-to-be-sorted>";
        }

        public string[] SortNames(string[] unsorted_names)
        {
            return unsorted_names.OrderBy(name => name).ToArray(); ;
        }
    }
}
