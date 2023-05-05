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
	public bool IsValidBST(TreeNode root)
	{
		if (root.left == null && root.right == null) return true;
		
		return CheckTree(root, null, null); 
	}

	internal bool CheckTree(TreeNode root, int? min, int? max)
	{
		bool isValid = true;

		if (root.left != null)
		{
			//max = root.val - 1;
			if (root.left.val >= root.val || (min.HasValue && root.left.val <= min))
			{
				isValid = false;
			}
			else
			{
				
				isValid = CheckTree(root.left, min, root.val);
			}
		}

		if (isValid && root.right != null)
		{
			if (root.right.val <= root.val || (max.HasValue && root.right.val >= max))
			{
				isValid = false;
			}
			else
			{
				isValid = CheckTree(root.right, root.val, max);
			}
		}

		return isValid;
	}
}

/*
			2
		   / \
		  1   3
*/
[Fact]
void LeafIsValidTree() 
{
	TreeNode leaf = new TreeNode(2); 
	Assert.True(new Solution().IsValidBST(leaf));
}

[Theory]
[InlineData(2, 2, 2, false)]
[InlineData(2, 1, 3, true)]
[InlineData(2, null, 3, true)]
[InlineData(2, 1, null, true)]
[InlineData(2, 3, 1, false)]
[InlineData(2, null, 1, false)]
[InlineData(2, 3, null, false)]
void Test_OneLevelTree(int root, int? l, int? r, bool expected) 
{
	TreeNode node = new TreeNode(root);
	if (l.HasValue) node.left = new TreeNode(l.Value); 
	if (r.HasValue) node.right = new TreeNode(r.Value); 
	bool result = new Solution().IsValidBST(node); 
	Assert.Equal(expected, result);
}

/**/
[Theory]
[InlineData(4, 2, 6, 1, 3, 5, 7, true)]
[InlineData(4, 2, 6, 1, 3, 5, null, true)]
[InlineData(4, 2, 6, 1, 3, null, 7, true)]
[InlineData(4, 2, 6, 1, 3, 5, 7, true)]
[InlineData(4, 2, 6, null, 3, 5, 7, true)]
[InlineData(4, 2, 6, 1, 3, null, null, true)]
[InlineData(4, 2, 6, null, null, 5, 7, true)]
[InlineData(4, 2, 6, 1, 3, 5, 4, false)]
[InlineData(4, 2, 6, 1, 3, 8, 7, false)]
[InlineData(4, 2, 6, 1, 1, 5, 7, false)]
[InlineData(4, 2, 6, 3, 3, 5, 7, false)]
[InlineData(4, 5, 6, 1, 3, 5, 7, false)]
[InlineData(4, 2, 3, 1, 3, 5, 7, false)]
[InlineData(5, 4, 6, null, null, 3, 7, false)]
[InlineData(-2147483648, null, 2147483647, null, null, -2147483648, null, false)]
//// [-2147483648,null,2147483647,-2147483648]

void TwoLevelTests(int root, int? l1_1, int? l1_2, int? l2_1, int? l2_2, int? l2_3, int? l2_4, bool expected) 
{
	TreeNode node = new TreeNode(root); 
	if (l1_1.HasValue) node.left = new TreeNode(l1_1.Value); 
	if (l1_2.HasValue) node.right = new TreeNode(l1_2.Value);
	TreeNode current = node;
	
	if (node.left != null) 
	{
		current = node.left;
		if (l2_1.HasValue) current.left = new TreeNode(l2_1.Value); 
		if (l2_2.HasValue) current.right = new TreeNode(l2_2.Value);
	}
	
	if (node.right != null)
	{
		current = node.right; 
		if (l2_3.HasValue) current.left = new TreeNode(l2_3.Value); 
		if (l2_4.HasValue) current.right = new TreeNode(l2_4.Value); 
	}
	
	bool result = new Solution().IsValidBST(node);
	Assert.Equal(expected, result);
}

[Fact]
void Troubleshooting() 
{
	/*
	                                 120
								  /      \	
							    /          \
							  70            140
							 /   \        /     \
						   50    100     130    160
						  /  \   / \    / \     /  \
						 20  55 75 110 119 135 150 200 
						               ===
	
	
	
	[120,70,140,50,100,130,160,20,55,75,110,119,135,150,200]
	false
	*/	
	// L1
	TreeNode root = new TreeNode(120); 
	root.left = new TreeNode(70); 
	root.right = new TreeNode(140); 
	
	// L2
	TreeNode current = root.left; 
	current.left = new TreeNode(50); 
	current.right	 = new TreeNode(100);
	
	current = root.right; 
	current.left = new TreeNode(130); 
	current.right = new TreeNode(160); 
	
	// L3
	current = root.left.left; 
	current.left = new TreeNode(20);
	current.right = new TreeNode(55);

	current = root.left.right;
	current.left = new TreeNode(75);
	current.right = new TreeNode(110);

	current = root.right.left;
	current.left = new TreeNode(119); // problem!
	current.right = new TreeNode(135);

	current = root.right.right;
	current.left = new TreeNode(150);
	current.right = new TreeNode(200);

	bool result = new Solution().IsValidBST(root);
	bool expected = false;
	Assert.Equal(expected, result);
}

[Fact]
void Troubleshooting2()
{
	/*
	                                3
								  /    \	
							    /       \
							  1          5
							 / \         / \
						   0    2       4   6  
						         \     /  \
						          3  
						          --     
	
	
	
	[3,1,5,0,2,4,6,null,null,null,3]
	false
	*/
	// L1
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(1);
	root.right = new TreeNode(5);

	// L2
	TreeNode current = root.left;
	current.left = new TreeNode(0);
	current.right = new TreeNode(2);

	current = root.right;
	current.left = new TreeNode(4);
	current.right = new TreeNode(6);

	// L3
	current = root.left.right;
	current.right = new TreeNode(3); // problem!

	bool result = new Solution().IsValidBST(root);
	bool expected = false;
	Assert.Equal(expected, result);
}

[Fact]
void Troubleshooting3()
{
	/*
	                                4
								  /   \	
							     2     6
							          / \
						             5   7  
						             						            
						          -- 
	[4, 2, 6, -1, -1, 5, 7]
	true
	*/
	// L1
	TreeNode root = new TreeNode(4);
	root.left = new TreeNode(2);
	root.right = new TreeNode(6);

	// L2
	TreeNode current = root.right;
	current.left = new TreeNode(5);
	current.right = new TreeNode(7);

	bool result = new Solution().IsValidBST(root);
	bool expected = true;
	Assert.Equal(expected, result);
}



/*

[InlineData(4, 2, 6, -1, -1, 5, 7, true)]
true

[3,1,5,0,2,4,6,null,null,null,3]
false

Input: root = [2,1,3]
Output: true

Input: root = [5,1,4,null,null,3,6]
Output: false
Explanation: The root node's value is 5 but its right child's value is 4.
*/
