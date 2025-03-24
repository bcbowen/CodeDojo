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
	private int _count = 0;
	public int CountUnivalSubtrees(TreeNode root)
	{
		IsUnival(root);

		return _count;
	}

	private bool IsUnival(TreeNode node) 
	{
		if(node == null) return false; 

		bool isLUnival = node.left == null || IsUnival(node.left) && node.left.val == node.val;
		bool isRunival = node.right == null || IsUnival(node.right) && node.right.val == node.val;

		if (isLUnival && isRunival) 
		{
			_count++;
			return true;
		}
		return false;
	}
}

public class Solution2
{
	// https://leetcode.com/problems/count-univalue-subtrees/discuss/2252460/Recursive-C
	int count;

	public int CountUnivalSubtrees(TreeNode root)
	{
		IsUnivalSubtree(root);
		return count;
	}

	public bool IsUnivalSubtree(TreeNode root)
	{
		if (root == null)
		{
			return false;
		}

		var isUnivalueL = (root.left == null || (IsUnivalSubtree(root.left) && root.left.val == root.val));
		var isUnivalueR = (root.right == null || (IsUnivalSubtree(root.right) && root.right.val == root.val));

		var isUnivalue = isUnivalueL && isUnivalueR;

		count += (isUnivalue ? 1 : 0);

		return isUnivalue;
	}
}

#region Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1() 
{
	TreeNode root = new TreeNode(5); 
	root.left = new TreeNode(1); 
	root.right = new TreeNode(5);
	
	root.left.left = new TreeNode(5); 
	root.left.right = new TreeNode(5); 
	
	root.right.right = new TreeNode(5); 
	
	int expected = 4; 
	int result = new Solution().CountUnivalSubtrees(root); 
	Assert.Equal(expected, result);
}

[Fact]
void Example2()
{
	TreeNode root = null;
	
	int expected = 0;
	int result = new Solution().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example3()
{
	TreeNode root = new TreeNode(5);
	root.left = new TreeNode(5);
	root.right = new TreeNode(5);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(5);

	root.right.right = new TreeNode(5);

	int expected = 6;
	int result = new Solution().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

// [1,1,1,5,5,null,5]
// 3

[Fact]
void Example4()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(1);
	root.right = new TreeNode(1);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(5);

	root.right.right = new TreeNode(5);

	int expected = 3;
	int result = new Solution().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example1b()
{
	TreeNode root = new TreeNode(5);
	root.left = new TreeNode(1);
	root.right = new TreeNode(5);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(5);

	root.right.right = new TreeNode(5);

	int expected = 4;
	int result = new Solution2().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example2b()
{
	TreeNode root = null;

	int expected = 0;
	int result = new Solution2().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

[Fact]
void Example3b()
{
	TreeNode root = new TreeNode(5);
	root.left = new TreeNode(5);
	root.right = new TreeNode(5);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(5);

	root.right.right = new TreeNode(5);

	int expected = 6;
	int result = new Solution2().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}

// [1,1,1,5,5,null,5]
// 3
/*    1
    /  \
   1    1
  / \    \
 5   5    5
*/
[Fact]
void Example4b()
{
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(1);
	root.right = new TreeNode(1);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(5);

	root.right.right = new TreeNode(5);

	int expected = 3;
	int result = new Solution2().CountUnivalSubtrees(root);
	Assert.Equal(expected, result);
}


#endregion