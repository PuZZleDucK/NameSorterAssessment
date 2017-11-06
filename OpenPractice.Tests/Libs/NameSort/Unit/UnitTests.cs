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
            string[] simple_name = { "Zoro" };
            Assert.Equal("Zoro", String.Join(" ", _nameSorter.SortNames(simple_name)));
        }

        [Fact]
        public void GivenSortedSimpleNamesReturnsNames()
        {
            string[] simple_names = { "Batman", "Robyn" };
            Assert.Equal("Batman Robyn", String.Join(" ", _nameSorter.SortNames(simple_names)));
        }

        [Fact]
        public void GivenReversedSimpleNamesReturnsSortedNames()
        {
            string[] simple_names = { "Simon", "Garfunkel" };
            Assert.Equal("Garfunkel Simon", String.Join(" ", _nameSorter.SortNames(simple_names)));
        }

        [Fact]
        public void GivenNameReturnsName()
        {
            string[] name = { "Richard Stallman" };
            Assert.Equal("Richard Stallman", String.Join("_", _nameSorter.SortNames(name)));
        }

        [Fact]
        public void GivenSortedNamesReturnsNames()
        {
            string[] names = { "Richard Stallman", "Linus Torvalds" };
            Assert.Equal("Richard Stallman_Linus Torvalds", String.Join("_", _nameSorter.SortNames(names)));
        }

        [Fact]
        public void GivenReversedNamesReturnsSortedNames()
        {
            string[] names = { "Siouxsie Sioux", "Joan Jett" };
            Assert.Equal("Joan Jett_Siouxsie Sioux", String.Join("_", _nameSorter.SortNames(names)));
        }

        [Fact]
        public void GivenLongNamesReturnsSortedNames()
        {
            string[] names = { "Michael George Goodspaceguy Nelson", "Kim Tim Jim Vestor", "John Captain Crunch Draper" };
            Assert.Equal("John Captain Crunch Draper_Michael George Goodspaceguy Nelson_Kim Tim Jim Vestor", String.Join("_", _nameSorter.SortNames(names)));
        }

        [Fact]
        public void GivenMixedNamesReturnsSortedNames()
        {
            string[] names = { "Sting", "Gordy Sumner", "Gordon Matthew Thomas Sumner" };
            Assert.Equal("Sting_Gordon Matthew Thomas Sumner_Gordy Sumner", String.Join("_", _nameSorter.SortNames(names)));
        }

        [Fact]
        public void GivenExampleNamesReturnsSortedNames()
        {
            string[] names = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };
            Assert.Equal("Marin Alvarez_Adonis Julius Archer_Beau Tristan Bentley_Hunter Uriah Mathew Clarke_Leo Gardner_Vaughn Lewis_London Lindsey_Mikayla Lopez_Janet Parsons_Frankie Conner Ritter_Shelby Nathan Yoder", String.Join("_", _nameSorter.SortNames(names)));
        }

    }
}
