using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00206_ReverseLinkedList;

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head == null) return head;

        ListNode tail = head;
        ListNode next = head;
        ListNode last = null;
        ListNode current = head;
        while (tail.next != null)
        {
            tail = tail.next;
        }

        while (current != tail)
        {
            next = current.next;
            tail.next = current;
            // first time last will be null, which we want at the end of the reversed list
            current.next = last;
            last = current;
            current = next;
        }

        return current;
    }
}