using LeetCode.Solutions.Medium.P00028_ImplementStrStr;

namespace LeetCode.Tests.Medium.P00028_ImplementStrStr;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase("hello", "ll", 2)]
    [TestCase("aaaaa", "bba", -1)]
    [TestCase("hello", "he", 0)]
    [TestCase("hello", "h", 0)]
    [TestCase("hello", "lo", 3)]
    public void StrStrTest(string haystack, string needle, int expected)
    {
        int result = new Solution().StrStr(haystack, needle);
        Assert.AreEqual(expected, result);
    }
}