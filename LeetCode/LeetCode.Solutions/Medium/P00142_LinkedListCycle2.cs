using LeetCode.Models.LinkedList;

namespace LeetCode.Solutions.Medium.P00142_LinkedListCycle2;

public class Solution
{
    public static ListNode Initialize(int[] nodes, int cycleIndex = -1)
    {
        if (nodes == null || nodes.Length == 0) return null;

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
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null) return head;

        ListNode current = head;
        HashSet<ListNode> visited = new HashSet<ListNode>();
        while (current.next != null)
        {
            if (visited.Contains(current)) return current;

            visited.Add(current);
            current = current.next;
        }

        return null;
    }
}