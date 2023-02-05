using LeetCode.Solutions.P00217_ContainsDupes;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [TestCase(new[] { 1, 2, 3, 1 }, true)]
    [TestCase(new[] { 1, 2, 3, 4 }, false)]
    [TestCase(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
    public void TestContainsDupes(int[] nums, bool expected)
    {
        bool result = new Solution().ContainsDuplicate(nums);
        Assert.AreEqual(expected, result);
    }

}