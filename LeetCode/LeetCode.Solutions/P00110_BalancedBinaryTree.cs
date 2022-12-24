using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.P00110_BalancedBinaryTree;

public class Solution
{
    public bool IsBalanced(TreeNode root)
    {
        if (root == null || IsLeaf(root)) return true;

        (int leftDepth, int rightDepth, bool IsUnbalanced) = TraverseTree(root, 0);
        return !IsUnbalanced;
    }

    private (int, int, bool) TraverseTree(TreeNode node, int depth)
    {
        int leftDepth = depth;
        int rightDepth = depth;
        bool isUnbalanced = false;

        if (node.left != null)
        {
            (int l, int r, bool u) = TraverseTree(node.left, depth + 1);
            if (u || Math.Abs(l - r) > 1) isUnbalanced = true;
            leftDepth = Math.Max(l, r);
        }

        if (node.right != null)
        {
            (int l, int r, bool u) = TraverseTree(node.right, depth + 1);
            if (u || Math.Abs(l - r) > 1) isUnbalanced = true;
            rightDepth = Math.Max(l, r);
        }

        if (Math.Abs(leftDepth - rightDepth) > 1) isUnbalanced = true;
        return (leftDepth, rightDepth, isUnbalanced);

    }

    private bool IsLeaf(TreeNode node)
    {
        return node.left == null && node.right == null;
    }
}