using LeetCode.Solutions.Easy.P00088_MergeSortedArray;

namespace LeetCode.Tests.Easy.P00088_MergeSortedArray;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
    [TestCase(new[] { 1 }, 1, new int[0], 0, new[] { 1 })]
    [TestCase(new[] { 0 }, 1, new int[] { 1 }, 1, new[] { 1 })]
    [TestCase(new[] { 0 }, 0, new int[] { 1 }, 1, new[] { 1 })]
    public void TestMerge(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        new Solution().Merge(nums1, m, nums2, n);
        Assert.AreEqual(expected, nums1);
    }

}