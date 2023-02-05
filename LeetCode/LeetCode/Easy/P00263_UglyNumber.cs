using LeetCode.Solutions.P00263_UglyNumber;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [TestCase(6, true)]
    [TestCase(1, true)]
    [TestCase(14, false)]
    [TestCase(80440, false)]
    [TestCase(56380, false)]
    [TestCase(24_300_000, true)]
    [TestCase(-2147483648, false)]
    public void Test(int n, bool expected)
    {
        bool result = new Solution().IsUgly(n);
        Assert.That(result, Is.EqualTo(expected));
    }

}