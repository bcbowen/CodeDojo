using LeetCode.Solutions.P00303_RangeSumQueryImmutable;
using static LeetCode.Solutions.P00303_RangeSumQueryImmutable.Solution;

namespace LeetCode.Tests.P00303_RangeSumQueryImmutable;

public class Tests
{
    [TestCase(new[] { -2, 0, 3, -5, 2, -1 }, 0, 2, 1)]
    [TestCase(new[] { -2, 0, 3, -5, 2, -1 }, 2, 5, -1)]
    [TestCase(new[] { -2, 0, 3, -5, 2, -1 }, 0, 5, -3)]
    public void SumRangeTests(int[] nums, int start, int end, int expected)
    {
        NumArray n = new NumArray(nums);
        int result = n.SumRange(start, end);
        Assert.That(result, Is.EqualTo(expected));
    }

}