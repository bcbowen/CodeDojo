using LeetCode.Solutions.Medium.P00739_DailyTemperature;

namespace LeetCode.Tests.Medium.P00739_DailyTemperature;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    [TestCase(new[] { 30, 40, 50, 60 }, new[] { 1, 1, 1, 0 })]
    [TestCase(new[] { 30, 60, 90 }, new[] { 1, 1, 0 })]
    public void DailyTemperatureTests(int[] temps, int[] expected)
    {
        int[] result = new Solution().DailyTemperatures(temps);
        Assert.That(result, Is.EqualTo(expected));
    }

}