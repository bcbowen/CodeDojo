using LeetCode.Solutions.Medium.P00394_DecodeString;

namespace LeetCode.Tests.Medium.P00394_DecodeString;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase("10[ben]", "benbenbenbenbenbenbenbenbenben")]
    [TestCase("3[a]2[bc]", "aaabcbc")]
    [TestCase("3[a2[c]]", "accaccacc")]
    [TestCase("3[a2[b2[c]]]", "abccbccabccbccabccbcc")]
    [TestCase("2[abc]3[cd]ef", "abcabccdcdcdef")]
    [TestCase("abcabccdcdcdef", "abcabccdcdcdef")]
    public void DecodeStringTests(string s, string expected)
    {
        string result = new Solution().DecodeString(s); 
        Assert.That(result, Is.EqualTo(expected));
    }

}

/*
Example 1:
Input: s = "3[a]2[bc]"
Output: "aaabcbc"

Example 2:
Input: s = "3[a2[c]]"
Output: "accaccacc"

Example 3:
Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"
*/