using LeetCode.Solutions.P00070_ClimbStairs;

namespace LeetCode.Tests.P00070_ClimbStairs;

public class Tests
{
    [Test]
    [TestCase(2, 2)]
    [TestCase(3, 3)]
    public void Test(int n, int expected)
    {
        int result = new Solution().ClimbStairs(n);
        Assert.AreEqual(expected, result);
    }

}