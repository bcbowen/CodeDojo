using LeetCode.Models.DoublyLinkedList;

namespace LeetCode.Solutions.Medium.P00430_FlattenMultilevelDoublyLinkedList;

public class Solution
{
    public Node Flatten(Node head)
    {
        if (head == null) return head;

        Node current = head;
        Node next = head.next;

        while (current != null)
        {
            if (current.child != null)
            {
                Node flat = Flatten(current.child);
                current.child = null;
                current.next = flat;
                flat.prev = current;
                current = FindEnd(current);
                if (next != null)
                {
                    current.next = next;
                    next.prev = current;
                }
            }
            current = current.next;
            if (current != null) next = current.next;
        }

        return head;
    }

    private static Node FindEnd(Node node)
    {
        while (node.next != null)
        {
            node = node.next;
        }
        return node;
    }
}