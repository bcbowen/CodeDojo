using LeetCode.Solutions.P00198_HouseRobber;

namespace Medium;

public class Tests
{
    [TestCase(new[] { 1, 2, 3, 1 }, 4)]
    [TestCase(new[] { 2, 7, 9, 3, 1 }, 12)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().Rob(nums);
        Assert.That(result, Is.EqualTo(expected));
    }
}