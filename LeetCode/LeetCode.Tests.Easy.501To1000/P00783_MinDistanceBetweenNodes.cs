using LeetCode.Solutions.Easy.P00783_MinDistanceBetweenNodes;
using LeetCode.Models.Tree.BinaryTree;
using static LeetCode.Models.Tree.BinaryTree.TreeNodeExtensions;
namespace LeetCode.Tests.Easy.P00783_MinDistanceBetweenNodes;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase(new[] { 4, 2, 6, 1, 3}, 1)]
    [TestCase(new[] { 1, 0, 48, 12, 49 }, 1)]
    public void P00783_Test(int[] values, int expected) 
    {
        TreeNode root = null;
        foreach (int value in values)
        {
            root = root.AddNode(value);    
        }
        int result = new Solution().MinDiffInBST(root);
        Assert.That(result, Is.EqualTo(expected));

    }

    [TestCase(new[] { 4, 2, 6, 1, 3 }, new[] { 1, 2, 3, 4, 6} )]
    [TestCase(new[] { 1, 0, 48, 12, 49 }, new[] { 0, 1, 12, 48, 49 })]
    public void P00783_Test(int[] values, int[] expected)
    {
        TreeNode root = null;
        foreach (int value in values)
        {
            root = root.AddNode(value);
        }
        List<int> result = new List<int>();
        new Solution().GetInorderValues(root, result);
        Assert.That(result, Is.EqualTo(expected.ToList()));
    }




}