using LeetCode.Solutions.P01770_MaxScore;

namespace LeetCode.Tests.P01770_MaxScore;

public class Tests
{
    [TestCase(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, 14)]
    [TestCase(new[] { -5, -3, -3, -2, 7, 1 }, new[] { -10, -5, 3, 4, 6 }, 102)]
    public void Test(int[] nums, int[] multipliers, int expected)
    {
        int result = new Solution().MaximumScore(nums, multipliers);
        Assert.That(result, Is.EqualTo(expected));
    }

}