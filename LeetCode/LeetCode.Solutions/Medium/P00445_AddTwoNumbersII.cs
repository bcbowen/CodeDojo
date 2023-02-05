using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00445_AddTwoNumbersII;

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        l1 = ReverseList(l1);
        l2 = ReverseList(l2);

        bool carry = false;
        int value = l1.val + l2.val;
        if (value >= 10)
        {
            value -= 10;
            carry = true;
        }
        ListNode resultRoot = new ListNode(value);
        ListNode resultCurrent = resultRoot;

        while (l1 != null && l1.next != null || l2 != null && l2.next != null)
        {
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
            value = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + (carry ? 1 : 0);
            if (value >= 10)
            {
                value -= 10;
                carry = true;
            }
            else
            {
                carry = false;
            }
            resultRoot = new ListNode(value);
            resultRoot.next = resultCurrent;
            resultCurrent = resultRoot;
        }
        if (carry)
        {
            resultRoot = new ListNode(1);
            resultRoot.next = resultCurrent;
        }

        return resultRoot;
    }

    internal static ListNode ReverseList(ListNode list)
    {
        if (list == null || list.next == null) return list;

        ListNode tail = FindTail(list);
        ListNode head = list;
        ListNode newTail = head;
        ListNode newHead = head;
        ListNode current = newTail;

        while (newHead != tail)
        {
            newHead = head;
            head = head.next;
            newHead.next = current;
            current = newHead;
        }
        newTail.next = null;
        return newHead;
    }

    internal static ListNode FindTail(ListNode list)
    {
        ListNode current = list;
        while (current.next != null)
        {
            current = current.next;
        }
        return current;
    }

    internal static ListNode InitList(int[] values)
    {
        ListNode root = new ListNode(values[0]);
        ListNode current = root;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new ListNode(values[i]);
            current = current.next;
        }

        return root;
    }
}
