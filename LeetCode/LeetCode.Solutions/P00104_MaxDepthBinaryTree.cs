using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.P000104_MaxDepthBinaryTree;

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null) return 0;

        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);

        return Math.Max(left, right) + 1;
    }
}