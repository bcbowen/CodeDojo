using LeetCode.Solutions.Hard.P00295_FindMedianFromDataStream;

namespace LeetCode.Tests.Hard.P00295_FindMedianFromDataStream;

[TestFixture]
[Category("Hard")]
public class Tests
{
    [TestCase(new[] { 2, 3, 4 }, 3.0)]
    [TestCase(new[] { 2, 3 }, 2.5)]
    [TestCase(new[] { 1, 2 }, 1.5)]
    [TestCase(new[] { 1, 2, 3 }, 2.0)]
    public void SimpleTests(int[] values, double expected)
    {
        MedianFinder m = new MedianFinder();
        foreach (int value in values)
        {
            m.AddNum(value);
        }
        Assert.That(m.FindMedian(), Is.EqualTo(expected));
    }


}