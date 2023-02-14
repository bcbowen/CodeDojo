namespace LeetCode.Solutions.Medium.P00138_CopyListWithRandomPointer;

public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head == null) return head;
        int index = 0;
        Dictionary<Node, int> indexLookup = new Dictionary<Node, int>();
        Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
        Node copy = new Node(head.val);
        indexLookup.Add(head, index);
        nodeLookup.Add(index, copy);
        index++;

        Node c1 = head;
        Node c2 = copy;

        while (c1.next != null)
        {
            c1 = c1.next;
            c2.next = new Node(c1.val);
            c2 = c2.next;
            indexLookup.Add(c1, index);
            nodeLookup.Add(index, c2);
            index++;
        }

        c1 = head;
        c2 = copy;

        if (c1.random == null)
        {
            c2.random = null;
        }
        else
        {
            int i = indexLookup[c1.random];
            c2.random = nodeLookup[i];
        }

        while (c1.next != null)
        {
            c1 = c1.next;
            c2 = c2.next;

            if (c1.random == null)
            {
                c2.random = null;
            }
            else
            {
                int i = indexLookup[c1.random];
                c2.random = nodeLookup[i];
            }
        }
        return copy;
    }
}