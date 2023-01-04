using LeetCode.Solutions.P00709_ToLower;

namespace LeetCode.Tests.P00709_ToLower;

public class Tests
{
    [TestCase("Hello", "hello")]
    [TestCase("here", "here")]
    [TestCase("LOVELY", "lovely")]
    [TestCase("", "")]
    public void TestToLowerCase(string input, string expected)
    {
        string result = new Solution().ToLowerCase(input);
        Assert.That(result, Is.EqualTo(expected));
    }

}