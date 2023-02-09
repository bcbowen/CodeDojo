using LeetCode.Solutions.Medium.P00003_LongestSubstringWithoutRepeatChars;

namespace LeetCode.Tests.Medium.P00003_LongestSubstringWithoutRepeatChars;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    [TestCase(null, 0)]
    [TestCase("", 0)]
    public void LongestSubstringTest(string s, int expected)
    {
        int result = new Solution().LengthOfLongestSubstring(s); 
        Assert.That(result, Is.EqualTo(expected));
    }
    /*
    Example 1:
    Input: s = "abcabcbb"
    Output: 3
    Explanation: The answer is "abc", with the length of 3.

    Example 2:
    Input: s = "bbbbb"
    Output: 1
    Explanation: The answer is "b", with the length of 1.
    
    Example 3:
    Input: s = "pwwkew"
    Output: 3
    Explanation: The answer is "wke", with the length of 3.
    Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    */
}