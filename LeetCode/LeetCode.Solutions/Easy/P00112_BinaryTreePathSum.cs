using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00112_BinaryTreePathSum;

public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root == null) return false;

        return PathSum(root, targetSum, 0);
    }

    private bool IsLeaf(TreeNode node)
    {
        return node != null && node.left == null && node.right == null;
    }

    private bool PathSum(TreeNode node, int targetSum, int currentSum)
    {
        if (node == null) return false;

        currentSum += node.val;

        if (IsLeaf(node) && currentSum == targetSum)
        {
            return true;
        }

        if (IsLeaf(node.left) && currentSum + node.left.val == targetSum)
        {
            return true;
        }

        if (IsLeaf(node.right) && currentSum + node.right.val == targetSum)
        {
            return true;
        }

        return PathSum(node.left, targetSum, currentSum) || PathSum(node.right, targetSum, currentSum);
    }
}