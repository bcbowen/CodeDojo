using System.Text;
using LeetCode.Solutions.P00459_RepeatedSubstringPattern;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [TestCase("abab", "ab", true)]
    [TestCase("abab", "aba", false)]
    [TestCase("abab", "a", false)]
    [TestCase("aba", "ab", false)]
    [TestCase("ab", "ab", false)]
    [TestCase("abcabcabcabc", "abc", true)]
    [TestCase("abcabcabcabc", "abcabc", true)]
    public void TestTest(string m, string s, bool expected)
    {
        bool result = new Solution().Test(m, new StringBuilder(s));
        Assert.That(result, Is.EqualTo(expected));
    }


    [Theory]
    [TestCase("abab", true)]
    [TestCase("aba", false)]
    [TestCase("abcabcabcabc", true)]
    public void Test(string s, bool expected)
    {
        bool result = new Solution().RepeatedSubstringPattern(s);
        Assert.That(result, Is.EqualTo(expected));
    }


}