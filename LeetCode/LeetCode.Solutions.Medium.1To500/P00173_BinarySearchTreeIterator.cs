using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Medium.P00173_BinarySearchTreeIterator;

public class BSTIterator
{
    private int _pointer; // starts out smaller than the smallest element, then points to the currnet element

    private List<int> _nodes;

    // init pointer to 1 less than the min value in the tree
    public BSTIterator(TreeNode root)
    {
        _pointer = -1;
        _nodes = new List<int>();
        SetInorderValues(root);

    }

    internal void SetInorderValues(TreeNode node)
    {
        if (node == null) return;

        SetInorderValues(node.left);
        _nodes.Add(node.val);
        SetInorderValues(node.right);
    }

    public int Next()
    {
        return HasNext() ? _nodes[++_pointer] : -1;
    }

    public bool HasNext()
    {
        return _pointer < _nodes.Count - 1;
    }

}