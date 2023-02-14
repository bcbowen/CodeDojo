using LeetCode.Solutions.Easy.P01356_SortIntsByCountOf1Bits;

namespace LeetCode.Tests.Easy.P01356_SortIntsByCountOf1Bits;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, new[] { 0, 1, 2, 4, 8, 3, 5, 6, 7 })]
    [TestCase(new[] { 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 }, new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 })]
    public void SortByBitsTests(int[] arr, int[] expected)
    {
        int[] result = new Solution().SortByBits(arr);
        Assert.That(result, Is.EqualTo(expected));
    }

}