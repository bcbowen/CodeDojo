using LeetCode.Models.Tree.BinaryTree;
using LeetCode.Solutions.Hard.P00297_SerializeAndDeserializeBinaryTree;

namespace LeetCode.Tests.Hard.P00297_SerializeAndDeserializeBinaryTree;

[TestFixture]
[Category("Hard")]
public class Tests
{
    [Test]
    public void FullTest1()
    {
        TreeNode node = new TreeNode(1);
        node.left = new TreeNode(2);
        node.right = new TreeNode(3);
        node.right.left = new TreeNode(4);
        node.right.right = new TreeNode(5);

        Codec c = new Codec();
        string serialized = c.serialize(node);

        TreeNode deserilized = c.deserialize(serialized);

        Assert.AreEqual(1, deserilized.val);
        Assert.AreEqual(2, deserilized.left.val);
        Assert.AreEqual(3, deserilized.right.val);
        Assert.AreEqual(4, deserilized.right.left.val);
        Assert.AreEqual(5, deserilized.right.right.val);

    }



    /*
    Input: root = [1,2,3,null,null,4,5]
    Output: [1,2,3,null,null,4,5]
    Example 2:

    Input: root = []
    Output: []


    */
    #region serialize

    [Test]
    public void SerializeEmptyTree()
    {
        Codec c = new Codec();
        TreeNode root = null;
        string result = c.serialize(root);
        string expected = "null";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SerializeSingleNodeTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        string result = c.serialize(root);
        string expected = "1,null,null";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SerializeFullTwoLevelTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.right = new TreeNode(3);
        string result = c.serialize(root);
        string expected = "1,2,null,null,3,null,null";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SerializePartialTwoLevelTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        string result = c.serialize(root);
        string expected = "1,2,null,null,null";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SerializeFiveNodeTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.right = new TreeNode(5);
        string result = c.serialize(root);
        string expected = "1,2,3,null,null,4,null,null,5,null,null";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SerializeFullThreeLevelTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.right = new TreeNode(5);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);
        string result = c.serialize(root);
        string expected = "1,2,3,null,null,4,null,null,5,6,null,null,7,null,null";
        Assert.AreEqual(expected, result);

    }

    #endregion

    #region deserialize

    [Test]
    public void DeSerializeSingleNodeTree()
    {
        Codec c = new Codec();
        string s = "1,null,null";
        TreeNode root = c.deserialize(s);
        Assert.AreEqual(1, root.val);
        Assert.Null(root.left);
        Assert.Null(root.right);
    }

    [Test]
    public void DeSerializeFullTwoLevelTree()
    {
        Codec c = new Codec();
        string data = "1,2,null,null,3,null,null";
        TreeNode root = c.deserialize(data);
        Assert.AreEqual(1, root.val);
        Assert.AreEqual(2, root.left.val);
        Assert.AreEqual(3, root.right.val);
        Assert.Null(root.left.left);
        Assert.Null(root.left.right);
        Assert.Null(root.right.left);
        Assert.Null(root.right.right);
    }

    [Test]
    public void DeSerializePartialTwoLevelTree()
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        string result = c.serialize(root);
        string expected = "1,2,null,null,null";
        Assert.AreEqual(expected, result);
    }

    #endregion

    #region troubleshooting

    /*

     [4,-7,-3,null,null,-9,-3,9,-7,-4,null,6,null,-6,-6,null,null,0,6,5,null,9,null,null,-1,-4,null,null,null,-2]

    */

    [Test]
    public void BigHonkingTreeTest()
    {
        TreeNode node = new TreeNode(4);
        node.left = new TreeNode(-7);
        node.right = new TreeNode(-3);

        TreeNode current = node.right;
        current.left = new TreeNode(-9);
        current.right = new TreeNode(-3);
        current.right.left = new TreeNode(-4);

        current = current.left;
        current.left = new TreeNode(9);
        current.right = new TreeNode(-7);

        // left side from 9
        current.left.left = new TreeNode(6);
        current.left.left.left = new TreeNode(0);
        current.left.left.left.right = new TreeNode(-1);
        current.left.left.right = new TreeNode(6);
        current.left.left.right.left = new TreeNode(-4);

        // right side from -7
        current = current.right;
        current.left = new TreeNode(-6);
        current.left.left = new TreeNode(5);
        current.right = new TreeNode(-6);
        current = current.right;
        current.left = new TreeNode(9);
        current.left.left = new TreeNode(-2);

        Codec c = new Codec();
        string s = c.serialize(node);
        Assert.AreEqual("4,-7,null,null,-3,-9,9,6,0,null,-1,null,null,6,-4,null,null,null,null,-7,-6,5,null,null,null,-6,9,-2,null,null,null,null,-3,-4,null,null,null", s);
        TreeNode d = c.deserialize(s);

    }

    [Test]
    public void OneLevelMissingLeftChild()
    {
        TreeNode node = new TreeNode(1);
        node.right = new TreeNode(2);
        Codec c = new Codec();
        string s = c.serialize(node);
        Assert.AreEqual("1,null,2,null,null", s);
        TreeNode d = c.deserialize(s);
        Assert.AreEqual(1, d.val);
        Assert.Null(d.left);
        Assert.AreEqual(2, d.right.val);
        Assert.Null(d.right.left);
        Assert.Null(d.right.right);
    }
    #endregion troubleshooting



    /*

    Input:
    [1,null,2]
    Output:
    [1,2]
    Expected:
    [1,null,2]


    [Test]
    void SerializeFiveNodeTree() 
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3); 
        root.left.right = new TreeNode(4); 
        root.right = new TreeNode(5);
        string result = c.serialize(root);
        string expected = "[1,2,3,null,null,4,null,null,5,null,null]";
        Assert.AreEqual(expected, result);
    }

    [Test]
    void SerializeFullThreeLevelTree() 
    {
        Codec c = new Codec();
        TreeNode root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.right = new TreeNode(5);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);
        string result = c.serialize(root);
        string expected = "[1,2,3,null,null,4,null,null,5,6,null,null,7,null,null]";
        Assert.AreEqual(expected, result);

    }
    */



}