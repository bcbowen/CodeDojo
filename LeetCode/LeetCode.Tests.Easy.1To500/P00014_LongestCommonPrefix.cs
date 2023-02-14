using LeetCode.Solutions.Easy.P00014_LongestCommonPrefix;

namespace LeetCode.Tests.Easy.P00014_LongestCommonPrefix;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
    [TestCase(new string[] { "dog", "racecar", "car" }, "")]
    [TestCase(new string[] { "dog", "", "dork" }, "")]
    [TestCase(new string[] { "", "racecar", "rat" }, "")]
    [TestCase(new string[] { "", "" }, "")]
    public void Test(string[] input, string expected)
    {
        string result = new Solution().LongestCommonPrefix(input);
        Assert.AreEqual(expected, result);
    }
}