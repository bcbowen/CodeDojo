using LeetCode.Solutions.Easy.P01046_LastStoneWeight;

namespace LeetCode.Tests.Easy.P01046_LastStoneWeight;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 2, 7, 4, 1, 8, 1 }, 1)]
    public void TestLastStoneWeight(int[] stones, int expected)
    {
        int result = new Solution().LastStoneWeight(stones);
        Assert.That(result, Is.EqualTo(expected));
    }

}