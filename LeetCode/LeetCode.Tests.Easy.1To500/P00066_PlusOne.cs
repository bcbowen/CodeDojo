using LeetCode.Solutions.Easy.P00066_PlusOne;

namespace LeetCode.Tests.Easy.P00066_PlusOne;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
    [TestCase(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
    [TestCase(new[] { 9 }, new[] { 1, 0 })]
    public void TestPlusOne(int[] digits, int[] expected)
    {
        int[] result = new Solution().PlusOne(digits);
        Assert.AreEqual(expected, result);
    }

}