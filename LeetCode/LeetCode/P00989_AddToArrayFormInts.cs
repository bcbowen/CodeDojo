using LeetCode.Solutions.P00989_AddToArrayFormInts;

namespace LeetCode.Tests.P00989_AddToArrayFormInts;

public class Tests
{
    [TestCase(new[] { 1, 2, 0, 0 }, 34, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 2, 7, 4 }, 181, new[] { 4, 5, 5 })]
    [TestCase(new[] { 2, 1, 5 }, 806, new[] { 1, 0, 2, 1 })]
    [TestCase(new[] { 2, 1 }, 999, new[] { 1, 0, 2, 0 })]
    public void Test(int[] num, int k, int[] expected)
    {
        IList<int> result = new Solution().AddToArrayForm(num, k);
        Assert.That(result, Is.EqualTo(expected));
    }

}