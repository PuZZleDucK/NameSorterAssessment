using System;
using Helpers;
using System.Diagnostics;

namespace TestHelpers
{
    public class SortBuilder
    {
        // We build a particular binary to harness into the integration and stress tests.
        // On some machines (CI in particular) we may not have access to previous binaries
        // so we proactivly build it for each test suite. A compromise between speed and
        // reliability.
        public static Process PrepareNameSorterProcess(Process _name_sorter)
        {
            if (_name_sorter == null) {
                var _name_sort_builder = new Process();
                _name_sort_builder.StartInfo.FileName = @"dotnet";
                if (Platform.IsPosix)
                {
                    _name_sort_builder.StartInfo.Arguments = "publish -c Release -r ubuntu.14.04-x64 ../../../../../../../OpenPractice/Demos/name-sorter";
                } else {
                    _name_sort_builder.StartInfo.Arguments = @"publish -c Release -r win10-x64 ..\..\..\..\..\..\..\OpenPractice\Demos\name-sorter";
                }
                _name_sort_builder.Start();
                _name_sort_builder.WaitForExit();
            }
            var name_sorter = new Process();
            if (Platform.IsPosix)
            {
                name_sorter.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            } else {
                name_sorter.StartInfo.FileName = @"..\..\..\..\..\..\..\OpenPractice\Demos\name-sorter\bin\Release\netcoreapp2.0\win10-x64\publish\name-sorter";
            }
            name_sorter.StartInfo.RedirectStandardOutput = true;
            return name_sorter;
        }
    }
}
