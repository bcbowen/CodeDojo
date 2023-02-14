using LeetCode.Solutions.Medium.P00031_NextPermutation;

namespace LeetCode.Tests.Medium.P00031_NextPermutation;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
    [TestCase(new[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 1, 5 }, new[] { 1, 5, 1 })]
    public void TestNextPermutation(int[] nums, int[] expected)
    {
        new Solution().NextPermutation(nums);
        Assert.AreEqual(expected, nums);
    }
}