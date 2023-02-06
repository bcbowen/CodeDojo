using LeetCode.Solutions.Models.LinkedList;
using LeetCode.Solutions.Medium.P00328_OddEvenLinkedList;
using LeetCode.Tests.Utility.Helpers;

namespace LeetCode.Tests.Medium.P00328_OddEvenLinkedList;

public class Tests
{
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 3, 5, 2, 4 })]
    [TestCase(new[] { 2, 1, 3, 5, 6, 4, 7 }, new[] { 2, 3, 6, 7, 1, 5, 4 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new[] { 1, 3, 5, 7, 2, 4, 6, 8 })]
    [TestCase(new int[0], new int[0])]
    public void OddEvenListTest(int[] values, int[] expected)
    {
        ListNode start = LinkedListHelpers.Init(values);
        ListNode result = new Solution().OddEvenList(start);

        if (values.Length > 0)
        {
            ListNode current = result;
            int i = 0;
            while (current != null)
            {
                Assert.That(current.val, Is.EqualTo(expected[i++]));
                current = current.next;
            }
        }
        else
        {
            Assert.Null(result);
        }

    }


}