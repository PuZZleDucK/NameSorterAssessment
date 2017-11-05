using System;
using Xunit;

namespace Integration
{
    public class IntegrationTests
    {
        [Fact]
        public void ProgramPrintsUsageWithoutArgs()
        {
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = @"dotnet";
            pProcess.StartInfo.Arguments = "run --project ../../../../../../../OpenPractice/Demos/name-sorter/";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();
            // Keeping console mesages to make CI config easier - TODO: remove
            System.Console.WriteLine($"OUTPUT: {output}");
            System.Console.WriteLine($"PWD: {System.IO.Directory.GetCurrentDirectory()}");
            Assert.Matches("usage information", output);
        }
    }
}
