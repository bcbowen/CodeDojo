using LeetCode.Solutions.Easy.P00020_ValidParens;

namespace LeetCode.Tests.Easy.P00020_ValidParens;

[TestFixture]
[Category("Easy")]
public partial class Tests
{
    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("([{}])", true)]
    [TestCase("(]", false)]
    [TestCase("([{})]", false)]
    [TestCase("([{}]", false)]
    public void ValidParensTest(string s, bool expected)
    {
        bool result = new Solution().IsValid(s);
        Assert.That(result, Is.EqualTo(expected));
    }
        /*
    Example 1:
    Input: s = "()"
    Output: true

    Example 2:
    Input: s = "()[]{}"
    Output: true

    Example 3:
    Input: s = "(]"
    Output: false
    */
}