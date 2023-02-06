using LeetCode.Solutions.Easy.P00224_BasicCalculator;

namespace LeetCode.Tests.Easy.P00224_BasicCalculator;

public class Tests
{
    [TestCase("1 + 1", 2)]
    [TestCase(" 2-1 + 2 ", 3)]
    [TestCase("(1+(4+5+2)-3)+(6+8)", 23)]
    [TestCase("(1+(4+5+2)-3)-(6+8)", -2)]
    [TestCase("-(1 + 1)", -2)]
    [TestCase("(1-(4+5+2)-3)+(6+8)", -1)]
    public void Test(string expression, int expected)
    {
        // TODO: These all fail because the code was never started
        int result = new Solution().Calculate(expression);
        Assert.AreEqual(expected, result);
    }

}