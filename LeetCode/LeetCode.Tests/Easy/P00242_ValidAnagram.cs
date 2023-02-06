using LeetCode.Solutions.Easy.P00242_ValidAnagram;

namespace LeetCode.Tests.Easy.P00242_ValidAnagram;

public class Tests
{

    [TestCase("anagram", "nagaram", true)]
    [TestCase("rat", "car", false)]
    [TestCase("ab", "a", false)]
    [TestCase("a", "ab", false)]
    public void AnagramTest(string s, string t, bool expected)
    {
        bool result = new Solution().IsAnagram(s, t);
        Assert.That(result, Is.EqualTo(expected));
    }

}