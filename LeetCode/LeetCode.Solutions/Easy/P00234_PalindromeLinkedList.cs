using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Easy;

public class Solution
{
    internal ListNode ReverseList(ListNode head)
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

    public bool IsPalindrome(ListNode head)
    {
        if (head == null) return false;

        ListNode tail = head;
        ListNode mid = head;
        ListNode halfEnd = head;
        int step = 0;
        while (tail.next != null)
        {
            tail = tail.next;
            if (step++ % 2 == 0)
            {
                halfEnd = mid;
                mid = mid.next;
            }
        }

        if (mid == tail)
        {
            // mid == tail when there are two nodes, so it is a palindrome if both nodes are the same
            return head.val == mid.val;
        }

        // reverse mid nodes
        halfEnd.next = ReverseList(mid);
        mid = halfEnd.next;

        ListNode front = head;
        ListNode back = mid;
        bool isPalindrome = true;
        while (front != mid)
        {
            if (front.val != back.val)
            {
                isPalindrome = false;
                break;
            }
            front = front.next;
            back = back.next;
        }

        // restore mid nodes
        halfEnd.next = ReverseList(mid);
        return isPalindrome;
    }

}