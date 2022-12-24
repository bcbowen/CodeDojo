using System.Xml.Linq;

namespace LeetCode.Solutions.P00116_PopulatingNextRightPointersInBinaryTree;

public class Solution
{
    /// <summary>
    /// One off non-standard binary tree with extra pointer for next
    /// </summary>
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public Node Connect(Node root)
    {
        if (root == null) return root;

        Queue<Node> nodeQueue = new Queue<Node>();
        nodeQueue.Enqueue(root);
        while (nodeQueue.Count > 0)
        {
            int levelCount = nodeQueue.Count();
            Node last = null;
            for (int i = 0; i < levelCount; i++)
            {
                Node current = nodeQueue.Dequeue();
                if (current.left != null) nodeQueue.Enqueue(current.left);
                if (current.right != null) nodeQueue.Enqueue(current.right);
                if (last != null) last.next = current;
                last = current;
            }
        }

        return root;
    }
}