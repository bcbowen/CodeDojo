using LeetCode.Solutions.P00116_PopulatingNextRightPointersInBinaryTree;
using static LeetCode.Solutions.P00116_PopulatingNextRightPointersInBinaryTree.Solution;

namespace Medium;

public class Tests
{

    [Test]
    public void Example1Test()
    {
        Node root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        root.left.left = new Node(4);
        root.left.right = new Node(5);

        root.right = new Node(3);
        root.right.left = new Node(6);
        root.right.right = new Node(7);

        Node result = new Solution().Connect(root);
        Assert.Null(result.next);

        Node current = result.left;
        Assert.AreEqual(3, current.next.val);
        Assert.Null(current.next.next);

        current = current.left;
        Assert.AreEqual(5, current.next.val);
        Assert.AreEqual(6, current.next.next.val);
        Assert.AreEqual(7, current.next.next.next.val);
        Assert.Null(current.next.next.next.next);
    }

    [Test]
    public void Example2Test()
    {
        Node root = null;
        Node result = new Solution().Connect(root);
        Assert.Null(result);
    }

}