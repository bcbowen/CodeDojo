using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00094_BinaryTreeInOrder;

public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        {
            List<int> values = new List<int>();
            if (root == null) return values;
            values.AddRange(InorderTraversal(root.left));
            values.Add(root.val);
            values.AddRange(InorderTraversal(root.right));
            return values;
        }
    }
}