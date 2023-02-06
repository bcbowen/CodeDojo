using LeetCode.Solutions.Medium.P00139_WordBreak;

namespace LeetCode.Tests.Medium.P00139_WordBreak;

public class Tests
{
    [Test]
    [TestCase("leetcode", new[] { "leet", "code" }, true)]
    [TestCase("applepenapple", new[] { "apple", "pen" }, true)]
    [TestCase("catsandog", new[] { "cats", "dog", "sand", "and", "cat" }, false)]
    [TestCase("bb", new[] { "a", "b", "bbb", "bbbb" }, true)]
    public void Test(string s, IList<string> wordDict, bool expected)
    {
        bool result = new Solution().WordBreak(s, wordDict);
        Assert.AreEqual(expected, result);
    }

}