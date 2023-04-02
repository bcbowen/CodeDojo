<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public int MinDiffInBST(TreeNode root)
	{
		List<int> inorderValues = new List<int>();
		GetInorderValues(root, inorderValues);
		int min = inorderValues[1] - inorderValues[0];
		for (int i = 2; i < inorderValues.Count; i++)
		{
			min = Math.Min(min, inorderValues[i] - inorderValues[i - 1]);
		}
		return min;
	}

	internal void GetInorderValues(TreeNode root, List<int> values)
	{
		if (root == null) return;
		if (root.left != null)
		{
			GetInorderValues(root.left, values);
		}
		values.Add(root.val);
		if (root.right != null)
		{
			GetInorderValues(root.right, values);
		}
	}
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

public static class TreeNodeExtensions
{
	public static TreeNode AddNode(this TreeNode root, int value)
	{
		if (root == null)
		{
			root = new TreeNode(value);
		}
		else
		{
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

		return root;
	}

	public static string GetNodeList(this TreeNode node)
	{
		StringBuilder result = new StringBuilder();
		result.Append("[");
		// TODO: finish
		result.Append("]");
		return result.ToString();
	}
}

[Theory]
[InlineData(new[] { 4, 2, 6, 1, 3 }, 1)]
[InlineData(new[] { 1, 0, 48, 12, 49 }, 1)]
public void P00783_Test(int[] values, int expected)
{
	TreeNode root = null;
	foreach (int value in values)
	{
		root = root.AddNode(value);
	}
	int result = new Solution().MinDiffInBST(root);
	Assert.Equal(expected, result);

}

[Theory]
[InlineData(new[] { 4, 2, 6, 1, 3 }, new[] { 1, 2, 3, 4, 6 })]
[InlineData(new[] { 1, 0, 48, 12, 49 }, new[] { 0, 1, 12, 48, 49 })]
public void P00783_Test(int[] values, int[] expected)
{
	TreeNode root = null;
	foreach (int value in values)
	{
		root = root.AddNode(value);
	}
	List<int> result = new List<int>();
	new Solution().GetInorderValues(root, result);
	Assert.Equal(expected, result);
}