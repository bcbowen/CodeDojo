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
	public TreeNode SearchBST(TreeNode root, int val)
	{
		if (root == null) return root;
		TreeNode node = null;
		if (root.val == val)
		{
			node = root;
		}
		else if (val < root.val)
		{
			node = SearchBST(root.left, val);
			/*
			node = SearchBST(root.left, val);
			if (node != null && node.val != val)
			{
				node = SearchBST(root.right, val);
			}
			*/
		}
		else 
		{
			node = SearchBST(root.right, val);
		}
		return node;
	}
}

#region private::Tests

public TreeNode Add(TreeNode root, int val)
{
	if (root == null)
	{
		root = new TreeNode(val);
	}
	else if (val < root.val)
	{
		if (root.left == null)
		{
			root.left = new TreeNode(val);
		}
		else
		{
			Add(root.left, val);
		}
	}
	else
	{
		if (root.right == null)
		{
			root.right = new TreeNode(val);
		}
		else
		{
			Add(root.right, val);
		}
	}
	return root;
}

[Fact]
void Test1()
{
	int[] values = { 4, 2, 7, 1, 3 };
	int val = 2;
	TreeNode node = null;
	foreach (int value in values)
	{
		node = Add(node, value);
	}

	TreeNode result = new Solution().SearchBST(node, val);

	Assert.Equal(2, result.val);
	Assert.Equal(1, result.left.val);
	Assert.Equal(3, result.right.val);
}

[Fact]
void Test2()
{
	int[] values = { 4, 2, 7, 1, 3 };
	int val = 5;
	TreeNode node = null;
	foreach (int value in values)
	{
		node = Add(node, value);
	}

	TreeNode result = new Solution().SearchBST(node, val);

	Assert.Null(result);
}

[Fact]
void Test3()
{
	int[] values = { 18, 2, 22, 63, 84 };
	int val = 63;
	TreeNode node = null;
	foreach (int value in values)
	{
		node = Add(node, value);
	}

	TreeNode result = new Solution().SearchBST(node, val);

	Assert.Equal(63, result.val);
	Assert.Null(result.left.val);
	Assert.Equal(84, result.right.val);
}

/*

Input: root = [4,2,7,1,3], val = 2
Output: [2,1,3]

Input: root = [4,2,7,1,3], val = 5
Output: []

[18,2,22,null,null,null,63,null,84,null,null]
[63,null,84]

*/
#endregion