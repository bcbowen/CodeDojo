using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Easy.P00203_RemoveLinkedListElements;

public class Solution
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;
        }

        if (head == null) return head;

        ListNode current = head;
        while (current != null)
        {
            ListNode peek = current.next;
            while (peek != null && peek.val == val)
            {
                peek = peek.next;
            }
            current.next = peek;
            current = current.next;
        }
        return head;
    }
}