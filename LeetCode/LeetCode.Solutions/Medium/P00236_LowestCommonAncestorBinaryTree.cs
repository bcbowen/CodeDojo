using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Medium.P00236_LowestCommonAncestorBinaryTree;

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        (int count, TreeNode node) = FindAncestor(root, p.val, q.val);
        return node;
    }


    internal (int, TreeNode) FindAncestor(TreeNode root, int p, int q)
    {
        if (root == null) return (0, null);

        int matchCount = 0;
        int count;
        TreeNode ancestor = null;
        (count, ancestor) = FindAncestor(root.left, p, q);
        if (ancestor != null) return (count, ancestor);
        matchCount += count;

        (count, ancestor) = FindAncestor(root.right, p, q);
        if (ancestor != null) return (count, ancestor);
        matchCount += count;

        if (root.val == p || root.val == q) matchCount++;

        return (matchCount, matchCount >= 2 ? root : null);

    }
}