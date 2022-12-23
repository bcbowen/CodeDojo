using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Tests.Utility.Helpers
{
    public static class LinkedListHelpers
    {
        public static ListNode? Init(int[] values)
        {
            if (values == null || values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }

            return head;
        }

        public static bool ValuesMatch(ListNode head, int[] values) 
        {
            if (head == null && values == null) return true;
            if (head == null || values == null) return false;

            ListNode current = head;
            int i = 0;
            while (current != null) 
            {
                if (i > values.Length - 1) return false;
                if (current.val != values[i++]) return false;
                current = current.next;
            }
            if (i != values.Length) return false;

            return true;
        }
    }
}
