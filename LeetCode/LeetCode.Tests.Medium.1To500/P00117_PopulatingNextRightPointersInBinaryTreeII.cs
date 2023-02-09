using LeetCode.Solutions.Medium.P00117_PopulatingNextRightPointersInBinaryTreeII;

namespace LeetCode.Tests.Medium;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void Example1Test()
    {
        Solution.Node root = new Solution.Node(1);
        root.left = new Solution.Node(2);
        root.right = new Solution.Node(3);
        root.left.left = new Solution.Node(4);
        root.left.right = new Solution.Node(5);

        root.right = new Solution.Node(3);
        root.right.right = new Solution.Node(7);

        Solution.Node result = new Solution().Connect(root);
        Assert.Null(result.next);

        Solution.Node current = result.left;
        Assert.AreEqual(3, current.next.val);
        Assert.Null(current.next.next);

        current = current.left;
        Assert.AreEqual(5, current.next.val);
        Assert.AreEqual(7, current.next.next.val);
        Assert.Null(current.next.next.next);
    }

    [Test]
    public void Example2Test()
    {
        Solution.Node root = null;
        Solution.Node result = new Solution().Connect(root);
        Assert.Null(result);
    }

}