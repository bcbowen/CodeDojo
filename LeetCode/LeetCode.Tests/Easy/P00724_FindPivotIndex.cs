using LeetCode.Solutions.Easy.P00724_FindPivotIndex;

namespace LeetCode.Tests.Easy.P00724_FindPivotIndex;

public class Tests
{
    [TestCase(new[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [TestCase(new[] { 1, 2, 3 }, -1)]
    [TestCase(new[] { 2, 1, -1 }, 0)]
    [TestCase(new[] { -1, -1, 0, 1, 1, 0 }, 5)]
    public void PivotIndexTest(int[] values, int expected)
    {
        int result = new Solution().PivotIndex(values);
        Assert.That(result, Is.EqualTo(expected));
    }

}