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
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.Start();
            string output = pProcess.StandardOutput.ReadToEnd();
            pProcess.WaitForExit();
            Assert.Matches("usage information", output);
        }
    }
}
