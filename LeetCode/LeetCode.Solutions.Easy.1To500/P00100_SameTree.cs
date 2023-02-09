using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00100_SameTree;

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == q) return true;
        if (p == null || q == null) return false;

        if (p.val != q.val) return false;

        if (!IsSameTree(p.left, q.left)) return false;
        if (!IsSameTree(p.right, q.right)) return false;

        return true;
    }
}