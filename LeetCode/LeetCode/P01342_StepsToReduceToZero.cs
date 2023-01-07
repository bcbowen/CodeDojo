using LeetCode.Solutions.P01342_StepsToReduceToZero;

namespace LeetCode.Tests.P01342_StepsToReduceToZero;

public class Tests
{
    [TestCase(14, 6)]
    [TestCase(8, 4)]
    [TestCase(123, 12)]
    public void Test(int num, int expected)
    {
        int result = new Solution().NumberOfSteps(num);
        Assert.That(result, Is.EqualTo(expected));
    }

}