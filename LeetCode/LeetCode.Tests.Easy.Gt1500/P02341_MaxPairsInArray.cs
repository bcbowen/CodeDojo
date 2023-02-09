using LeetCode.Solutions.Easy.P02341_MaxPairsInArray;

namespace LeetCode.Tests.Easy.P02341_MaxPairsInArray;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 1, 3, 2, 1, 3, 2, 2 }, new[] { 3, 1 })]
    [TestCase(new[] { 1, 1 }, new[] { 1, 0 })]
    [TestCase(new[] { 0 }, new[] { 0, 1 })]
    public void Test(int[] nums, int[] expected)
    {
        int[] result = new Solution().NumberOfPairs(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}