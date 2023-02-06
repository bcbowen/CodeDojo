using LeetCode.Solutions.P01588_SumOfOddLengthArrays;

namespace LeetCode.Tests.P01588_SumOfOddLengthArrays;

public class Tests
{
    [TestCase(new[] { 1, 4, 2, 5, 3 }, 58)]
    [TestCase(new[] { 1, 2 }, 3)]
    [TestCase(new[] { 10, 11, 12 }, 66)]
    public void Test(int[] arr, int expected)
    {
        int result = new Solution().SumOddLengthSubarrays(arr);
        Assert.That(result, Is.EqualTo(expected));
    }

}