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
	public int SumOfLeftLeaves(TreeNode root)
	{
		if (root == null) return 0;

		int sum = 0;
		if (root.left != null && root.left.left == null && root.left.right == null) 
		{
			sum += root.left.val;
		}
		sum += SumOfLeftLeaves(root.left); 
		sum += SumOfLeftLeaves(root.right);
		
		return sum;
	}

}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1Test() 
{
	/*
		Input: root = [3,9,20,null,null,15,7]
		Output: 24
		Explanation: There are two left leaves in the binary tree, with values 9 and 15 respectively.
	*/
	
	TreeNode root = new TreeNode(3); 
	root.left = new TreeNode(9); 
	root.right = new TreeNode(20); 
	TreeNode current = root.right;
	current.left = new TreeNode(15); 
	current.right = new TreeNode(7);
	
	int expected = 24;
	int result = new Solution().SumOfLeftLeaves(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example2Test()
{
	/*
		Input: root = [1]
		Output: 0
	*/

	TreeNode root = new TreeNode(1);

	int expected = 0;
	int result = new Solution().SumOfLeftLeaves(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example3Test()
{
	/*
		Input [1,2,3,4,5]
		Output 6
		Expected 4
	*/

	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);
	TreeNode current = root.left;
	current.left = new TreeNode(4);
	current.right = new TreeNode(5);

	int expected = 4;
	int result = new Solution().SumOfLeftLeaves(root);
	Assert.Equal(expected, result);
}



#endregion