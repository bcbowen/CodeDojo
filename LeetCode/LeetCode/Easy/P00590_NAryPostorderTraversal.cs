using LeetCode.Solutions.P00590_NAryPostorderTraversal;
using LeetCode.Solutions.Models.Tree.NAryTree;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [Test]
    public void Example1Test()
    {
        Node root = new Node(1);
        Node current = root;
        current.children.Add(new Node(3));
        current.children.Add(new Node(2));
        current.children.Add(new Node(4));
        current = current.children[0];
        current.children.Add(new Node(5));
        current.children.Add(new Node(6));

        int[] result = new Solution().Postorder(root).ToArray();
        int[] expected = new int[] { 5, 6, 3, 2, 4, 1 };

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Example2Test()
    {
        Node root = new Node(1);
        Node current = root;
        current.children.Add(new Node(2));
        current.children.Add(new Node(3));
        current.children.Add(new Node(4));
        current.children.Add(new Node(5));

        // 3
        current = current.children[1];
        current.children.Add(new Node(6));
        current.children.Add(new Node(7));

        // 4
        current = root.children[2];
        current.children.Add(new Node(8));
        // 5
        current = root.children[3];
        current.children.Add(new Node(9));
        current.children.Add(new Node(10));

        // 7
        current = root.children[1].children[1];
        current.children.Add(new Node(11));
        current = current.children[0];
        current.children.Add(new Node(14));

        // 8
        current = root.children[2].children[0];
        current.children.Add(new Node(12));

        // 9
        current = root.children[3].children[0];
        current.children.Add(new Node(13));

        int[] result = new Solution().Postorder(root).ToArray();
        int[] expected = new int[] { 2, 6, 14, 11, 7, 3, 12, 8, 4, 13, 9, 10, 5, 1 };

        Assert.AreEqual(expected, result);
    }


}