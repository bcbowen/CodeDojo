using LeetCode.Solutions.Easy.P00346_MovingAverageDataStream;

namespace LeetCode.Tests.Easy.P00346_MovingAverageDataStream;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(3, new[] { 1, 10, 3, 5 }, new[] { 1.0, 5.5, 4.66667, 6.0 })]
    public void Test(int size, int[] values, double[] expectedValues)
    {
        MovingAverage m = new MovingAverage(size);

        for (int i = 0; i < values.Length; i++)
        {
            Assert.That(m.Next(values[i]), Is.EqualTo(expectedValues[i]).Within(.0001));
        }
    }


}