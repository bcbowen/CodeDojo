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
	public IList<int> PreorderTraversal(TreeNode root)
	{
		List<int> values = new List<int>(); 
		if (root == null) return values;
		values.Add(root.val);
		values.AddRange(PreorderTraversal(root.left));
		values.AddRange(PreorderTraversal(root.right));
		return values;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion