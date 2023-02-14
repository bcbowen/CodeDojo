using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00104_MaxDepthBinaryTree;

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