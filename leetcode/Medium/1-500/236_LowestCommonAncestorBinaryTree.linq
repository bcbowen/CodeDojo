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
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	
	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		(int count, TreeNode node) = FindAncestor(root, p.val, q.val);
		return node;
	}


	internal (int, TreeNode) FindAncestor(TreeNode root, int p, int q) 
	{
		if (root == null) return (0, null);
	
		int matchCount = 0; 
		int count;
		TreeNode ancestor = null; 
		(count, ancestor) = FindAncestor(root.left, p, q); 
		if (ancestor != null) return(count, ancestor);
		matchCount += count; 
		
		(count, ancestor) = FindAncestor(root.right, p, q); 
		if (ancestor != null) return(count, ancestor);	
		matchCount += count;

		if (root.val == p || root.val == q) matchCount++;
		
		return (matchCount, matchCount >= 2 ? root : null);
	
	}
	
	
}

#region Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1() 
{
	/*
	Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
	Output: 3
	Explanation: The LCA of nodes 5 and 1 is 3.
	*/
	TreeNode root = new TreeNode(3); 
	root.left = new TreeNode(5); 
	root.left.left = new TreeNode(6); 
	root.left.right = new TreeNode(2); 
	root.left.right.left = new TreeNode(7); 
	root.left.right.left = new TreeNode(4); 
	
	root.right = new TreeNode(1); 
	root.right.left = new TreeNode(0); 
	root.right.right = new TreeNode(8); 
	
	TreeNode result = new Solution().LowestCommonAncestor(root, root.left, root.right);
	Assert.Equal(root.val, result.val);
}

[Fact]
void Example2()
{
	/*
	Input: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
Output: 5
Explanation: The LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
	*/
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(5);
	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(2);
	root.left.right.left = new TreeNode(7);
	root.left.right.left = new TreeNode(4);

	root.right = new TreeNode(1);
	root.right.left = new TreeNode(0);
	root.right.right = new TreeNode(8);

	TreeNode result = new Solution().LowestCommonAncestor(root, root.left, root.left.right.left);
	Assert.Equal(root.left.val, result.val);
}

[Fact]
void Example3()
{
	/*
	Input: root = [1,2], p = 1, q = 2
	Output: 1.
	*/
	TreeNode node = new TreeNode(1); 
	node.left = new TreeNode(2); 
	
	TreeNode result = new Solution().LowestCommonAncestor(node, node, node.left); 
	Assert.Equal(node.val, result.val);
}

#endregion