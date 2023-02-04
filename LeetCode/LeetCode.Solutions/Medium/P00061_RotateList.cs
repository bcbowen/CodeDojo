using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Medium.P00061_RotateList;

public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || k == 0) return head;
        ListNode tail = head;
        ListNode current = head;
        int len = 1;
        while (tail.next != null)
        {
            tail = tail.next;
            len++;
        }
        // if k > len, get the mod to find the number to shift
        k = k % len;
        tail.next = head;

        // ex: 1-2-3-4-5, k = 2
        // 4 will be the new head, current will be 3
        // rotate list 2 to the right by rotating 3 to the left and removing the link from the new tail to the new head
        for (int i = 0; i < (len - k - 1); i++)
        {
            current = current.next;
        }
        ListNode newHead = current.next;
        current.next = null;
        return newHead;
    }
}