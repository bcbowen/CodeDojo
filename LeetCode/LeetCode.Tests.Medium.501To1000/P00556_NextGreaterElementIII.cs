using LeetCode.Solutions.Medium.P00556_NextGreaterElementIII;

namespace LeetCode.Tests.Medium.P00556_NextGreaterElementIII;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(21, 12)]
    [TestCase(56, 65)]
    [TestCase(65, 56)]
    public void SwapDigitsTest(int n, int expected)
    {
        int result = new Solution().SwapDigits(n);
        Assert.AreEqual(expected, result);
    }

    [Theory]
    [TestCase(21, new[] { 2, 1 })]
    [TestCase(56, new[] { 5, 6 })]
    [TestCase(65, new[] { 6, 5 })]
    [TestCase(65, new[] { 6, 5 })]
    public void GetDigitsTest(int n, int[] expected)
    {
        int[] result = new Solution().GetDigits(n);
        Assert.AreEqual(expected, result);
    }

    [Theory]
    /**/
    [TestCase(new[] { 2, 1 }, 21)]
    [TestCase(new[] { 2, 1, 4 }, 214)]
    [TestCase(new[] { 2, 1, 4, 7 }, 2147)]
    [TestCase(new[] { 2, 1, 4, 7, 9 }, 21479)]
    [TestCase(new[] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 7 }, 2147483647)]
    [TestCase(new[] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 8 }, -1)]
    [TestCase(new[] { 9, 1, 9, 9, 9, 9, 9, 9, 9, 9 }, -1)]
    public void GetValueTest(int[] digits, int expected)
    {
        int result = new Solution().GetValue(digits);
        Assert.AreEqual(expected, result);
    }


    [TestCase(1999999999, -1)]
    [TestCase(12222333, 12223233)]
    [TestCase(1265, 1526)]
    [TestCase(2147483486, -1)]
    [TestCase(1265, 1526)]
    [TestCase(230241, 230412)]
    [TestCase(12, 21)]
    [TestCase(21, -1)]
    [TestCase(2, -1)]
    [TestCase(100, -1)]
    [TestCase(231, 312)]
    [TestCase(5432, -1)]
    [TestCase(5423, 5432)]
    /**/
    public void TestMain(int n, int expected)
    {
        int result = new Solution().NextGreaterElement(n);
        Assert.AreEqual(expected, result);
    }

}