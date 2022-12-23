using LeetCode.Solutions.P00009_PalindromeNumber;

namespace LeetCode.Tests.P00009_PalindromeNumber;

public class Tests
{
    [Test]
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void TestPalindromeNumber(int x, bool expected)
    {
        bool result = new Solution().IsPalindrome(x);
        Assert.AreEqual(expected, result);
    }
}