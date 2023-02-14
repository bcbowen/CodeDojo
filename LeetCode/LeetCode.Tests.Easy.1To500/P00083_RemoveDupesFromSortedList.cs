using LeetCode.Models.LinkedList;
using LeetCode.Solutions.Easy.P00083_RemoveDupesFromSortedList;

namespace LeetCode.Tests.Easy.P00083_RemoveDupesFromSortedList;

[TestFixture]
[Category("Easy")]
public class Tests
{

    [Test]
    public void EmptyListReturnsNull()
    {
        ListNode node = null;
        ListNode result = new Solution().DeleteDuplicates(node);
        Assert.Null(result);
    }

    [Test]
    [TestCase(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
    [TestCase(new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3 })]
    public void Test(int[] values, int[] expected)
    {
        ListNode node = null;
        if (values.Length > 0)
        {
            node = new ListNode(values[0]);
            ListNode current = node;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
        }

        ListNode result = new Solution().DeleteDuplicates(node);

        ListNode resultNode = result;
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(resultNode.val, expected[i]);
            resultNode = resultNode.next;
        }
        Assert.Null(resultNode);
    }

}