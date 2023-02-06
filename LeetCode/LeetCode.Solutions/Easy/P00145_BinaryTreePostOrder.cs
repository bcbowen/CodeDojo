using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00145_BinaryTreePostOrder;

public class Solution
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        List<int> values = new List<int>();
        if (root == null) return values;
        values.AddRange(PostorderTraversal(root.left));
        values.AddRange(PostorderTraversal(root.right));
        values.Add(root.val);
        return values;
    }
}