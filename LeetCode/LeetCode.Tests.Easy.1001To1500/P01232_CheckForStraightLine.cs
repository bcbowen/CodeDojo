using LeetCode.Solutions.Easy.P01232_CheckForStraightLine;

namespace LeetCode.Tests.Easy.P01232_CheckForStraightLine;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(true, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 6, 7 })]
    [TestCase(false, new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 4 }, new[] { 4, 5 }, new[] { 5, 6 }, new[] { 7, 7 })]
    [TestCase(true, new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, -1 })]
    [TestCase(true, new[] { 2, 1 }, new[] { 4, 2 }, new[] { 6, 3 })]
    public void Test(bool expected, params int[][] coordinates)
    {
        bool result = new Solution().CheckStraightLine(coordinates);
        Assert.That(result, Is.EqualTo(expected));
    }

}