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

public int MaxAncestorDiff(TreeNode root)
{
	int range = GetRange(root, root.val, root.val); 
	return range;
}

internal int GetRange(TreeNode root, int min, int max) 
{
	int largestRange = Math.Abs(max - min); 
	min = Math.Min(min, root.val); 
	max = Math.Max(max, root.val); 
	int range = Math.Max(largestRange, max - min); 
	if (root.left != null) range = GetRange(root.left, min, max); 
	largestRange = Math.Max(range, largestRange); 
	if (root.right != null) range = GetRange(root.right, min, max); 
	return Math.Max(range, largestRange); 	
}

[Fact]
void Test1() 
{
	TreeNode root = new TreeNode(8); 
	root.left = new TreeNode(3); 
	root.right = new TreeNode(10); 
	
	// left side
	TreeNode current = root.left; 
	current.left = new TreeNode(1); 
	current.right = new TreeNode(6); 
	
	current = current.right; 
	current.left = new TreeNode(4); 
	current.right = new TreeNode(7); 
	
	// right side
	current = root.right; 
	current.right = new TreeNode(14); 
	current = current.right; 
	current.left = new TreeNode(13); 
	
	int result = MaxAncestorDiff(root); 
	int expected = 7; 
	Assert.Equal(expected, result); 
}

[Fact]
void Test2() 
{
	TreeNode root = new TreeNode(1); 
	root.right = new TreeNode(2); 
	root.right.right = new TreeNode(0); 
	root.right.right.left = new TreeNode(3);

	int result = MaxAncestorDiff(root);
	int expected = 3;
	Assert.Equal(expected, result);
}
