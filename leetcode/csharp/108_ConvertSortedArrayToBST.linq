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
	public TreeNode SortedArrayToBST(int[] nums)
	{
		TreeNode node = null; 
		if (nums == null || nums.Length == 0) return node;
		
		if (nums.Length == 1) return new TreeNode(nums[0]);
		
		int mid = nums.Length / 2;
		node = new TreeNode(nums[mid]);
		for (int i = mid - 1; i >= 0; i--) 
		{
			node.AddNode(nums[i]);
		}
		for (int i = mid + 1; i <= nums.Length; i++)
		{
			node.AddNode(nums[i]);
		}

		return node;
	}
}

public static class TreeNodeExtensions
{
	public static void AddNode(this TreeNode root, int value)
	{
		if (root == null) 
		{
			root = new TreeNode(value);
			return;
		};

		if (value < root.val)
		{
			if (root.left == null) 
			{
				root.left = new TreeNode(value);
			}
			else 
			{
				root.left.AddNode(value);
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
				root.right.AddNode(value);
			}
		}
	}
	
	public static string GetNodeList(this TreeNode node)
	{
		StringBuilder result = new StringBuilder();
		result.Append("[");
		
		result.Append("]");
		return result.ToString();
	}
}

#region Tests

[Fact]
void Test_Xunit() 
{
	var nums = new[] { -10, -3, 0, 5, 9};
	TreeNode result = new Solution().SortedArrayToBST(nums); 
	result.Dump(); 
	
}



#endregion