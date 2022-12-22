using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00019_RemoveNthNodeFromEnd
{
    public class Solution
    {
        private ListNode RemoveLast(ListNode head)
        {
            ListNode current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            current.next = null;
            return head;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null) return null;

            if (n == 1) return RemoveLast(head);

            ListNode current = head;
            ListNode peek = current;
            for (int i = 0; i < n; i++)
            {
                peek = peek.next;
            }

            // if peek = null we have to remove the first node
            if (peek == null) return head.next;

            while (peek.next != null)
            {
                current = current.next;
                peek = peek.next;
            }

            // remove current.next by pointing to the following node
            current.next = current.next.next;

            return head;
        }

        public ListNode RemoveNthFromEndFirst(ListNode head, int n)
        {
            if (head.next == null) return null;

            if (n == 1) return RemoveLast(head);

            int step = 0;
            ListNode first = head;
            ListNode second = head;
            while (first != null)
            {
                first = first.next;
                step++;
                if (step > n + 1)
                {
                    second = second.next;
                }
            }
            if (second != head) second.next = second.next.next;
            return head;
        }
    }
}