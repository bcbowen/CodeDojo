using LeetCode.Solutions.Medium.P00189_RotateArray;

namespace LeetCode.Tests.Medium.P00189_RotateArray;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 10, new[] { 5, 6, 7, 1, 2, 3, 4 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
    [TestCase(new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 })]
    [TestCase(new[] { 1, 2 }, 1, new[] { 2, 1 })]
    [TestCase(new[] { 1, 2 }, 2, new[] { 1, 2 })]
    [TestCase(new[] { 1, 2, 3, 4 }, 2, new[] { 3, 4, 1, 2 })]
    public void RotateArrayTest(int[] nums, int k, int[] expected)
    {
        new Solution().Rotate(nums, k);
        Assert.AreEqual(expected, nums);
    }

}