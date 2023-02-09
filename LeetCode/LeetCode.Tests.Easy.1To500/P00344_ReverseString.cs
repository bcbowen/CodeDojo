using LeetCode.Solutions.Easy.P00344_ReverseString;

namespace LeetCode.Tests.Easy.P00344_ReverseString;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 'h', 'e', 'l', 'l', 'o' }, new[] { 'o', 'l', 'l', 'e', 'h' })]
    [TestCase(new[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
    public void TestReverseString(char[] s, char[] expected)
    {
        new Solution().ReverseString(s);
        Assert.That(s, Is.EqualTo(expected));
    }

}