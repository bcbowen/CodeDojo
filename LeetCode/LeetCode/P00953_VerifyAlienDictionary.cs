using LeetCode.Solutions.P00953_VerifyAlienDictionary;

namespace LeetCode.Tests.P00953_VerifyAlienDictionary;

public class Tests
{
    
    [TestCase(new[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
    [TestCase(new[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
    [TestCase(new[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
    public void TestVerification(string[] words, string alphabet, bool expected)
    {
        bool result = new Solution().IsAlienSorted(words, alphabet);
        Assert.AreEqual(expected, result);
    }

    
    [TestCase("yadda", "yadda", 0)]
    [TestCase("yadda", "yad", 1)]
    [TestCase("yad", "yadda", -1)]
    [TestCase("avocado", "banana", -1)]
    [TestCase("zeus", "axle", 1)]
    [TestCase("ball", "balls", -1)]
    [TestCase("", "a", -1)]
    [TestCase("a", "", 1)]
    public void CompareTests(string word1, string word2, int expected)
    {
        string order = "abcdefghijklmnopqrstuvwxyz";
        Dictionary<char, int> dictionary = new Solution().InitDictionary(order);
        int result = new Solution().Compare(word1, word2, dictionary);
        if (expected == 0)
        {
            Assert.AreEqual(expected, result);
        }
        else if (expected > 0)
        {
            Assert.True(result > 0);
        }
        else
        {
            Assert.True(result < 0);
        }
    }

}