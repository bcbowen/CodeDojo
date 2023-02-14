using LeetCode.Models.Tree.BinaryTree;
using LeetCode.Solutions.Easy.P00110_BalancedBinaryTree;

namespace LeetCode.Tests.Easy.P00110_BalancedBinaryTree;

[TestFixture]
[Category("Easy")]
public class Tests
{

    [Test]
    public void Example1()
    {
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);

        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        bool expected = true;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example2()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(2);

        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(3);

        root.left.left.left = new TreeNode(4);
        root.left.left.right = new TreeNode(4);

        bool expected = false;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example3()
    {
        TreeNode root = null;

        bool expected = true;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

    /*
    [1,null,2,null,3]
    Output
    true
    Expected
    false
    */

    [Test]
    public void Example4()
    {
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);

        bool expected = false;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

    /*
    Input
    [1,2,2,3,null,null,3,4,null,null,4]
    Output
    true
    Expected
    false
    */

    [Test]
    public void Example5()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(2);

        root.left.left = new TreeNode(3);
        root.right.right = new TreeNode(3);

        root.left.left.left = new TreeNode(4);
        root.right.right.right = new TreeNode(4);

        bool expected = false;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

    /*
    Input
    [1,2,3,4,5,6,null,8]
    Output
    false
    Expected
    true

            1
         /    \
        2      3
       / \    /  
      4   5  6   
     /
    8


    */

    [Test]
    public void Example6()
    {
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);

        root.left.left = new TreeNode(4);
        root.left.right = new TreeNode(5);

        root.right.left = new TreeNode(6);

        root.left.left.left = new TreeNode(8);

        bool expected = true;
        bool result = new Solution().IsBalanced(root);
        Assert.AreEqual(expected, result);
    }

}