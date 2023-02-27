<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

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
	public int MaxDepth(TreeNode root)
	{
		if (root == null) return 0;
		
		int left = MaxDepth(root.left);
		int right = MaxDepth(root.right);
		
		return Math.Max(left, right) + 1;
	}

}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1Test() 
{
	/*
		Input: root = [3,9,20,null,null,15,7]
		Output: 3
	*/
	
	TreeNode root = new TreeNode(3); 
	root.left = new TreeNode(9); 
	root.right = new TreeNode(20); 
	TreeNode current = root.right;
	current.left = new TreeNode(15); 
	current.right = new TreeNode(7);
	
	int expectedMaxDepth = 3;
	int maxDepth = new Solution().MaxDepth(root);
	Assert.Equal(expectedMaxDepth, maxDepth);
}

[Fact]
void Example2Test()
{
	/*
		Input: root = [1,null,2]
		Output: 2
	*/

	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);

	int expectedMaxDepth = 2;
	int maxDepth = new Solution().MaxDepth(root);
	Assert.Equal(expectedMaxDepth, maxDepth);
}

#endregion