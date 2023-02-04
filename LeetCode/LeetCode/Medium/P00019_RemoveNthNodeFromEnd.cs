using LeetCode.Solutions.Medium.P00019_RemoveNthNodeFromEnd;
using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Tests.Medium.P00019_RemoveNthNodeFromEnd;

public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3, 5 })]
    [TestCase(new[] { 1 }, 1, new int[0])]
    [TestCase(new[] { 1, 2 }, 1, new[] { 1 })]
    [TestCase(new[] { 1, 2 }, 2, new[] { 2 })]
    public void TestRemoveNodeFromEnd(int[] nodes, int n, int[] expected)
    {
        ListNode head = new ListNode(nodes[0]);
        ListNode node = head;
        for (int i = 1; i < nodes.Length; i++)
        {
            node.next = new ListNode(nodes[i]);
            node = node.next;
        }

        ListNode result = new Solution().RemoveNthFromEnd(head, n);
        node = result;
        int j = 0;
        if (expected.Length == 0)
        {
            Assert.Null(node);
        }
        else
        {
            while (node != null)
            {
                Assert.AreEqual(expected[j++], node.val);
                node = node.next;
            }
        }

    }


}