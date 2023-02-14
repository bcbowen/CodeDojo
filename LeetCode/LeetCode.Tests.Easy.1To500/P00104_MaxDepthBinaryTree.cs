using LeetCode.Models.Tree.BinaryTree;
using LeetCode.Solutions.Easy.P00104_MaxDepthBinaryTree;

namespace LeetCode.Tests.Easy.P00104_MaxDepthBinaryTree;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    public void Example1Test()
    {
        /*
            Input: root = [3,9,20,null,null,15,7]
            Output: 3
        */

        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        TreeNode current = root.right;
        current.left = new TreeNode(15);
        current.right = new TreeNode(7);

        int expectedMaxDepth = 3;
        int maxDepth = new Solution().MaxDepth(root);
        Assert.AreEqual(expectedMaxDepth, maxDepth);
    }

    [Test]
    public void Example2Test()
    {
        /*
            Input: root = [1,null,2]
            Output: 2
        */

        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);

        int expectedMaxDepth = 2;
        int maxDepth = new Solution().MaxDepth(root);
        Assert.AreEqual(expectedMaxDepth, maxDepth);
    }


}