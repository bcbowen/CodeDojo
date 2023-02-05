using LeetCode.Solutions.P00430_FlattenMultilevelDoublyLinkedList;
using LeetCode.Solutions.Models.DoublyLinkedList;

namespace Medium;

public class Tests
{
    [Test]
    public void FlattenTest1()
    {
        int?[] values = new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 };
        int[] expected = new[] { 1, 2, 3, 7, 8, 11, 12, 9, 10, 4, 5, 6 };
        Node expanded = Node.Init(values);
        Node flat = new Solution().Flatten(expanded);
        int[] result = Node.GetTopValues(flat);
        Assert.AreEqual(expected, result);
    }

    /*
    Input: head = [1,2,null,3]
    Output: [1,3,2]
    */

    [Test]
    public void FlattenTest2()
    {
        int?[] values = new int?[] { 1, 2, null, 3 };
        int[] expected = new[] { 1, 3, 2 };
        Node expanded = Node.Init(values);
        Node flat = new Solution().Flatten(expanded);
        int[] result = Node.GetTopValues(flat);
        Assert.AreEqual(expected, result);
    }

    /*
    Input: head = []
    Output: []
    */

    [Test]
    public void FlattenTest3()
    {
        int?[] values = new int?[0];
        int[] expected = new int[0];
        Node expanded = Node.Init(values);
        Node flat = new Solution().Flatten(expanded);
        int[] result = Node.GetTopValues(flat);
        Assert.AreEqual(expected, result);
    }

    /*
    input: [1,null,2,null,3,null]
    output: [1,2,3]
    */

    [Test]
    public void FlattenTest4()
    {
        int?[] values = new int?[] { 1, null, 2, null, 3, null };
        int[] expected = new[] { 1, 2, 3 };
        Node expanded = Node.Init(values);
        Node flat = new Solution().Flatten(expanded);
        int[] result = Node.GetTopValues(flat);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void InitTest1()
    {
        int?[] values = { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 };
        Node node = Node.Init(values);
        (int count, Node current) = Node.GetLast(node);
        Assert.AreEqual(6, current.val);
        Assert.AreEqual(6, count);

        current = Node.Get(node, 2);
        Assert.AreEqual(3, current.val);

        Assert.NotNull(current.child);

        current = current.child;
        Assert.AreEqual(7, current.val);

        node = current;
        (count, current) = Node.GetLast(node);
        Assert.AreEqual(10, current.val);
        Assert.AreEqual(4, count);

        current = Node.Get(node, 1);
        Assert.AreEqual(8, current.val);
        current = current.child;
        Assert.AreEqual(11, current.val);

        node = current;
        (count, current) = Node.GetLast(node);
        Assert.AreEqual(12, current.val);
        Assert.AreEqual(2, count);
    }

    [Test]
    public void InitTest2()
    {
        int?[] values = { 1, 2, null, 3 };
        Node node = Node.Init(values);
        (int count, Node current) = Node.GetLast(node);
        Assert.AreEqual(2, current.val);
        Assert.AreEqual(2, count);

        Assert.NotNull(node.child);

        current = node.child;
        Assert.AreEqual(3, current.val);

        node = current;
        (count, current) = Node.GetLast(node);
        Assert.AreEqual(3, current.val);
        Assert.AreEqual(1, count);
    }

    [Test]
    public void InitTest3()
    {
        int?[] values = new int?[0];
        Node node = Node.Init(values);

        Assert.Null(node);
    }

    [Test]
    public void InitTest4()
    {
        int?[] values = { 1, null, 2, null, 3, null };
        Node node = Node.Init(values);
        (int count, Node current) = Node.GetLast(node);
        Assert.AreEqual(1, current.val);
        Assert.AreEqual(1, count);

        Assert.NotNull(node.child);

        current = node.child;
        Assert.AreEqual(2, current.val);
        node = current;

        current = node.child;
        Assert.AreEqual(3, current.val);
    }


}