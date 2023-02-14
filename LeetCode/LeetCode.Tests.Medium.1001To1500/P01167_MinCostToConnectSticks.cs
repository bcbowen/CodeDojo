using LeetCode.Solutions.Medium.P01167_MinCostToConnectSticks;

namespace LeetCode.Tests.Medium.P01167_MinCostToConnectSticks;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 2, 4, 3 }, 14)]
    [TestCase(new[] { 1, 8, 3, 5 }, 30)]
    [TestCase(new[] { 5 }, 0)]
    public void TestConnectSticks(int[] sticks, int expected)
    {
        int result = new Solution().ConnectSticks(sticks);
        Assert.That(result, Is.EqualTo(expected));
    }

}