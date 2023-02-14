using LeetCode.Solutions.Easy.P01281_SubtractProductAndSumOfDigitsOfInt;

namespace LeetCode.Tests.Easy.P01281_SubtractProductAndSumOfDigitsOfInt;

[TestFixture]
[Category("Easy")]
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