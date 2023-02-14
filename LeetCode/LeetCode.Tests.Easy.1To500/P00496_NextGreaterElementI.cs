using LeetCode.Solutions.Easy.P00496_NextGreaterElementI;

namespace LeetCode.Tests.Easy.P00496_NextGreaterElementI;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 4, 1, 2 }, new[] { 1, 3, 4, 2 }, new[] { -1, 3, -1 })]
    [TestCase(new[] { 2, 4 }, new[] { 1, 2, 3, 4 }, new[] { 3, -1 })]
    public void Test(int[] nums1, int[] nums2, int[] expected)
    {
        int[] result = new Solution().NextGreaterElement(nums1, nums2);
        Assert.That(result, Is.EqualTo(expected));
    }

}