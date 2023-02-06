using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Medium.P00328_OddEvenLinkedList;

public class Solution
{
    // odd indices first, then even indices
    public ListNode OddEvenList(ListNode head)
    {
        if (head == null) return head;
        ListNode oddTail = head;
        ListNode tail = head;
        while (oddTail?.next?.next != null)
        {
            oddTail = oddTail.next.next;
        }

        tail = oddTail.next;

        ListNode current = head;
        ListNode newOddTail = oddTail;
        while (current != oddTail)
        {
            newOddTail.next = current.next;
            current.next = current.next.next;

            newOddTail = newOddTail.next;
            newOddTail.next = tail;
            current = current.next;
        }
        return head;
    }
}

