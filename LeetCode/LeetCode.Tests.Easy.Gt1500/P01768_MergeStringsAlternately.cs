using LeetCode.Solutions.Easy.P01768_MergeStringsAlternately;

namespace LeetCode.Tests.Easy.P01768_MergeStringsAlternately;

[TestFixture]
[Category("Easy")]
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