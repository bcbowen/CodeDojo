<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}

public class Solution
{
	public bool HasPathSum(TreeNode root, int targetSum)
	{
		if (root == null) return false;

		return PathSum(root, targetSum, 0);
	}

	private bool IsLeaf(TreeNode node)
	{
		return node != null && node.left == null && node.right == null;
	}

	private bool PathSum(TreeNode node, int targetSum, int currentSum)
	{
		if (node == null) return false;

		currentSum += node.val;

		if (IsLeaf(node) && currentSum == targetSum) 
		{
			return true;
		}
		
		if (IsLeaf(node.left) && currentSum + node.left.val == targetSum)
		{
			return true;
		}

		if (IsLeaf(node.right) && currentSum + node.right.val == targetSum)
		{
			return true;
		}

		return PathSum(node.left, targetSum, currentSum) || PathSum(node.right, targetSum, currentSum);
	}
}

#region private::Tests

/*
[1,2]
1
*/
[Fact]
void Example1() 
{
	TreeNode root = new TreeNode(5); 
	root.left = new TreeNode(4); 
	root.right = new TreeNode(8); 
	root.left.left = new TreeNode(11); 
	root.left.left.left = new TreeNode(7); 
	root.left.left.right = new TreeNode(2); 
	root.right.left = new TreeNode(13); 
	root.right.right = new TreeNode(4); 
	root.right.right.right = new TreeNode(1); 
	
	int target = 22;
	bool expected = true; 
	bool result = new Solution().HasPathSum(root, target); 
	Assert.Equal(expected, result);
}

[Fact]
void Example2()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	int target = 5;
	bool expected = false;
	bool result = new Solution().HasPathSum(root, target);
	Assert.Equal(expected, result);
}

[Fact]
void Example3()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);

	int target = 1;
	bool expected = false;
	bool result = new Solution().HasPathSum(root, target);
	Assert.Equal(expected, result);
}

[Fact]
void Example4()
{
	TreeNode root = new TreeNode(1);

	int target = 1;
	bool expected = true;
	bool result = new Solution().HasPathSum(root, target);
	Assert.Equal(expected, result);
}

#endregion