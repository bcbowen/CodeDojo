using LeetCode.Solutions.P01768_MergeStringsAlternately;

namespace LeetCode.Tests.P01768_MergeStringsAlternately;

public class Tests
{
    [TestCase("abc", "pqr", "apbqcr")]
    [TestCase("ab", "pqrs", "apbqrs")]
    [TestCase("abcd", "pq", "apbqcd")]
    public void Test(string word1, string word2, string expected)
    {
        string result = new Solution().MergeAlternately(word1, word2);
        Assert.That(result, Is.EqualTo(expected));
    }

}