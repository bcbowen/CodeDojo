using LeetCode.Solutions.Models.LinkedList;


namespace LeetCode.Tests.Utility.Helpers
{
    [TestFixture]
    public class LinkedListHelperTests
    {
        [Test]
        public void LinkedListWithValuesInitializesAsExpected() 
        {
            int[] values = { 1, 2, 3, 4, 5 };
            ListNode head = LinkedListHelpers.Init(values);

            Assert.True(LinkedListHelpers.ValuesMatch(head, values));
        }

        [Test]
        public void LinkedListWithoutValuesInitializesToNull() 
        {
            int[] values = new int[0];
            ListNode head = LinkedListHelpers.Init(values);
            Assert.IsNull(head);
        }

        [Test]
        public void NullLinkedListInitializesToNull()
        {
            int[] values = null;
            ListNode head = LinkedListHelpers.Init(values);
            Assert.IsNull(head);
        }

        [Test]
        public void ListMatchingValuesMatches() 
        {
            ListNode head = new ListNode(1);
            ListNode current = head;
            current.next = new ListNode(2);
            current = current.next;
            current.next = new ListNode(3);
            current = current.next;
            current.next = new ListNode(4);

            int[] values = { 1, 2, 3, 4};
            Assert.True(LinkedListHelpers.ValuesMatch(head, values));
        }

        [Test]
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1, 2, 3, 4, 5 })]
        public void ListWithDifferentNumberOfValuesDoesNotMatch(int[] values)
        {
            ListNode head = new ListNode(1);
            ListNode current = head;
            current.next = new ListNode(2);
            current = current.next;
            current.next = new ListNode(3);
            current = current.next;
            current.next = new ListNode(4);

            Assert.False(LinkedListHelpers.ValuesMatch(head, values));
        }


    }
}
