using LeetCode.Solutions.Easy.P00202_HappyNumber;

namespace LeetCode.Tests.Easy.P00202_HappyNumber;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(19, true)]
    [TestCase(2, false)]
    [TestCase(7, true)]
    public void IsHappyTest(int n, bool expected)
    {
        bool result = new Solution().IsHappy(n);
        Assert.AreEqual(expected, result);
    }

}