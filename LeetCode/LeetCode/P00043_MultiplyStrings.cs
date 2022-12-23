using LeetCode.Solutions.P00043_MultiplyStrings;

namespace LeetCode.Tests.P00043_MultiplyStrings;

public class Tests
{
    [Test]
    [TestCase("0", "332620029", "0")]
    [TestCase("9133", "0", "0")]
    [TestCase("2", "3", "6")]
    [TestCase("2", "4", "8")]
    [TestCase("1", "2", "2")]
    [TestCase("6", "3", "18")]
    [TestCase("5", "6", "30")]
    [TestCase("8", "5", "40")]
    [TestCase("20", "4", "80")]
    [TestCase("37", "32", "1184")]
    [TestCase("81", "89", "7209")]
    [TestCase("20", "40", "800")]
    [TestCase("134", "46", "6164")]
    [TestCase("5678", "1234", "7006652")]
    [TestCase("51", "46", "2346")]
    [TestCase("51", "42", "2142")]
    [TestCase("93", "76", "7068")]
    [TestCase("26", "71", "1846")]
    [TestCase("6937", "2423", "16808351")]
    [TestCase("5176", "4440", "22981440")]
    [TestCase("1385", "3751", "5195135")] // sub
    [TestCase("127", "102", "12954")]
    [TestCase("5077", "8319", "42235563")]
    [TestCase("5127", "4265", "21866655")] // sub
    [TestCase("123", "456", "56088")]
    public void SmallTests(string x, string y, string expected)
    {
        string result = new Solution().Multiply(x, y);
        Assert.AreEqual(expected, result);
    }

    [Test]
    [TestCase("9", "1", "8")]
    [TestCase("134", "123", "11")]
    [TestCase("533", "77", "456")]
    [TestCase("0", "0", "0")]
    [TestCase("9", "0", "9")]
    [TestCase("6164", "4600", "1564")]
    [TestCase("105", "56", "49")]
    [TestCase("1000", "1", "999")]
    [TestCase("234", "189", "45")]
    [TestCase("56238", "19758", "36480")]
    //[TestCase("", "", "")]
    public void SubtractTests(string x, string y, string expected)
    {
        string result = Solution.Subtract(x, y);
        Assert.AreEqual(expected, result);
    }

    [Test]
    [TestCase("1385", "3751", "5195135")] // sub
    [TestCase("5127", "4265", "21866655")] // sub
    public void SmallTestsDebug(string x, string y, string expected)
    {
        string result = new Solution().Multiply(x, y);
        Assert.AreEqual(expected, result);
    }
    /*

    Example 1:
    Input: num1 = "2", num2 = "3"
    Output: "6"

    Example 2:
    Input: num1 = "123", num2 = "456"
    Output: "56088"

    */
    [Test]
    [TestCase("1", 1)]
    [TestCase("10", 2)]
    [TestCase("103", 4)]
    [TestCase("1234", 4)]
    [TestCase("123456", 8)]
    [TestCase("12345678", 8)]
    [TestCase("1234567890", 16)]
    public void GetIdealSizeTests(string value, int expectedSize)
    {
        int result = Solution.GetIdealSize(value);
        Assert.AreEqual(expectedSize, result);
    }

    [Test]
    [TestCase("1", "1")]
    [TestCase("10", "10")]
    [TestCase("103", "0103")]
    [TestCase("1234", "1234")]
    [TestCase("123456", "00123456")]
    [TestCase("12345678", "12345678")]
    [TestCase("1234567890", "0000001234567890")]
    public void SetSizeTests(string value, string expected)
    {
        string result = Solution.SetSize(value);
        Assert.AreEqual(expected, result);
    }

    [Test]
    [TestCase("1", "2", "1", "2")]
    [TestCase("13", "2", "13", "02")]
    [TestCase("1", "10", "01", "10")]
    [TestCase("103", "0103", "0103", "0103")]
    [TestCase("1", "1234", "0001", "1234")]
    public void TestSetSizes(string x, string y, string expectedX, string expectedY)
    {
        (string resultX, string resultY) = Solution.SetSizes(x, y);
        Assert.AreEqual(expectedX, resultX);
        Assert.AreEqual(expectedY, resultY);

    }

}