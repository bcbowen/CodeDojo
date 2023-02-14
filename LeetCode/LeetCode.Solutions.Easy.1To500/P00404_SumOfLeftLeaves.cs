using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00404_SumOfLeftLeaves;

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