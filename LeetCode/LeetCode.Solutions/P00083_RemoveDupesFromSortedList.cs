using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00083_RemoveDupesFromSortedList;

public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head != null)
        {
            ListNode current = head;
            ListNode next = current.next;
            while (next != null)
            {
                while (next != null && current.val == next.val)
                {
                    next = next.next;
                }

                if (next != null)
                {
                    current.next = next;
                    current = next;
                }
            }
            current.next = null;
        }

        return head;
    }

    public ListNode DeleteDuplicates_first(ListNode head)
    {
        if (head != null)
        {
            ListNode current = head;
            ListNode last = null;
            while (current != null)
            {
                last = current;
                while (current.val == last.val)
                {
                    if (current.next == null)
                    {
                        last.next = null;
                        current = null;
                        break;
                    }
                    else
                    {
                        current = current.next;
                    }

                }
                if (current != null)
                {
                    last.next = current;
                    current = current.next;
                }
            }
        }

        return head;
    }
}