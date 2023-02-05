using LeetCode.Solutions.P00740_DeleteAndEarn;

namespace Medium;

public class Tests
{
    [TestCase(new[] { 3, 4, 2 }, 6)]
    [TestCase(new[] { 2, 2, 3, 3, 3, 4 }, 9)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 1, 3 }, 4)]
    [TestCase(new[] { 2, 2, 3, 3, 3 }, 9)]
    [TestCase(new[] { 1, 1, 1, 2, 4, 5, 5, 5, 6 }, 18)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().DeleteAndEarn(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}