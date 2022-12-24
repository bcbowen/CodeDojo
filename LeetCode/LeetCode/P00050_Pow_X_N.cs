using LeetCode.Solutions.P00050_Pow_X_N;

namespace LeetCode.Tests.P00050_Pow_X_N;

public class Tests
{
    [Test]
    [TestCase(2, 10, 1024)]
    [TestCase(2.1, 3, 9.26100)]
    [TestCase(2, -2, .25)]
    public void Test(double x, int n, double expected)
    {
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result, 4);
    }

    [Test]
    public void NegativePowerTest()
    {
        double x = 2;
        int n = -2;
        double expected = .25;
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result, 4);
    }

    [Test]
    public void TinyValueHugeExponentTest()
    {
        double x = .00001;
        int n = 2147483647;
        double expected = 0;
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result);

    }

    [Test]
    [TestCase(1.00001, 123456, 3.43684)]
    [TestCase(-1.00001, 447125, -87.46403)]
    public void AlmostOneHugeExponentTest(double x, int n, double expected)
    {
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result, 5);
    }

    [Test]
    public void HugeNegativeExponentAlsoZero()
    {
        double x = 2;
        int n = -2147483648;
        double expected = 0;
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result);
    }

    [Test]
    [TestCase(1, -2147483646, 1)]
    [TestCase(1, 2147483647, 1)]
    [TestCase(-1, 2147483646, 1)]
    [TestCase(-1, 2147483647, -1)]
    public void OnesTest(double x, int n, double expected)
    {
        double result = new Solution().MyPow(x, n);
        Assert.AreEqual(expected, result);
    }


}