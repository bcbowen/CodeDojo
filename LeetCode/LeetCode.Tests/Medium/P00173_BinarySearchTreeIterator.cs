using LeetCode.Solutions.Models.Tree.BinaryTree;
using LeetCode.Solutions.Medium.P00173_BinarySearchTreeIterator;

namespace LeetCode.Tests.Medium.P00173_BinarySearchTreeIterator;

public class Tests
{

    [Test]
    public void Test1()
    {
        TreeNode root = GetTestTree1();

        BSTIterator i = new BSTIterator(root);
        int expected = 3;
        int next = i.Next();
        Assert.AreEqual(expected, next);

        next = i.Next();
        expected = 7;
        Assert.AreEqual(expected, next);

        bool hasNext = i.HasNext();
        Assert.True(hasNext);

        next = i.Next();
        expected = 9;
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);

        next = i.Next();
        expected = 15;
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);

        next = i.Next();
        expected = 20;
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.False(hasNext);
    }

    /*
           7
         /  \
        3    15
            /  \
           9   20


    Input
    ["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
    [[[7, 3, 15, null, null, 9, 20]], [], [], [], [], [], [], [], [], []]
    Output
    [null, 3, 7, true, 9, true, 15, true, 20, false]

    Explanation
    BSTIterator bSTIterator = new BSTIterator([7, 3, 15, null, null, 9, 20]);
    bSTIterator.next();    // return 3
    bSTIterator.next();    // return 7
    bSTIterator.hasNext(); // return True
    bSTIterator.next();    // return 9
    bSTIterator.hasNext(); // return True
    bSTIterator.next();    // return 15
    bSTIterator.hasNext(); // return True
    bSTIterator.next();    // return 20
    bSTIterator.hasNext(); // return False
    */
    /*
             3
          /    \
        1       5
         \      / \
          2    4   6
    */
    [Test]
    public void Test2()
    {
        TreeNode root = GetTestTree2();

        BSTIterator i = new BSTIterator(root);
        int expected;
        bool hasNext = i.HasNext();

        Assert.True(hasNext);
        expected = 1;
        int next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);
        expected = 2;
        next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);
        expected = 3;
        next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);
        expected = 4;
        next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);
        expected = 5;
        next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.True(hasNext);
        expected = 6;
        next = i.Next();
        Assert.AreEqual(expected, next);

        hasNext = i.HasNext();
        Assert.False(hasNext);
    }

    /*
             3
          /    \
        1       5
         \      / \
          2    4   6


    ["BSTIterator","hasNext","next","hasNext","next","hasNext","next","hasNext","next","hasNext"]
    [[[3,1,4,null,2]],[],[],[],[],[],[],[],[],[]]
    Output
    [null,true,1,true,3,true,4,false,0,false]
    Expected
    [null,true,1,true,2,true,3,true,4,false]

    */

    /*

    /*
           7
         /  \
        3    15
            /  \
           9   20

    */
    private TreeNode GetTestTree1()
    {
        TreeNode root = new TreeNode(7);
        root.left = new TreeNode(3);
        root.right = new TreeNode(15);
        root.right.left = new TreeNode(9);
        root.right.right = new TreeNode(20);

        return root;
    }


    /*
             3
          /    \
        1        5
         \      / \
          2    4   6
    */
    private TreeNode GetTestTree2()
    {
        TreeNode root = new TreeNode(3);
        root.left = new TreeNode(1);
        root.left.right = new TreeNode(2);
        root.right = new TreeNode(5);
        root.right.left = new TreeNode(4);
        root.right.right = new TreeNode(6);

        return root;

    }

    /*
            7
         /    \
        3      15
         \    /  \
          5   9   20

    */
    private TreeNode GetTestTree3()
    {
        TreeNode root = GetTestTree1();
        root.left.right = new TreeNode(5);
        return root;
    }


    /*
            7
         /    \
        3      15
         \    /  \
          5   9   20
         /
        4 
    */
    private TreeNode GetTestTree4()
    {
        TreeNode root = GetTestTree3();
        root.left.right.left = new TreeNode(4);
        return root;
    }
}