using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy;

public class Solution
{
    public IList<int> PreorderTraversal(TreeNode root)
    {
        List<int> values = new List<int>();
        if (root == null) return values;
        values.Add(root.val);
        values.AddRange(PreorderTraversal(root.left));
        values.AddRange(PreorderTraversal(root.right));
        return values;
    }
}