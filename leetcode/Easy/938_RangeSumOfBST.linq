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

public int RangeSumBST(TreeNode root, int low, int high)
{
	List<int> values = new List<int>(); 
	GetInOrderValues(root, values); 
	int sum = 0;
	bool started = false;
	foreach(int value in values)
	{
		if (!started)
		{
			if (value >= low)
			{
				started = true;
				sum += value;
			}
		}
		else
		{
			if (value <= high)
			{
				sum += value; 	
			}

			if (value >= high) break; 
		}
	}
	
	return sum; 
}

private void GetInOrderValues(TreeNode root, List<int> values)
{
	if (root.left != null) 
	{
		GetInOrderValues(root.left, values); 
	}
	values.Add(root.val);
	if (root.right != null) 
	{
		GetInOrderValues(root.right, values); 
	}
}

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


/*

Input: root = [10,5,15,3,7,null,18], low = 7, high = 15
Output: 32
Explanation: Nodes 7, 10, and 15 are in the range [7, 15]. 7 + 10 + 15 = 32.

Input: root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
Output: 23
Explanation: Nodes 6, 7, and 10 are in the range [6, 10]. 6 + 7 + 10 = 23.

*/

[Theory]
[InlineData(new[] {10,5,15,3,7,18}, 7, 15, 32)]
[InlineData(new[] {10,5,15,3,7,13,18,1,6}, 6, 10, 23)]
void Test(int[] values, int low, int high, int expected)
{ 
	TreeNode root = Init(values); 
	int result = RangeSumBST(root, low, high);  
	Assert.Equal(expected, result); 
}

