using LeetCode.Solutions.P00347_TopKFrequentElements;

namespace LeetCode.Tests.P00347_TopKFrequentElements;

public class Tests
{
    [TestCase(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    [TestCase(new[] { 1 }, 1, new[] { 1 })]
    public void Test(int[] nums, int k, int[] expected)
    {
        int[] result = new Solution().TopKFrequent(nums, k);
        Assert.That(result, Is.EqualTo(expected));
    }

}