using LeetCode.Solutions.P00021_MergeTwoSortedLists;
using LeetCode.Solutions.Models.LinkedList;
using LeetCode.Tests.Utility.Helpers;

namespace LeetCode.Tests.P00021_MergeTwoSortedLists;

public class Tests
{
    [Test]
    [TestCase(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [TestCase(new[] { 1, 2, 4 }, new[] { 5, 6 }, new[] { 1, 2, 4, 5, 6 })]
    [TestCase(new[] { 2, 7, 9 }, new[] { 1, 3, 6 }, new[] { 1, 2, 3, 6, 7, 9 })]
    [TestCase(new int[0], new[] { 0 }, new[] { 0 })]
    [TestCase(new int[0], new int[0], new int[0])]
    public void MergeTwoListsTest(int[] values1, int[] values2, int[] expected)
    {
        ListNode? list1 = LinkedListHelpers.Init(values1); 
        ListNode? list2 = LinkedListHelpers.Init(values2);

        ListNode result = new Solution().MergeTwoLists(list1, list2);

        if (expected.Length > 0)
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