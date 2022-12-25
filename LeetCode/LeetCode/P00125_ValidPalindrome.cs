using LeetCode.Solutions.P00125_ValidPalindrome;

namespace LeetCode.Tests.P00125_ValidPalindrome;

public class Tests
{
    [Test]
    [TestCase("A man, a plan, a canal: Panama", true)]
    [TestCase("race a car", false)]
    [TestCase(" ", true)]
    [TestCase("abba", true)]
    [TestCase("aba", true)]
    [TestCase("..", true)]
    [TestCase("0P", false)]
    [TestCase("1001", true)]
    [TestCase("1011", false)]
    [Theory]
    public void IsPalindromeTest(string s, bool expected)
    {
        bool result = new Solution().IsPalindrome(s);
        Assert.AreEqual(expected, result);
    }

}