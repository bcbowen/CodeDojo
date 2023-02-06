using LeetCode.Solutions.P01662_CheckStringArraysEqual;

namespace LeetCode.Tests.P01662_CheckStringArraysEqual;

public class Tests
{
    [TestCase(new[] { "ab", "c" }, new[] { "a", "bc" }, true)]
    [TestCase(new[] { "a", "cb" }, new[] { "ab", "c" }, false)]
    [TestCase(new[] { "abc", "d", "defg" }, new[] { "abcddefg" }, true)]
    [TestCase(new[] { "bbb" }, new[] { "bbb" }, true)]
    [TestCase(new[] { "bbb" }, new[] { "bb" }, false)]
    [TestCase(new[] { "bb" }, new[] { "bbb" }, false)]

    public void Test(string[] word1, string[] word2, bool expected)
    {
        bool result = new Solution().ArrayStringsAreEqual(word1, word2);
        Assert.That(result, Is.EqualTo(expected));
    }

}