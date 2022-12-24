using LeetCode.Solutions.P00065_Sqrt;

namespace LeetCode.Tests.P00065_Sqrt;

public class Tests
{
    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 2)]
    [TestCase(6, 2)]
    [TestCase(8, 2)]
    [TestCase(10, 3)]
    [TestCase(64, 8)]
    [TestCase(66, 8)]
    [TestCase(8192, 90)]
    [TestCase(4_294_967_295, 65_535)]
    public void SqrtTest(long x, int expected)
    {
        int result = new Solution().MySqrt(x);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void FixProblemChild()
    {
        /*
        8192
    Output
    64
    Expected
    90
        */
        int expected = 3;
        int result = new Solution().MySqrt(10);
        Assert.AreEqual(expected, result);
    }

}