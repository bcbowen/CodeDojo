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
	public int LongestZigZag(TreeNode root)
	{
		Stack<TreeNode> nodeStack = new Stack<TreeNode>();
		nodeStack.Push(root);
		while(nodeStack.Count > 0) 
		{}
	}

	internal int GetCount(TreeNode node) 
	{
		
	}
}

/*

Input: root = [1,null,1,1,1,null,null,1,1,null,1,null,null,null,1,null,1]
Output: 3
Explanation: Longest ZigZag path in blue nodes (right -> left -> right).


Input: root = [1,1,1,null,1,null,null,1,1,null,1]
Output: 4
Explanation: Longest ZigZag path in blue nodes (left -> right -> left -> right).

Input: root = [1]
Output: 0

*/

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
