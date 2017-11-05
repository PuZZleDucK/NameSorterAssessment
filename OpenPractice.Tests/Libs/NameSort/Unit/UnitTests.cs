using Xunit;
using NameSort;
using System.Text.RegularExpressions;

namespace Unit
{
    public class UnitTests
    {
        private readonly NameSorter _nameSorter;

        public UnitTests()
        {
            _nameSorter = new NameSorter();
        }

        [Fact]
        public void SanityTest()
        {
            Assert.True(true, "True should be true");
        }

        [Fact]
        public void UsageInformation()
        {
            Assert.Matches(@"\usage information\", NameSorter.ProgramUsageText());
        }
    }
}
