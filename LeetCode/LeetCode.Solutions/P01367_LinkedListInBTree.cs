using LeetCode.Solutions.Models.LinkedList;
using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.P01367_LinkedListInBTree;

public class Solution
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        if (root == null) return false;

        //if head val, found in tree
        //search path
        if (head.val == root.val)
        {
            if (SearchPath(head, root)) return true;
        }

        //path didn't find
        //now search in left subtree, 
        //if didn't found search in right subtree
        return IsSubPath(head, root.left) || IsSubPath(head, root.right);
    }


    private bool SearchPath(ListNode listNode, TreeNode treeNode)
    {
        //base cases
        //if tree node reched to end,
        //check list node reached to end or node
        if (treeNode == null) return listNode == null;

        //list node reached to end, it meand found 
        if (listNode == null) return true;

        //if treeNode val is not match with list val,
        //return, no need to search further
        if (treeNode.val != listNode.val) return false;

        return SearchPath(listNode.next, treeNode.left)
            || SearchPath(listNode.next, treeNode.right);
    }

}

public static class TreeNodeParser
{
    public static TreeNode Parse(string serialized)
    {
        if (string.IsNullOrEmpty(serialized) || serialized == "[]")
        {
            return null;
        }

        serialized = serialized.Replace("[", "").Replace("]", "");
        string[] nodes = serialized.Split(',');
        TreeNode root = new TreeNode(int.Parse(nodes[0]));
        Queue<TreeNode> nodeQ = new Queue<TreeNode>();
        TreeNode node = root;
        nodeQ.Enqueue(node);
        int index = 1;
        while (nodeQ.Count > 0 && index < nodes.Length)
        {
            node = nodeQ.Dequeue();
            int value;
            if (nodes[index] != "null")
            {
                value = int.Parse(nodes[index]);
                node.left = new TreeNode(value);
                nodeQ.Enqueue(node.left);
            }
            index++;

            if (index >= nodes.Length) break;

            if (nodes[index] != "null")
            {
                value = int.Parse(nodes[index]);
                node.right = new TreeNode(value);
                nodeQ.Enqueue(node.right);
            }
            index++;
        }

        return root;
    }
}
