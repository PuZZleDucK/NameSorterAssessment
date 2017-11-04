using System;
using Xunit;
using NameSort;

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
    public void BadTest()
    {
      Assert.False(true, "True should not be false");
    }
  }
}
