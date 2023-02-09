using LeetCode.Solutions.Easy.P01137_NthTribonacciNumber;

namespace LeetCode.Tests.Easy.P01137_NthTribonacciNumber;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(4, 4)]
    [TestCase(25, 1389537)]
    public void Test(int n, int expected)
    {
        int result = new Solution().Tribonacci(n);
        Assert.That(result, Is.EqualTo(expected));
    }

}