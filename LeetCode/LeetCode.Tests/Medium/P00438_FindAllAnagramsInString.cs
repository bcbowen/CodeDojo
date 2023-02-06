using LeetCode.Solutions.Medium.P00438_FindAllAnagramsInString;

namespace LeetCode.Tests.Medium;

public class Tests
{
    [TestCase("cbaebabacd", "abc", new[] { 0, 6 })]
    [TestCase("abab", "ab", new[] { 0, 1, 2 })]
    [TestCase("baa", "aa", new[] { 1 })]
    [TestCase("aaaaaaaaaa", "aaaaaaaaaaaaa", new int[0])]
    public void Test(string s, string p, int[] expected)
    {
        IList<int> result = new Solution().FindAnagrams(s, p);
        Assert.That(result.ToArray(), Is.EqualTo(expected));
    }

}