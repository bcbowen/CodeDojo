using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P01290_ConvertBinaryLinkedListToInt;

public class Solution
{
    public int GetDecimalValue(ListNode head)
    {

        int val = head.val;
        ListNode node = head.next;
        while (node != null)
        {
            val <<= 1;
            val += node.val;
            node = node.next;
        }
        return val;
    }

    internal ListNode InitList(int[] values)
    {
        ListNode head = new ListNode(values[0]);
        ListNode node = head;
        for (int i = 1; i < values.Length; i++)
        {
            node.next = new ListNode(values[i]);
            node = node.next;
        }

        return head;
    }
}
