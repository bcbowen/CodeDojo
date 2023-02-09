using LeetCode.Models.Tree.BinaryTree;
using LeetCode.Solutions.Medium.P00105_ConstructBinaryTreeFromPreOrderAndInorder_Template;

namespace LeetCode.Tests.Medium.P00105_ConstructBinaryTreeFromPreOrderAndInorder_Template;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void P00105_Example1()
    {
        /*
        Input: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
    Output: [3,9,20,null,null,15,7]
        */
        int[] inorder = { 9, 3, 15, 20, 7 };
        int[] preorder = { 3, 9, 20, 15, 7 };
        TreeNode root = new Solution().BuildTree(preorder, inorder);

        Assert.AreEqual(3, root.val);
        Assert.AreEqual(9, root.left.val);
        Assert.AreEqual(20, root.right.val);
        Assert.AreEqual(15, root.right.left.val);
        Assert.AreEqual(7, root.right.right.val);
    }

    [Test]
    public void P00105_Example2()
    {
        /*
        Input: inorder = [-1], postorder = [-1]
        Output: [-1]
        */
        int[] inorder = new int[] { -1 };
        int[] preorder = new int[] { -1 };
        TreeNode root = new Solution().BuildTree(preorder, inorder);
        Assert.AreEqual(-1, root.val);
        Assert.Null(root.left);
        Assert.Null(root.right);
    }

}