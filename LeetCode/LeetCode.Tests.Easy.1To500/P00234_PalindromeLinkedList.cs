using LeetCode.Models.LinkedList;
using LeetCode.Solutions.Easy.P00234_PalindromeLinkedList;
using LeetCode.Tests.Utility.Helpers;
namespace LeetCode.Tests.Easy.P00234_PalindromeLinkedList;

[TestFixture]
[Category("Easy")]
public class Tests
{

    [TestCase(new[] { 1 }, true)]
    [TestCase(new[] { 1, 2 }, false)]
    [TestCase(new[] { 1, 1 }, true)]
    [TestCase(new[] { 1, 2, 3 }, false)]
    [TestCase(new int[0], false)]

    [TestCase(new[] { 1, 2, 2, 1 }, true)]
    [TestCase(new[] { 1, 2, 3, 2, 1 }, true)]
    public void IsPalindromeTest(int[] values, bool expected)
    {
        ListNode head = LinkedListHelpers.Init(values);

        bool result = new Solution().IsPalindrome(head);
        Assert.AreEqual(expected, result);
    }
}