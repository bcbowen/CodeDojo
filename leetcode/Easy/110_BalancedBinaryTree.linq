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
	public bool IsBalanced(TreeNode root)
	{
		if (root == null || IsLeaf(root)) return true;
	
		(int leftDepth, int rightDepth, bool IsUnbalanced) = TraverseTree(root, 0); 
		return !IsUnbalanced;
	}

	private (int, int, bool) TraverseTree(TreeNode node, int depth)
	{		
		int leftDepth = depth;
		int rightDepth = depth;
		bool isUnbalanced = false;
		
		if (node.left != null) 
		{
			(int l, int r, bool u) = TraverseTree(node.left, depth + 1);
			if (u || Math.Abs(l - r) > 1) isUnbalanced = true;
			leftDepth = Math.Max(l, r);
		}

		if (node.right != null)
		{
			(int l, int r, bool u) = TraverseTree(node.right, depth + 1);
			if (u || Math.Abs(l - r) > 1) isUnbalanced = true;
			rightDepth = Math.Max(l, r);
		}

		if (Math.Abs(leftDepth - rightDepth) > 1) isUnbalanced = true;
		return (leftDepth, rightDepth, isUnbalanced);

	}

	private bool IsLeaf(TreeNode node)
	{
		return node.left == null && node.right == null;
	}

}

#region private::Tests

[Fact]
void Example1()
{
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);

	root.right.left = new TreeNode(15);
	root.right.right = new TreeNode(7);

	bool expected = true;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example2()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2); 
	root.right = new TreeNode(2); 
	
	root.left.left = new TreeNode(3); 
	root.left.right = new TreeNode(3);
	
	root.left.left.left = new TreeNode(4); 
	root.left.left.right = new TreeNode(4);
	
	bool expected = false;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example3()
{
	TreeNode root = null;
	
	bool expected = true;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}

/*
[1,null,2,null,3]
Output
true
Expected
false
*/

[Fact]
void Example4()
{
	TreeNode root = new TreeNode(1);
	root.right = new TreeNode(2);
	root.right.right = new TreeNode(3);

	bool expected = false;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}

/*
Input
[1,2,2,3,null,null,3,4,null,null,4]
Output
true
Expected
false
*/

[Fact]
void Example5()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(2);
	
	root.left.left = new TreeNode(3);
	root.right.right = new TreeNode(3);

	root.left.left.left = new TreeNode(4);
	root.right.right.right = new TreeNode(4);

	bool expected = false;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}

/*
Input
[1,2,3,4,5,6,null,8]
Output
false
Expected
true

        1
     /    \
    2      3
   / \    /  
  4   5  6   
 /
8


*/

[Fact]
void Example6()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);

	root.right.left = new TreeNode(6);
	
	root.left.left.left = new TreeNode(8);

	bool expected = true;
	bool result = new Solution().IsBalanced(root);
	Assert.Equal(expected, result);
}


#endregion