using LeetCode.Solutions.Models.LinkedList;
using LeetCode.Solutions.P00206_ReverseLinkedList;
using LeetCode.Tests.Utility.Helpers;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
    [TestCase(new int[0], new int[0])]
    public void ReverseListTest(int[] values, int[] expected)
    {
        ListNode start = LinkedListHelpers.Init(values);
        ListNode result = new Solution().ReverseList(start);

        if (values.Length > 0)
        {
            ListNode current = result;
            int i = 0;
            while (current != null)
            {
                Assert.AreEqual(expected[i++], current.val);
                current = current.next;
            }
        }
        else
        {
            Assert.Null(result);
        }

    }

}