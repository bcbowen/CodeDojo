using LeetCode.Solutions.P01779_NearestPointWithSameXOrYCoord;

namespace LeetCode.Tests.P01779_NearestPointWithSameXOrYCoord;

public class Tests
{
    [TestCase(3, 4, 2,
    new[] { 1, 2 },
    new[] { 3, 1 },
    new[] { 2, 4 },
    new[] { 2, 3 },
    new[] { 4, 4 }
    )]
    [TestCase(3, 4, 0,
    new[] { 3, 4 }
    )]
    [TestCase(3, 4, -1,
    new[] { 2, 3 }
    )]
    public void NearestPointTests(int x, int y, int expected, params int[][] points)
    {
        int result = new Solution().NearestValidPoint(x, y, points);
        Assert.That(result, Is.EqualTo(expected));
    }

}