using LeetCode.Solutions.Easy.P00279_PerfectSquares;

namespace LeetCode.Tests.Easy.P00279_PerfectSquares;

public class Tests
{
    [TestCase(12, 3)]
    [TestCase(13, 2)]
    public void Test(int n, int expected)
    {
        int result = new Solution().NumSquares(n);
        Assert.That(result, Is.EqualTo(expected));
    }

}