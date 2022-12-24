using LeetCode.Solutions.P00067_AddBinary;

namespace LeetCode.Tests.P00067_AddBinary;

public class Tests
{
    [Test]
    [TestCase("11", "1", "100")]
    [TestCase("1010", "1011", "10101")]
    public void Test(string a, string b, string expected)
    {
        string result = new Solution().AddBinary(a, b);
        Assert.AreEqual(expected, result);

    }

}