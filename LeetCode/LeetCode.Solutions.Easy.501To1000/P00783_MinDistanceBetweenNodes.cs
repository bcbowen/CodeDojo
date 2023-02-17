using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00783_MinDistanceBetweenNodes;

public class Solution
{
    public int MinDiffInBST(TreeNode root)
    {
        List<int> inorderValues = new List<int>();
        GetInorderValues(root, inorderValues);
        int min = inorderValues[1] - inorderValues[0];
        for (int i = 2; i < inorderValues.Count; i++) 
        {
            min = Math.Min(min, inorderValues[i] - inorderValues[i - 1]);
        }
        return min;
    }

    internal void GetInorderValues(TreeNode root, List<int> values)
    {
        if (root == null) return;
        if (root.left != null) 
        {
            GetInorderValues(root.left, values);
        }
        values.Add(root.val);
        if (root.right != null) 
        {
            GetInorderValues(root.right, values);
        }
    }
}