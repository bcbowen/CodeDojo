using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00141_LinkedListCycle;

public class Solution
{
    public static ListNode Initialize(int[] nodes, int cycleIndex = -1)
    {
        ListNode cycleNode = null;
        ListNode root = new ListNode(nodes[0]);
        ListNode current = root;
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            if (i == cycleIndex)
            {
                cycleNode = current;
            }
            current.next = new ListNode(nodes[i + 1]);
            current = current.next;
        }
        current.next = cycleNode;

        return root;
    }

    public bool HasCycle(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        int step = 0;
        while (fast?.next?.next != null)
        {
            if (step % 2 == 0) fast = fast.next;

            fast = fast.next;
            slow = slow.next;

            if (fast == slow) return true;
        }

        return false;
    }
}