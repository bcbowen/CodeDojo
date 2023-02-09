using LeetCode.Solutions.Medium.P01642_FurthestBuildingYouCanReach;

namespace LeetCode.Tests.Medium.P01642_FurthestBuildingYouCanReach;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1, 4)]
    [TestCase(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2, 7)]
    [TestCase(new[] { 14, 3, 19, 3 }, 17, 0, 3)]

    [TestCase(new[] { 1, 5, 1, 2, 3, 4, 10000 }, 4, 1, 5)]
    public void TestFurthestBuilding(int[] heights, int bricks, int ladders, int expected)
    {
        int result = new Solution().FurthestBuilding(heights, bricks, ladders);
        Assert.That(result, Is.EqualTo(expected));
    }

}