using LeetCode.Solutions.Medium.P00503_NextGreaterNumberII;

namespace LeetCode.Tests.Medium;

public class Tests
{
    [TestCase(new[] { 1, 2, 1 }, new[] { 2, -1, 2 })]
    [TestCase(new[] { 1, 2, 3, 4, 3 }, new[] { 2, 3, 4, -1, 4 })]
    public void Test(int[] nums, int[] expected)
    {
        int[] result = new Solution().NextGreaterElements(nums);
        Assert.That(result, Is.EqualTo(expected));
    }


}