using LeetCode.Models.LinkedList;

namespace LeetCode.Solutions.Easy.P00876_MiddleLinkedList;

public class Solution
{
    public ListNode MiddleNode(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        int step = 0;

        while (fast != null)
        {
            if (step % 2 == 0)
            {
                if (fast.next != null)
                {
                    slow = slow.next;
                }

            }
            step++;
            fast = fast.next;
        }

        return slow;
    }

    public ListNode MiddleNodeFirst(ListNode head)
    {
        List<ListNode> list = new List<ListNode>();
        ListNode current = head;
        while (true)
        {
            list.Add(current);
            current = current.next;
            if (current == null) break;
        }

        int index = list.Count / 2;

        return list[index];
    }
}