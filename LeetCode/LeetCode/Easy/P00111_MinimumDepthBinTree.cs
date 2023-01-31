using LeetCode.Solutions.Easy.P00111_MinimumDepthBinTree;
using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Tests.Easy.P00111_MinimumDepthBinTree;

[Category("Easy")]
[Category("P00111")]
public class Tests
{
    /*
        3
       /  \
      9    20
          /  \
         15   7

    Input: root = [3,9,20,null,null,15,7]
    Output: 2    
    */
    
    [Test]
    public void Partial3LevelTreeTest() 
    {
        TreeNode root = new TreeNode(3); 
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);

        int expected = 2;
        int result = new Solution().MinDepth(root); 
        Assert.That(result, Is.EqualTo(expected));
    }

    /*

    Example 2:
        2
         \
          3
           \ 
            4
             \
              5
               \
                6
    Input: root = [2,null,3,null,4,null,5,null,6]
    Output: 5

    */
    [Test]
    public void FiveLevelOneSidedTreeTest()
    {
        TreeNode root = new TreeNode(2);
        TreeNode current = root; 
        current.right = new TreeNode(3);
        current = current.right;
        current.right = new TreeNode(4);
        current = current.right;
        current.right = new TreeNode(5);
        current = current.right;
        current.right = new TreeNode(6);
        

        int expected = 5;
        int result = new Solution().MinDepth(root);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void OneNodeTreeTest()
    {
        TreeNode root = new TreeNode(2);
        
        int expected = 1;
        int result = new Solution().MinDepth(root);
        Assert.That(result, Is.EqualTo(expected));
    }

    /*


         3
       /   \
      9     20
     / \   /  \
    1   6 15   7

    Input: root = [3,9,20,1,6,15,7]
    Output: 2
    Example 2:

    */

    [Test]
    public void ThreeLevelFullTreeTest()
    {
        TreeNode root = new TreeNode(3);
        TreeNode current = root;
        current.left = new TreeNode(9);
        current.right = new TreeNode(20);
        current = current.left;
        current.left = new TreeNode(1);
        current.right = new TreeNode(6);

        current = root.right;
        current.left = new TreeNode(15);
        current.right = new TreeNode(7);


        int expected = 3;
        int result = new Solution().MinDepth(root);
        Assert.That(result, Is.EqualTo(expected));
    }

    /*

              3
         /         \
        9           20
       /  \       /    \
      1    6     15     7
     / \  / \    / \   / \
    13 14 21 23 31 32 43 45

    Input: root = [3,9,20,1,6,15,7]
    Output: 3
    Example 2:

    */
    [Test]
    public void FourLevelFullTreeTest()
    {
        TreeNode root = new TreeNode(3);
        TreeNode current = root;
        current.left = new TreeNode(9);
        current.right = new TreeNode(20);
        current = current.left;
        current.left = new TreeNode(1);
        current.right = new TreeNode(6);

        current = current.left;
        current.left = new TreeNode(13);
        current.right = new TreeNode(14);

        current = root.left.right;
        current.left = new TreeNode(21);
        current.right = new TreeNode(23);

        current = root.right;
        current.left = new TreeNode(15);
        current.right = new TreeNode(7);

        current = current.left;
        current.left = new TreeNode(31);
        current.right = new TreeNode(32);

        current = root.right.right;
        current.left = new TreeNode(43);
        current.right = new TreeNode(45);

        int expected = 4;
        int result = new Solution().MinDepth(root);
        Assert.That(result, Is.EqualTo(expected));
    }

}