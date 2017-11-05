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

        [Fact]
        public void GivenSingleNameReturnsName()
        {
            string[] nobody = { "Zoro" };
            Assert.Equal("Zoro", String.Join(" ", _nameSorter.SortNames(nobody)));
        }

        [Fact]
        public void GivenSortedSimpleNamesReturnsNames()
        {
            string[] nobody = { "Batman", "Robyn" };
            Assert.Equal("Batman Robyn", String.Join(" ", _nameSorter.SortNames(nobody)));
        }

        [Fact]
        public void GivenReversedSimpleNamesReturnsSortedNames()
        {
            string[] nobody = { "Simon", "Garfunkel" };
            Assert.Equal("Garfunkel Simon", String.Join(" ", _nameSorter.SortNames(nobody)));
        }

        [Fact]
        public void GivenNameReturnsName()
        {
            string[] nobody = { "Richard Stallman" };
            Assert.Equal("Richard Stallman", String.Join("_", _nameSorter.SortNames(nobody)));
        }

        [Fact]
        public void GivenSortedNamesReturnsNames()
        {
            string[] nobody = { "Richard Stallman", "Linus Torvalds" };
            Assert.Equal("Richard Stallman_Linus Torvalds", String.Join("_", _nameSorter.SortNames(nobody)));
        }

        // [Fact]
        // public void GivenReversedNamesReturnsSortedNames()
        // {
        //     string[] nobody = { "Simon", "Garfunkel" };
        //     Assert.Equal("Garfunkel Simon", String.Join("_", _nameSorter.SortNames(nobody)));
        // }


    }
}
