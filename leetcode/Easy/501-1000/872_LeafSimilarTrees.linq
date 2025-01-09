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
/*
internal TreeNode Init(int[] values)
{
	if (values.Length == 0) return null;

	TreeNode root = new TreeNode(values[0]);
	for (int i = 1; i < values.Length; i++)
	{
		Add(root, values[i]);
	}

	return root;
}

internal void Add(TreeNode root, int value)
{
	TreeNode current = root;
	if (value < root.val)
	{
		if (root.left == null)
		{
			root.left = new TreeNode(value);
		}
		else
		{
			Add(root.left, value);
		}
	}
	else
	{
		if (root.right == null)
		{
			root.right = new TreeNode(value);
		}
		else
		{
			Add(root.right, value);
		}
	}
}
*/

public TreeNode Init(int?[] values)
{
	if (values == null || !values[0].HasValue) return null;

	TreeNode root = new TreeNode(values[0].Value);
	Queue<TreeNode> q = new Queue<TreeNode>();
	q.Enqueue(root);
	int i = 1;
	while (i < values.Length && q.Count > 0)
	{
		TreeNode node = q.Dequeue();
		int? value = values[i++];
		if (value.HasValue)
		{
			node.left = new TreeNode(value.Value);
			q.Enqueue(node.left);
		}
		value = values[i++];
		if (value.HasValue)
		{
			node.right = new TreeNode(value.Value);
			q.Enqueue(node.right);
		}
	}
	return root;
}

public bool LeafSimilar(TreeNode root1, TreeNode root2)
{
	List<int> tree1Leaves = new List<int>(); 
	GetLeaves(root1, tree1Leaves);

	List<int> tree2Leaves = new List<int>();
	GetLeaves(root2, tree2Leaves);
	
	if (tree1Leaves.Count != tree2Leaves.Count) return false;

	for(int i = 0; i < tree1Leaves.Count; i++) 
	{
		if (tree1Leaves[i] != tree2Leaves[i]) return false; 
	}
	
	return true;
}

internal void GetLeaves(TreeNode root, List<int> leaves) 
{
	if (root.left == null && root.right == null) 
	{
		leaves.Add(root.val); 
		return;
	}
	
	if (root.left != null) 
	{
		GetLeaves(root.left, leaves);
	}
	if (root.right != null)
	{
		GetLeaves(root.right, leaves); 
	}
}
/*
Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]
Output: true

Input: root1 = [1,2,3], root2 = [1,3,2]
Output: false

*/

[Fact]
void Test1()
{
	int?[] values1 = new int?[] { 3, 5, 1, 6, 2, 9, 8, null, null, 7, 4 };
	int?[] values2 = new int?[] { 3, 5, 1, 6, 7, 4, 2, null, null, null, null, null, null, 9, 8 };
	bool expected = true;
	TreeNode root1 = Init(values1);
	TreeNode root2 = Init(values2);

	bool result = LeafSimilar(root1, root2);
	Assert.Equal(expected, result);
}

[Fact]
void Test2()
{
	int?[] values1 = new int?[] { 1, 2, 3 };
	int?[] values2 = new int?[] { 1, 3, 2 };
	bool expected = false;
	TreeNode root1 = Init(values1);
	TreeNode root2 = Init(values2);

	bool result = LeafSimilar(root1, root2);
	Assert.Equal(expected, result);
}
