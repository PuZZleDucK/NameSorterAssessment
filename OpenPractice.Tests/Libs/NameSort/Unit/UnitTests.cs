using Xunit;
using NameSort;
using System.Text.RegularExpressions;
using System;

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
        public void MinimalUsageInformation()
        {
            Assert.Matches("usage information", NameSorter.ProgramUsageText());
        }

        [Fact]
        public void GivenNothingReturnsNothing()
        {
            string[] nobody = new string[0];
            Assert.Equal("", String.Join(" ", _nameSorter.SortNames(nobody)));
        }
    }
}
