using LeetCode.Solutions.Medium.P00567_PermutationInString;

namespace LeetCode.Tests.Medium.P00567_PermutationInString;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase("ac", "ac", true)]
    [TestCase("ac", "ca", true)]
    [TestCase("ac", "cb", false)]
    [TestCase("ac", "ab", false)]
    [TestCase("aaaabc", "caaaab", true)]
    [TestCase("abcdef", "fedcba", true)]
    [TestCase("aabbcc", "abcabc", true)]
    public void P00567_PermutationInString_IsPermutationTests(string s1, string s2, bool expected) 
    {
        Dictionary<char, int> masterCounts = new Dictionary<char, int>();
        foreach (char c in s1) 
        {
            if (!masterCounts.ContainsKey(c)) 
            {
                masterCounts.Add(c, 0); 
            }
            masterCounts[c]++;
        }

        bool result = new Solution().IsPermutation(s2, masterCounts); 
        Assert.That(result, Is.EqualTo(expected));
    }

    
    [TestCase("ab", "eidbaooo", true)]
    [TestCase("ab", "eidboaoo", false)]
    [TestCase("ab", "eidoooba", true)]
    [TestCase("ab", "baeidooo", true)]
    [TestCase("ab", "abeidooo", true)]
    [TestCase("ab", "eidoooab", true)]
    [TestCase("aab", "eidooobaa", true)]
    [TestCase("aba", "eidoooaab", true)]
    [TestCase("aba", "abdoooaab", true)]
    [TestCase("aba", "aabeidooo", true)]
    [TestCase("aba", "baaeidooo", true)]
    [TestCase("aba", "baeaidooo", false)]
    [TestCase("aaa", "aaaidooo", true)]
    [TestCase("aaa", "idoooaaa", true)]
    [TestCase("aaa", "idaaaooo", true)]
    public void P00567_PermutationInString_CheckInclusionTests(string s1, string s2, bool expected) 
    {
        bool result = new Solution().CheckInclusion(s1, s2);
        Assert.That(result, Is.EqualTo(expected));
    }

    /*
    public bool CheckInclusion(string s1, string s2)
    {

    }


    Example 1:

Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").
Example 2:

Input: s1 = "ab", s2 = "eidboaoo"
Output: false
    */
}