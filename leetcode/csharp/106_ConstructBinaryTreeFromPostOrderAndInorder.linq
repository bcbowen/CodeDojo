<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


//Definition for a binary tree node.
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
	private int[] _postorder;
	private int[] _inorder;
	private int _postIndex;
	Dictionary<int, int> _inorderIndexes;

	public TreeNode BuildTree(int[] inorder, int[] postorder)
	{
		_postorder = postorder;
		_inorder = inorder;

		_inorderIndexes = new Dictionary<int, int>();
		for (int i = 0; i < _inorder.Length; i++)
		{
			_inorderIndexes.Add(_inorder[i], i);
		}
		_postIndex = postorder.Length - 1;
		return BuildSubTree(0, _inorder.Length - 1);
	}

	internal TreeNode BuildSubTree(int leftIndex, int rightIndex)
	{
		if (leftIndex > rightIndex) return null;
		int rootVal = _postorder[_postIndex];
		TreeNode root = new TreeNode(rootVal);

		int index = _inorderIndexes[rootVal];
		_postIndex--;
		root.right = BuildSubTree(index + 1, rightIndex);
		root.left = BuildSubTree(leftIndex, index - 1);
		return root;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1()
{
	/*
	Input: inorder = [9, 3, 15, 20, 7], postorder = [9, 15, 7, 20, 3]
	Output: [3,9,20,null,null,15,7]	
	*/
	int[] inorder = { 9, 3, 15, 20, 7 };
	int[] postorder = { 9, 15, 7, 20, 3 };
	TreeNode root = new Solution().BuildTree(inorder, postorder);

	Assert.Equal(3, root.val);
	Assert.Equal(9, root.left.val);
	Assert.Equal(20, root.right.val);
	Assert.Equal(15, root.right.left.val);
	Assert.Equal(7, root.right.right.val);
}

[Fact]
void Example2()
{
	/*
	Input: inorder = [-1], postorder = [-1]
	Output: [-1]
	*/
	int[] inorder = new int[] { -1 };
	int[] postorder = new int[] { -1 };
	TreeNode root = new Solution().BuildTree(inorder, postorder);
	Assert.Equal(-1, root.val);
	Assert.Null(root.left);
	Assert.Null(root.right);
}


[Fact]
void Example3()
{
	int[] inorder = { 4, 2, 5, 1, 3 };
	int[] postorder = { 4, 5, 2, 3, 1 };
	TreeNode root = new Solution().BuildTree(inorder, postorder);

	Assert.Equal(1, root.val);
	Assert.Equal(2, root.left.val);
	Assert.Equal(3, root.right.val);
	Assert.Equal(4, root.left.left.val);
	Assert.Equal(5, root.left.right.val);
}


[Fact]
void Example4()
{

	int[] inorder = { 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90 };
	int[] postorder = { 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25 };
	TreeNode root = new Solution().BuildTree(inorder, postorder);

	Assert.Equal(25, root.val);
	Assert.Equal(15, root.left.val);
	Assert.Equal(50, root.right.val);
	Assert.Equal(35, root.right.left.val);
	Assert.Equal(18, root.left.right.left.val);
}

#endregion