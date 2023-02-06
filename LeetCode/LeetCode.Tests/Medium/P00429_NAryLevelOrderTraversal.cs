using LeetCode.Solutions.Models.Tree.NAryTree;
using LeetCode.Solutions.Medium.P00429_NAryLevelOrderTraversal;

namespace LeetCode.Tests.Medium.P00429_NAryLevelOrderTraversal;

[TestFixture]
[Category("Medium")]
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

        IList<IList<int>> result = new Solution().LevelOrder(root);
        // Output: [[1],[3,2,4],[5,6]]
        Assert.AreEqual(3, result.Count);
        IList<int> row = result[0];
        Assert.AreEqual(1, row.Count);
        Assert.AreEqual(1, row[0]);

        row = result[1];
        Assert.AreEqual(3, row.Count);
        Assert.AreEqual(new List<int> { 3, 2, 4 }, row);

        row = result[2];
        Assert.AreEqual(2, row.Count);
        Assert.AreEqual(new List<int> { 5, 6 }, row);
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

        IList<IList<int>> result = new Solution().LevelOrder(root).ToArray();
        // [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
        Assert.AreEqual(5, result.Count);
        IList<int> row = result[0];
        Assert.AreEqual(1, row.Count);
        Assert.AreEqual(1, row[0]);

        row = result[1];
        Assert.AreEqual(4, row.Count);
        Assert.AreEqual(new List<int> { 2, 3, 4, 5 }, row);

        row = result[2];
        Assert.AreEqual(5, row.Count);
        Assert.AreEqual(new List<int> { 6, 7, 8, 9, 10 }, row);

        row = result[3];
        Assert.AreEqual(3, row.Count);
        Assert.AreEqual(new List<int> { 11, 12, 13 }, row);

        row = result[4];
        Assert.AreEqual(1, row.Count);
        Assert.AreEqual(14, row[0]);
    }


}