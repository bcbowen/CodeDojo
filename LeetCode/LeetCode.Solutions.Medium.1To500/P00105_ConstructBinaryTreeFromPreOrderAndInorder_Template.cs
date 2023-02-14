using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Medium.P00105_ConstructBinaryTreeFromPreOrderAndInorder_Template;

public class Solution
{
    private int[] _preorder;
    private int[] _inorder;
    private int _preIndex;
    Dictionary<int, int> _inorderIndexes;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        _preorder = preorder;
        _inorder = inorder;

        _inorderIndexes = new Dictionary<int, int>();
        for (int i = 0; i < _inorder.Length; i++)
        {
            _inorderIndexes.Add(_inorder[i], i);
        }
        _preIndex = 0;
        return BuildSubTree(0, _inorder.Length - 1);
    }

    internal TreeNode BuildSubTree(int leftIndex, int rightIndex)
    {
        if (leftIndex > rightIndex) return null;
        int rootVal = _preorder[_preIndex];
        TreeNode root = new TreeNode(rootVal);

        int index = _inorderIndexes[rootVal];
        _preIndex++;
        root.left = BuildSubTree(leftIndex, index - 1);
        root.right = BuildSubTree(index + 1, rightIndex);
        return root;
    }
}