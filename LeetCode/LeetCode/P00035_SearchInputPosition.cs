using LeetCode.Solutions.P00035_SearchInputPosition;

namespace LeetCode.Tests.P00035_SearchInputPosition;

public class Tests
{
    [Test]
    [TestCase(new[] { 1, 3, 5, 6 }, 5, 2)]
    [TestCase(new[] { 1, 3, 5, 6 }, 2, 1)]
    [TestCase(new[] { 1, 3, 5, 6 }, 7, 4)]
    [TestCase(new[] { 2, 3, 5, 6 }, 1, 0)]
    [TestCase(new[] { 5 }, 2, 0)]
    [TestCase(new[] { 5 }, 7, 1)]
    [TestCase(new[] { 1, 3 }, 2, 1)]
    [TestCase(new[] { 2, 7, 8, 9, 10 }, 9, 3)]
    public void SearchInsert(int[] nums, int target, int expected)
    {
        int result = new Solution().SearchInsert(nums, target);
        Assert.AreEqual(expected, result);
    }
}