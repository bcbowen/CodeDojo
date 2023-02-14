using LeetCode.Solutions.Easy.P00703_KthLargestElementInStream;

namespace LeetCode.Tests.Easy.P00703_KthLargestElementInStream;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(3, new int[] { 4, 5, 8, 2 }, new int[] { 3, 5, 10, 9, 4 }, new int[] { 4, 5, 5, 8, 8 })]
    [TestCase(1, new int[0], new int[] { -3, -2, -4, 0, 4 }, new int[] { -3, -2, -2, 0, 4 })]
    public void KthLargestElementInStreamTests(int k, int[] initValues, int[] adds, int[] expectedValues)
    {
        List<int> results = new List<int>();
        KthLargest driver = new KthLargest(k, initValues);
        foreach (int add in adds)
        {
            results.Add(driver.Add(add));
        }
        Assert.That(results, Is.EqualTo(expectedValues));
    }

}