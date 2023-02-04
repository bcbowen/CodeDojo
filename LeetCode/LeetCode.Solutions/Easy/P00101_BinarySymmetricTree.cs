using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00101_BinarySymmetricTree;

public class Solution
{
    private bool IsSymmetric(TreeNode left, TreeNode right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;
        if (left.val != right.val) return false;
        if (!IsSymmetric(left.left, right.right)) return false;
        if (!IsSymmetric(left.right, right.left)) return false;
        return true;

    }
}