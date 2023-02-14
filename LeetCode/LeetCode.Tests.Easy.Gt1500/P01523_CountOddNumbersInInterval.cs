using LeetCode.Solutions.Easy.P01523_CountOddNumbersInInterval;

namespace LeetCode.Tests.Easy.P01523_CountOddNumbersInInterval;

[TestFixture]
[Category("Easy")]
public partial class Tests
{
    [TestCase(3, 7, 3)]
    [TestCase(2, 7, 3)]
    [TestCase(2, 8, 3)]
    [TestCase(3, 8, 3)]
    [TestCase(3, 3, 1)]
    [TestCase(4, 4, 0)]
    [TestCase(1, 7, 4)]
    [TestCase(1, 8, 4)]
    [TestCase(1, 9, 5)]
    [TestCase(2, 10, 4)]
    [TestCase(8, 10, 1)]
    public void CountOddsTest(int low, int high, int expected) 
    {
        int result = new Solution().CountOdds(low, high);
        Assert.That(result, Is.EqualTo(expected));
    }

}