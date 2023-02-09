using LeetCode.Models.LinkedList;
using LeetCode.Solutions.P01290_ConvertBinaryLinkedListToInt;

namespace LeetCode.Tests.P01290_ConvertBinaryLinkedListToInt;

public class Tests
{
    [TestCase(new[] { 1, 0, 1 }, 5)]
    [TestCase(new[] { 0 }, 0)]
    [TestCase(new[] { 1, 0, 1, 1 }, 11)]
    [TestCase(new[] { 1, 0, 0, 0 }, 8)]
    public void GetValueTests(int[] values, int expected)
    {
        Solution solution = new Solution();
        ListNode node = solution.InitList(values);
        int result = solution.GetDecimalValue(node);
        Assert.That(result, Is.EqualTo(expected));
    }

}