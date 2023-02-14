using LeetCode.Solutions.Easy.P00976_LargestPerimeterTriangle;

namespace LeetCode.Tests.Easy.P00976_LargestPerimeterTriangle;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 2, 1, 2 }, 5)]
    [TestCase(new[] { 1, 2, 1 }, 0)]
    [TestCase(new[] { 3, 6, 2, 3 }, 8)]
    public void LargestPerimeterTest(int[] nums, int expected)
    {
        int result = new Solution().LargestPerimeter(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}