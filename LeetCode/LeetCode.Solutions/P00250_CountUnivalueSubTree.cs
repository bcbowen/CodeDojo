using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.P00250_CountUnivalueSubTree;

public partial class Solution
{
    private int _count = 0;
    public int CountUnivalSubtrees(TreeNode root)
    {
        IsUnival(root);

        return _count;
    }

    private bool IsUnival(TreeNode node)
    {
        if (node == null) return false;

        bool isLUnival = node.left == null || IsUnival(node.left) && node.left.val == node.val;
        bool isRunival = node.right == null || IsUnival(node.right) && node.right.val == node.val;

        if (isLUnival && isRunival)
        {
            _count++;
            return true;
        }
        return false;
    }

   
}

public class Solution2
{
    // https://leetcode.com/problems/count-univalue-subtrees/discuss/2252460/Recursive-C
    int count;

    public int CountUnivalSubtrees(TreeNode root)
    {
        IsUnivalSubtree(root);
        return count;
    }

    public bool IsUnivalSubtree(TreeNode root)
    {
        if (root == null)
        {
            return false;
        }

        var isUnivalueL = (root.left == null || (IsUnivalSubtree(root.left) && root.left.val == root.val));
        var isUnivalueR = (root.right == null || (IsUnivalSubtree(root.right) && root.right.val == root.val));

        var isUnivalue = isUnivalueL && isUnivalueR;

        count += (isUnivalue ? 1 : 0);

        return isUnivalue;
    }
}