using LeetCode.Solutions.Medium.P01143_LongestCommonSubsequence;

namespace LeetCode.Tests.Medium.P01143_LongestCommonSubsequence;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase("abcde", "ace", 3)]
    [TestCase("ace", "ace", 3)]
    [TestCase("abc", "def", 0)]
    [TestCase("pmjghexybyrgzczy", "hafcdqbgncrcbihkd", 4)]
    public void Test(string text1, string text2, int expected)
    {
        DateTime testStart = DateTime.Now;
        int result = new Solution().LongestCommonSubsequence(text1, text2);
        TimeSpan totalMilliseconds = DateTime.Now.Subtract(testStart);
        Assert.That(result, Is.EqualTo(expected));
    }

}