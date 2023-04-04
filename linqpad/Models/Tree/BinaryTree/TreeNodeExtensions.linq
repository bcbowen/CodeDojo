<Query Kind="Statements" />

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