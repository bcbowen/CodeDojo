using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy;

public class Solution
{
    public int SumOfLeftLeaves(TreeNode root)
    {
        if (root == null) return 0;

        int sum = 0;
        if (root.left != null && root.left.left == null && root.left.right == null)
        {
            sum += root.left.val;
        }
        sum += SumOfLeftLeaves(root.left);
        sum += SumOfLeftLeaves(root.right);

        return sum;
    }
}