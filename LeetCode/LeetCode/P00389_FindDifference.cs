using LeetCode.Solutions.P00389_FindDifference;

namespace LeetCode.Tests.P00389_FindDifference;

public class Tests
{
    [TestCase("abcd", "abcde", 'e')]
    [TestCase("", "y", 'y')]
    public void Test(string s, string t, char expected)
    {
        char result = new Solution().FindTheDifference(s, t);
        Assert.That(result, Is.EqualTo(expected));
    }


}