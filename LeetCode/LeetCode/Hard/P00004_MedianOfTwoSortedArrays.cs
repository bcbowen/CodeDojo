using LeetCode.Solutions.Hard.P00004_MedianOfTwoSortedArrays;

namespace LeetCode.Tests.Hard.P00004_MedianOfTwoSortedArrays;

[TestFixture]
[Category("P00004")]
[Category("Hard")]
public partial class Tests
{
    [TestCase(new[] { 1, 3 }, new[] { 2 }, 2)]
    [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, 2.5)]
    [TestCase(new[] { 1, 2, 3 }, new int[0], 2)]
    [TestCase(new[] { 1, 2, 3, 4 }, new int[0], 2.5)]
    [TestCase(new int[0], new[] { 1, 2, 3 }, 2)]
    [TestCase(new int[0], new[] { 1, 2, 3, 4 }, 2.5)]
    public void FindMedianTest(int[] nums1, int[] nums2, double expected)
    {
        double result = new Solution().FindMedianSortedArrays(nums1, nums2);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(new[] { 1, 3 }, new[] { 2 }, new[] { 1.0, 2.0, 3.0})]
    [TestCase(new[] { 1, 2 }, new[] { 3, 4 }, new[] { 1.0, 2.0, 3.0, 4.0 })]
    [TestCase(new[] { 3, 4 }, new[] { 1, 2 }, new[] { 1.0, 2.0, 3.0, 4.0 })]
    [TestCase(new[] { 1, 4 }, new int[0], new[] { 1.0, 4.0 })]
    [TestCase(new int [0], new[] { 2, 3 }, new[] { 2.0, 3.0 })]
    [TestCase(new int[0], new int [0], new double[0])]
    public void MergeTest(int[] nums1, int[] nums2, double[] expected) 
    {
        double[] result = new Solution().Merge(nums1, nums2);
        Assert.That(result, Is.EqualTo(expected));
    }

    /*
    Example 1:
    Input: nums1 = [1,3], nums2 = [2]
    Output: 2.00000
    Explanation: merged array = [1,2,3] and median is 2.

    Example 2:
    Input: nums1 = [1,2], nums2 = [3,4]
    Output: 2.50000
    Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
    */
}