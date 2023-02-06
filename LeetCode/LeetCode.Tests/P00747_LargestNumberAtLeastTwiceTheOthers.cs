using LeetCode.Solutions.P00747_LargestNumberAtLeastTwiceTheOthers;

namespace LeetCode.Tests.P00747_LargestNumberAtLeastTwiceTheOthers;

public class Tests
{
    [TestCase(new[] { 3, 6, 1, 0 }, 1)]
    [TestCase(new[] { 1, 2, 3, 4 }, -1)]
    public void TestDominantIndex(int[] nums, int expected)
    {
        int result = new Solution().DominantIndex(nums);
        Assert.AreEqual(expected, result);
    }

}