<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

/** * Definition for a binary tree node.*/
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
	public TreeNode BalanceBST(TreeNode root)
	{
		int[] values = Traverse(root).ToArray();
		return Balance(values); 
	}

	internal static TreeNode Balance(int[] values) 
	{
		TreeNode node = null; 
		if (values == null || values.Length == 0) return node;

		if (values.Length == 1) 
		{
			node = new TreeNode(values[0]);
		}
		else if (values.Length == 2) 
		{
			node = new TreeNode(values[0]); 
			node.right = new TreeNode(values[1]);
		}
		else if (values.Length == 3) 
		{
			node = new TreeNode(values[1]); 
			node.left = new TreeNode(values[0]); 
			node.right = new TreeNode(values[2]);
		}
		else 
		{
			int mid = values.Length / 2; 
			node = new TreeNode(values[mid]);
			node.left = Balance(values.Take(mid).ToArray());
			node.right = Balance(values.Skip(mid).ToArray()); 
		}
		return node;
	}

	internal static List<int> Traverse(TreeNode node) 
	{
		List<int> result = new List<int>();
		if (node.left != null) 
		{
			result.AddRange(Traverse(node.left));
		}
		result.Add(node.val);
		if (node.right != null) 
		{
			result.AddRange(Traverse(node.right)); 
		}
		return result;
	}

	internal static bool IsBalanced(TreeNode root) 
	{
		List<int> depths = GetEndDepths(root, 1); 
		int minDepth = depths.Min(d => d); 
		int maxDepth = depths.Max(d => d); 
		return maxDepth - minDepth <= 1; 

	}
	
	internal static List<int> GetEndDepths(TreeNode node, int depth) 
	{
		List<int> result = new List<int>();
		if (node == null) return result;
		if (node.left == null && node.right == null) 
		{
			result.Add(depth); 
			return result;
		}
		if (node.left == null || node.right == null) 
		{
			result.Add(depth);
		}
		if (node.left != null) 
		{
			result.AddRange(GetEndDepths(node.left, depth + 1));
		}
		
		if (node.right != null) 
		{
			result.AddRange(GetEndDepths(node.right, depth + 1)); 
		}
		
		return result;
	}

	internal static TreeNode Hydrate(IList<int> values) 
	{
		TreeNode root = null;
		if (values.Count > 0)
		{
			foreach (int i in values) 
			{
				root = Add(root, i); 
			}
		}
		return root;
	}

	internal static TreeNode Add(TreeNode node, int val)
	{
		TreeNode root = node; 
		if (root == null) 
		{
			root = new TreeNode(val);
		}
		else if (val <= root.val)
		{
			if (root.left == null) 
			{
				root.left = new TreeNode(val);
			}
			else 
			{
				root.left = Add(root.left, val); 
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
				root.right = Add(root.right, val); 
			}
		}
		return root; 
	}
	
}

[Fact]
void HydrateNoLefts() 
{
	int[] values = new[] {1, 2, 3, 4};
	TreeNode root = Solution.Hydrate(values); 
	Assert.Equal(1, root.val); 
	Assert.Null(root.left); 
	Assert.Equal(2, root.right.val); 
	Assert.Null(root.right.left); 
	TreeNode node = root.right.right; 
	Assert.Equal(3, node.val); 
	Assert.Null(node.left); 
	Assert.Equal(4, node.right.val); 
	Assert.Null(node.right.left);
	Assert.Null(node.right.right); 
}

[Theory]
[InlineData(new[] {1, 2, 3, 4}, false)]
[InlineData(new[] {2, 1, 3, 4}, true)]
[InlineData(new[] {3, 1, 4, 2}, true)]
void BalanceTest(int[] values, bool expected) 
{
	TreeNode node = Solution.Hydrate(values); 
	bool result = Solution.IsBalanced(node); 
	Assert.Equal(expected, result); 
}

[Theory]
[InlineData(new[] { 1, 2, 3, 4 })]
[InlineData(new[] { 2, 1, 3, 4 })]
[InlineData(new[] { 3, 1, 4, 2 })]
void TraverseRoundTripTest(int[] values)
{
	int[] expected = new[] {1, 2, 3, 4}; 
	TreeNode node = Solution.Hydrate(values);
	int[] result = Solution.Traverse(node).ToArray();
	Assert.Equal(expected, result);
}

[Fact]
void SimpleBalanceTest() 
{
	int[] values = new[] {1, 2, 3};
	TreeNode node = Solution.Balance(values); 
	Assert.Equal(2, node.val);
	Assert.Equal(1, node.left.val);
	Assert.Equal(3, node.right.val); 
}

[Fact]
void FiveBalanceTest() 
{
	int[] values = new[] {1, 2, 3, 4, 5};
	TreeNode node = Solution.Balance(values); 
	Assert.Equal(3, node.val); 
}


/*
Input: root = [1,null,2,null,3,null,4,null,null]
Output: [2,1,3,null,null,null,4]

Input: root = [2,1,3]
Output: [2,1,3]
*/

[Theory]
[InlineData(new int[] {1,2,3,4})]
[InlineData(new int[] {2, 1, 3})]
void MainTest(int[] values) 
{
	TreeNode node = Solution.Hydrate(values); 
	TreeNode result = new Solution().BalanceBST(node); 
	Assert.True(Solution.IsBalanced(result)); 
}
