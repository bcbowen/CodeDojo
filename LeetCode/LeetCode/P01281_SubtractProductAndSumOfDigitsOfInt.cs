using LeetCode.Solutions.P01281_SubtractProductAndSumOfDigitsOfInt;

namespace LeetCode.Tests.P01281_SubtractProductAndSumOfDigitsOfInt;

public class Tests
{
    [TestCase(234, 15)]
    [TestCase(4421, 21)]
    public void SubtractProductAndSumTest(int n, int expected)
    {
        int result = new Solution().SubtractProductAndSum(n);
        Assert.That(result, Is.EqualTo(expected));
    }

}