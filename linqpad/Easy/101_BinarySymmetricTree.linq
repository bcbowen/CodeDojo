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
	public bool IsSymmetric(TreeNode root)
	{
		if (root == null) return false;
		
		return IsSymmetric(root.left, root.right);
	}

	private bool IsSymmetric(TreeNode left, TreeNode right) 
	{
		if (left == null && right == null) return true;
		if (left == null || right == null) return false;
		if (left.val != right.val) return false; 
		if (!IsSymmetric(left.left, right.right)) return false;
		if (!IsSymmetric(left.right, right.left)) return false;
		return true;
		
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion