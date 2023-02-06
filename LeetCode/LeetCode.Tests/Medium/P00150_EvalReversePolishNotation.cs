using LeetCode.Solutions.Medium.P00150_EvalReversePolishNotation;

namespace LeetCode.Tests.Medium.P00150_EvalReversePolishNotation;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase(new[] { "2", "1", "+", "3", "*" }, 9)]
    [TestCase(new[] { "4", "13", "5", "/", "+" }, 6)]
    [TestCase(new[] { "4", "3", "-" }, 1)]
    [TestCase(new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" }, 22)]
    public void Test(string[] tokens, int expected)
    {
        int result = new Solution().EvalRPN(tokens);
        Assert.AreEqual(expected, result);
    }

}