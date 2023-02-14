using LeetCode.Solutions.Easy.P00058_LengthLastWord;

namespace LeetCode.Tests.Easy.P00058_LengthLastWord;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase("Hello World", 5)]
    [TestCase("   fly me   to   the moon  ", 4)]
    [TestCase("luffy is still joyboy", 6)]
    [TestCase("balls", 5)]
    public void Test(string s, int expected)
    {
        int result = new Solution().LengthOfLastWord(s);
        Assert.AreEqual(expected, result);
    }


}