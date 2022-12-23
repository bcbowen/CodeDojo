using LeetCode.Solutions.P00029_ValidParens;

namespace LeetCode.Tests.P00029_ValidParens;

public class Tests
{
    [Test]
    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    public void Test(string input, bool expected)
    {
        bool result = new Solution().IsValid(input);
        Assert.AreEqual(expected, result);
    }
}