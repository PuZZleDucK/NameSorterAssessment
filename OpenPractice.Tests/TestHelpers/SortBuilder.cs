using System;
using Helpers;
using System.Diagnostics;

namespace TestHelpers
{
    public class SortBuilder
    {
        public static Process PrepareNameSorterProcess(Process _name_sorter)
        {
            if (_name_sorter == null) {
                System.Diagnostics.Process _name_sort_builder;
                _name_sort_builder = new System.Diagnostics.Process();
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
            _name_sorter = new System.Diagnostics.Process();
            if (Platform.IsPosix)
            {
                _name_sorter.StartInfo.FileName = @"../../../../../../../OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter";
            } else {
                _name_sorter.StartInfo.FileName = @"..\..\..\..\..\..\..\OpenPractice\Demos\name-sorter\bin\Release\netcoreapp2.0\win10-x64\publish\name-sorter";
            }
            _name_sorter.StartInfo.RedirectStandardOutput = true;
            return _name_sorter;
        }
    }
}
