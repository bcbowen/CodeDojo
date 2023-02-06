using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.Medium.P00250_CountUnivalueSubTree;

namespace LeetCode.Tests.Medium;

public class Tests
{
    [Test]
    public void Example1()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(1);
        root.right = new TreeNode(5);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 4;
        int result = new Solution().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example2()
    {
        TreeNode root = null;

        int expected = 0;
        int result = new Solution().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example3()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(5);
        root.right = new TreeNode(5);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 6;
        int result = new Solution().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    // [1,1,1,5,5,null,5]
    // 3

    [Test]
    public void Example4()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(1);
        root.right = new TreeNode(1);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 3;
        int result = new Solution().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example1b()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(1);
        root.right = new TreeNode(5);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 4;
        int result = new Solution2().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example2b()
    {
        TreeNode root = null;

        int expected = 0;
        int result = new Solution2().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example3b()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(5);
        root.right = new TreeNode(5);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 6;
        int result = new Solution2().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

    // [1,1,1,5,5,null,5]
    // 3
    /*    1
        /  \
       1    1
      / \    \
     5   5    5
    */
    [Test]
    public void Example4b()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(1);
        root.right = new TreeNode(1);

        root.left.left = new TreeNode(5);
        root.left.right = new TreeNode(5);

        root.right.right = new TreeNode(5);

        int expected = 3;
        int result = new Solution2().CountUnivalSubtrees(root);
        Assert.AreEqual(expected, result);
    }

}