using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.P00112_BinaryTreePathSum;

namespace LeetCode.Tests.P00112_BinaryTreePathSum;

public class Tests
{
    [Test]
    public void Example1()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        int target = 22;
        bool expected = true;
        bool result = new Solution().HasPathSum(root, target);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example2()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        int target = 5;
        bool expected = false;
        bool result = new Solution().HasPathSum(root, target);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example3()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);

        int target = 1;
        bool expected = false;
        bool result = new Solution().HasPathSum(root, target);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example4()
    {
        TreeNode root = new TreeNode(1);

        int target = 1;
        bool expected = true;
        bool result = new Solution().HasPathSum(root, target);
        Assert.AreEqual(expected, result);
    }


}