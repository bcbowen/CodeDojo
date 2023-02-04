using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.Easy.P00100_SameTree;

namespace LeetCode.Tests.Easy.P00100_SameTree;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    public void EqualTreesReturnsTrue()
    {
        TreeNode node = new TreeNode(1);
        node.left = new TreeNode(2);
        node.right = new TreeNode(3);
        node.right.left = new TreeNode(4);
        node.right.right = new TreeNode(5);
        Assert.True(new Solution().IsSameTree(node, node));
    }

    [Test]
    public void OneNullTreeReturnsFalse()
    {
        TreeNode node = new TreeNode(1);
        Assert.False(new Solution().IsSameTree(node, null));
        Assert.False(new Solution().IsSameTree(null, node));
    }

    [Test]
    public void TwoNullTreesReturnsTrue()
    {
        Assert.True(new Solution().IsSameTree(null, null));
    }

    [Test]
    public void EqualTreesReturnTrue()
    {
        /*
        Input: p = [1,2,3], q = [1,2,3]
        Output: true
        */
        TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(1);

        t1.left = new TreeNode(2);
        t2.left = new TreeNode(2);

        t1.right = new TreeNode(3);
        t2.right = new TreeNode(3);

        Assert.True(new Solution().IsSameTree(t1, t2));
    }

    [Test]
    public void AsymmetricTreesReturnFalse()
    {
        /*
        Input: p = [1,2], q = [1,null,2]
        Output: false
        */

        TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(1);

        t1.left = new TreeNode(2);
        t2.right = new TreeNode(2);

        Assert.False(new Solution().IsSameTree(t1, t2));
    }

    [Test]
    public void UnequalTreesReturnFalse()
    {
        /*
        Input: p = [1,2,1], q = [1,1,2]
        Output: false
        */

        TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(1);

        t1.left = new TreeNode(2);
        t2.left = new TreeNode(1);

        t1.right = new TreeNode(1);
        t2.right = new TreeNode(2);

        Assert.False(new Solution().IsSameTree(t1, t2));
    }


}