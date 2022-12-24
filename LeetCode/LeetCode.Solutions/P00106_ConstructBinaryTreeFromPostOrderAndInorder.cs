using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.P00106_ConstructBinaryTreeFromPostOrderAndInorder;

public class Solution
{
    private int[] _postorder;
    private int[] _inorder;
    private int _postIndex;
    Dictionary<int, int> _inorderIndexes;

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        _postorder = postorder;
        _inorder = inorder;

        _inorderIndexes = new Dictionary<int, int>();
        for (int i = 0; i < _inorder.Length; i++)
        {
            _inorderIndexes.Add(_inorder[i], i);
        }
        _postIndex = postorder.Length - 1;
        return BuildSubTree(0, _inorder.Length - 1);
    }

    internal TreeNode BuildSubTree(int leftIndex, int rightIndex)
    {
        if (leftIndex > rightIndex) return null;
        int rootVal = _postorder[_postIndex];
        TreeNode root = new TreeNode(rootVal);

        int index = _inorderIndexes[rootVal];
        _postIndex--;
        root.right = BuildSubTree(index + 1, rightIndex);
        root.left = BuildSubTree(leftIndex, index - 1);
        return root;
    }
}