using LeetCode.Solutions.Easy.P00415_AddStrings;

namespace LeetCode.Tests.Easy.P00415_AddStrings;

public class Tests
{
    [TestCase("11", "123", "134")]
    [TestCase("456", "77", "533")]
    [TestCase("0", "0", "0")]
    [TestCase("0", "9", "9")]
    [TestCase("9", "0", "9")]
    [TestCase("4600", "1564", "6164")]
    [TestCase("0000", "4600", "4600")]
    [TestCase("00000", "4600", "4600")]
    [TestCase("000", "4600", "4600")]
    //[TestCase("", "", "")]
    public void Test(string x, string y, string expected)
    {
        string result = new Solution().AddStrings(x, y);
        Assert.That(result, Is.EqualTo(expected));
    }

    /*
    Example 1:
    Input: num1 = "11", num2 = "123"
    Output: "134"

    Example 2:
    Input: num1 = "456", num2 = "77"
    Output: "533"

    Example 3:
    Input: num1 = "0", num2 = "0"
    Output: "0"
    */

}