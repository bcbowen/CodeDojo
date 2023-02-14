using LeetCode.Models.LinkedList;
using LeetCode.Solutions.Easy.P00876_MiddleLinkedList;
using LeetCode.Tests.Utility.Helpers;

namespace LeetCode.Tests.Easy.P00876_MiddleLinkedList;

[TestFixture]
[Category("Easy")]
public class Tests
{

    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 6 })]
    public void Test(int[] values, int[] expectedValues)
    {
        Solution solution = new Solution();
        ListNode head = LinkedListHelpers.Init(values);
        ListNode result = solution.MiddleNode(head);

        Assert.That(LinkedListHelpers.ValuesMatch(result, expectedValues), Is.True);

    }

}