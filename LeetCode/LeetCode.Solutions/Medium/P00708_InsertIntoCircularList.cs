using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Medium.P00708_InsertIntoCircularList;

public class Solution
{
    public ListNode Insert(ListNode head, int insertVal)
    {
        ListNode node = new ListNode(insertVal);
        if (head == null)
        {
            node.next = node;
            return node;
        }
        else if (head.next == head)
        {
            head.next = node;
            node.next = head;
            return head;
        }

        ListNode current = head;
        while (current.next.val >= current.val && current.next != head)
        {
            current = current.next;
        }

        if (node.val > current.val || node.val < current.next.val)
        {
            // inserted node is the largest or smallest, it goes between the current largest and smallest
            node.next = current.next;
            current.next = node;

        }
        else
        {
            // find where the current node fits between 2 nodes
            while (current.next.val < node.val)
            {
                current = current.next;
            }
            node.next = current.next;
            current.next = node;
        }
        return head;

    }


    public ListNode InsertFirst(ListNode head, int insertVal)
    {
        ListNode node = new ListNode(insertVal);
        if (head == null)
        {
            node.next = node;
            return node;
        }
        else if (head.next == head)
        {
            head.next = node;
            node.next = head;
            return head;
        }

        if (head.val > insertVal)
        {
            int min = head.val;
            ListNode current = head;
            while (current.next.val > insertVal && current.next != head)
            {
                current = current.next;
                if (current.val < min) min = current.val;
            }

            if (current.next != head)
            {
                current = current.next;
                node.next = current.next;
                current.next = node;
            }
            else
            {
                while (current.next.val != min)
                {
                    current = current.next;
                }
                node.next = current.next;
                current.next = node;
            }
        }
        else if (head.val < insertVal)
        {
            int max = head.val;
            ListNode current = head;
            while (current.next.val < insertVal && current.next != head)
            {
                current = current.next;
                if (current.val > max) max = current.val;
            }

            if (current.next != head)
            {
                //current = current.next;
                node.next = current.next;
                current.next = node;
            }
            else
            {
                while (current.val != max)
                {
                    current = current.next;
                }
                node.next = current.next;
                current.next = node;
            }
        }
        else
        {
            node.next = head.next;
            head.next = node;
        }

        return head;
    }
}
