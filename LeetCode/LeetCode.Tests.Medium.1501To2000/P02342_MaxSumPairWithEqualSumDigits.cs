using LeetCode.Solutions.Medium.P02342_MaxSumPairWithEqualSumDigits;

namespace LeetCode.Tests.Medium.P02342_MaxSumPairWithEqualSumDigits;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 18, 43, 36, 13, 7 }, 54)]
    [TestCase(new[] { 10, 12, 19, 14 }, -1)]
    [TestCase(new[] { 229, 398, 269, 317, 420, 464, 491, 218, 439, 153, 482, 169, 411, 93, 147, 50, 347, 210, 251, 366, 401 }, 973)]
    public void Test(int[] nums, int expected)
    {
        int result = new Solution().MaximumSum(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}