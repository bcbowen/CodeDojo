using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.P00404_SumOfLeftLeaves;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [Test]
    public void Example1Test()
    {
        /*
            Input: root = [3,9,20,null,null,15,7]
            Output: 24
            Explanation: There are two left leaves in the binary tree, with values 9 and 15 respectively.
        */

        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        TreeNode current = root.right;
        current.left = new TreeNode(15);
        current.right = new TreeNode(7);

        int expected = 24;
        int result = new Solution().SumOfLeftLeaves(root);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Example2Test()
    {
        /*
            Input: root = [1]
            Output: 0
        */

        TreeNode root = new TreeNode(1);

        int expected = 0;
        int result = new Solution().SumOfLeftLeaves(root);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Example3Test()
    {
        /*
            Input [1,2,3,4,5]
            Output 6
            Expected 4
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        TreeNode current = root.left;
        current.left = new TreeNode(4);
        current.right = new TreeNode(5);

        int expected = 4;
        int result = new Solution().SumOfLeftLeaves(root);
        Assert.That(result, Is.EqualTo(expected));
    }

}