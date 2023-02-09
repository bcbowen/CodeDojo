using LeetCode.Solutions.Medium.P00531_LonelyPixel;

namespace LeetCode.Tests.Medium.P00531_LonelyPixel;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(3, new[] { 'W', 'W', 'B' }, new[] { 'W', 'B', 'W' }, new[] { 'B', 'W', 'W' })]
    [TestCase(0, new[] { 'B', 'B', 'B' }, new[] { 'B', 'B', 'W' }, new[] { 'B', 'B', 'B' })]
    [TestCase(0, new[] { 'B', 'B', 'B' }, new[] { 'B', 'B', 'W' }, new[] { 'B', 'B', 'B' })]
    [TestCase(1, new[] { 'B' })]
    [TestCase(0, new[] { 'W' })]
    [TestCase(1, new[] { 'W', 'B' })]
    [TestCase(0, new[] { 'W', 'B', 'W', 'W' }, new[] { 'W', 'B', 'B', 'W' }, new[] { 'W', 'W', 'W', 'W' })]

    public void Test(int expected, params char[][] picture)
    {
        int result = new Solution().FindLonelyPixel(picture);
        Assert.That(result, Is.EqualTo(expected));
    }

}