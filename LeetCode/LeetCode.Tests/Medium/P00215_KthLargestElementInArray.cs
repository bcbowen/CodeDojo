using LeetCode.Solutions.Medium.P00215_KthLargestElementInArray;

namespace LeetCode.Tests.Medium.P00215_KthLargestElementInArray;

public class Tests
{
    [TestCase(new[] { 3, 2, 1, 5, 6, 4 }, 2, 5)]
    [TestCase(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
    public void FindKthLargestTest(int[] nums, int k, int expected)
    {
        int result = new Solution().FindKthLargest(nums, k);
        Assert.AreEqual(expected, result);
    }

}