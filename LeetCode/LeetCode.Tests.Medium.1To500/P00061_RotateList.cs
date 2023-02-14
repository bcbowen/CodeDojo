using LeetCode.Models.LinkedList;
using LeetCode.Solutions.Medium.P00061_RotateList;
using LeetCode.Tests.Utility.Helpers;

namespace LeetCode.Tests.Medium.P00061_RotateList;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 4, 5, 1, 2, 3 })]
    [TestCase(new int[0], 1, new int[0])]
    [TestCase(new[] { 1, 2 }, 1, new[] { 2, 1 })]
    [TestCase(new[] { 0, 1, 2 }, 4, new[] { 2, 0, 1 })]
    public void TestRotateRight(int[] nodes, int n, int[] expected)
    {
        ListNode head = LinkedListHelpers.Init(nodes);

        ListNode result = new Solution().RotateRight(head, n);
        ListNode node = result;
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