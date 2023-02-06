using LeetCode.Solutions.Medium.P00151_ReverseWordsInString;

namespace LeetCode.Tests.Medium.P00151_ReverseWordsInString;

public class Tests
{
    [Theory]
    [TestCase("the sky is blue", "blue is sky the")]
    [TestCase("hello world  ", "world hello")]
    [TestCase("a good   example", "example good a")]
    [TestCase("  hello world  ", "world hello")]
    public void TestReverseWords(string s, string expected)
    {
        string result = new Solution().ReverseWords(s);
        Assert.AreEqual(expected, result);
    }

}