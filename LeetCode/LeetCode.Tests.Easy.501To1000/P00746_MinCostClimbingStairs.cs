using LeetCode.Solutions.Easy.P00746_MinCostClimbingStairs;

namespace LeetCode.Tests.Easy.P00746_MinCostClimbingStairs;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 10, 15, 20 }, 15)]
    [TestCase(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    [TestCase(new[] { 0, 2, 2, 1 }, 2)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().MinCostClimbingStairs(nums);
        Assert.AreEqual(expected, result);
    }

}