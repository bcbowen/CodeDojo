using LeetCode.Models.Tree.BinaryTree;
using LeetCode.Solutions.Medium.P00106_ConstructBinaryTreeFromPostOrderAndInorder;

namespace LeetCode.Tests.Medium.P00106_ConstructBinaryTreeFromPostOrderAndInorder;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void ConstructBinaryTree_Example1()
    {
        /*
        Input: inorder = [9, 3, 15, 20, 7], postorder = [9, 15, 7, 20, 3]
        Output: [3,9,20,null,null,15,7]	
        */
        int[] inorder = { 9, 3, 15, 20, 7 };
        int[] postorder = { 9, 15, 7, 20, 3 };
        TreeNode root = new Solution().BuildTree(inorder, postorder);

        Assert.AreEqual(3, root.val);
        Assert.AreEqual(9, root.left.val);
        Assert.AreEqual(20, root.right.val);
        Assert.AreEqual(15, root.right.left.val);
        Assert.AreEqual(7, root.right.right.val);
    }

    [Test]
    public void ConstructBinaryTree_Example2()
    {
        /*
        Input: inorder = [-1], postorder = [-1]
        Output: [-1]
        */
        int[] inorder = new int[] { -1 };
        int[] postorder = new int[] { -1 };
        TreeNode root = new Solution().BuildTree(inorder, postorder);
        Assert.AreEqual(-1, root.val);
        Assert.Null(root.left);
        Assert.Null(root.right);
    }


    [Test]
    public void ConstructBinaryTree_Example3()
    {
        int[] inorder = { 4, 2, 5, 1, 3 };
        int[] postorder = { 4, 5, 2, 3, 1 };
        TreeNode root = new Solution().BuildTree(inorder, postorder);

        Assert.AreEqual(1, root.val);
        Assert.AreEqual(2, root.left.val);
        Assert.AreEqual(3, root.right.val);
        Assert.AreEqual(4, root.left.left.val);
        Assert.AreEqual(5, root.left.right.val);
    }


    [Test]
    public void ConstructBinaryTree_Example4()
    {

        int[] inorder = { 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90 };
        int[] postorder = { 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25 };
        TreeNode root = new Solution().BuildTree(inorder, postorder);

        Assert.AreEqual(25, root.val);
        Assert.AreEqual(15, root.left.val);
        Assert.AreEqual(50, root.right.val);
        Assert.AreEqual(35, root.right.left.val);
        Assert.AreEqual(18, root.left.right.left.val);
    }


}