using LeetCode.Solutions.P00300_LongestIncreasingSubsequence;

namespace LeetCode.Tests.P00300_LongestIncreasingSubsequence;

public class Tests
{
    [TestCase(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [TestCase(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
    [TestCase(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
    [TestCase(new[] { 1, 3, 6, 7, 9, 4, 10, 5, 6 }, 6)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().LengthOfLIS(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}