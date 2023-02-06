using LeetCode.Solutions.P00896_MonotonicArray;

namespace LeetCode.Tests.P00896_MonotonicArray;

public class Tests
{
    [TestCase(new[] { 1, 2, 2, 3 }, true)]
    [TestCase(new[] { 6, 5, 4, 4 }, true)]
    [TestCase(new[] { 1, 3, 2 }, false)]
    [TestCase(new[] { 6, 6, 6 }, true)]
    public void Test(int[] nums, bool expected)
    {
        bool result = new Solution().IsMonotonic(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}