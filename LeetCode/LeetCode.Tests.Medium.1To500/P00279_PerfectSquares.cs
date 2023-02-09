using LeetCode.Solutions.Medium.P00279_PerfectSquares;

namespace LeetCode.Tests.Medium.P00279_PerfectSquares;

[TestFixture]
[Category("Medium")]
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