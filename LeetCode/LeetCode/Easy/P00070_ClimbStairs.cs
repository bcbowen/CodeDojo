using LeetCode.Solutions.Easy.P00070_ClimbStairs;

namespace LeetCode.Tests.Easy.P00070_ClimbStairs;

[TestFixture]
[Category("Easy")]
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