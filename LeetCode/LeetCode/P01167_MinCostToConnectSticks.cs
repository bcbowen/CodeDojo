using LeetCode.Solutions.P01167_MinCostToConnectSticks;

namespace LeetCode.Tests.P01167_MinCostToConnectSticks;

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