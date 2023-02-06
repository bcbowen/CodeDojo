using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.Medium.P00236_LowestCommonAncestorBinaryTree;

namespace LeetCode.Tests.Medium;

public class Tests
{
    [Test]
    public void Example1()
    {
        /*
        Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
        Output: 3
        Explanation: The LCA of nodes 5 and 1 is 3.
        */
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.right.left = new TreeNode(7);
        root.left.right.left = new TreeNode(4);

        root.right = new TreeNode(1);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);

        TreeNode result = new Solution().LowestCommonAncestor(root, root.left, root.right);
        Assert.AreEqual(root.val, result.val);
    }

    [Test]
    public void Example2()
    {
        /*
        Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
    Output: 5
    Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
        */
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(5);
        root.left.left = new TreeNode(6);
        root.left.right = new TreeNode(2);
        root.left.right.left = new TreeNode(7);
        root.left.right.left = new TreeNode(4);

        root.right = new TreeNode(1);
        root.right.left = new TreeNode(0);
        root.right.right = new TreeNode(8);

        TreeNode result = new Solution().LowestCommonAncestor(root, root.left, root.left.right.left);
        Assert.AreEqual(root.left.val, result.val);
    }

    [Test]
    public void Example3()
    {
        /*
        Input: root = [1,2], p = 1, q = 2
        Output: 1.
        */
        TreeNode node = new TreeNode(1);
        node.left = new TreeNode(2);

        TreeNode result = new Solution().LowestCommonAncestor(node, node, node.left);
        Assert.AreEqual(node.val, result.val);
    }

}