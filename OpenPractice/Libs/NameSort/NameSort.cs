using System;

namespace NameSort
{
    public class NameSorter
    {
      public static string ProgramUsageText()
      {
        return $"usage information:\n {System.AppDomain.CurrentDomain.FriendlyName} <list-to-be-sorted>";
      }
    }
}
