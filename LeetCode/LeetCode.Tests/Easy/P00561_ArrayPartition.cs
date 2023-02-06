using LeetCode.Solutions.Easy.P00561_ArrayPartition;

namespace LeetCode.Tests.Easy.P00561_ArrayPartition;

public class Tests
{
    [TestCase(new[] { 1, 4, 3, 2 }, 4)]
    [TestCase(new[] { 6, 2, 6, 5, 1, 2 }, 9)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().ArrayPairSum(nums);
        Assert.That(result, Is.EqualTo(expected));
    }
}