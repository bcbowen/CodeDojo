<Query Kind="Program" />

void Main()
{

}

// Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Codec
{

	// Encodes a tree to a single string.
	public string serialize(TreeNode root)
	{
		StringBuilder result = new StringBuilder();

		Stack<TreeNode> nodeStack = new Stack<TreeNode>();
		result.Append('[');
		result.Append(NodePreorderDfs(root));

		if (result[result.Length - 1] == ',') result.Length--;
		result.Append(']');
		return result.ToString();
	}

	internal string NodePreorderDfs(TreeNode node)
	{
		StringBuilder result = new StringBuilder();
		if (node != null)
		{
			result.Append($"{node.val},");
			if (node.left != null)
			{
				result.Append(NodePreorderDfs(node.left));
			}
			else
			{
				result.Append("null,");
			}

			if (node.right != null)
			{
				result.Append(NodePreorderDfs(node.right));
			}
			else
			{
				result.Append("null,");
			}
		}


		return result.ToString();
	}

	// Decodes your encoded data to tree.
	public TreeNode deserialize(string data)
	{
		TreeNode node = null;
		if (data != "[]")
		{
			string[] values = data.Substring(1, data.Length - 2).Split(',');
			node = new TreeNode(int.Parse(values[0]));
			Stack<TreeNode> nodeStack = new Stack<TreeNode>();
			nodeStack.Push(node);
			int i = 1;
			while (i < values.Length - 2)
			{
				TreeNode current = nodeStack.Peek();
				if (values[i] == "null" && values[i + 1] == "null")
				{
					i += 2;
					if (nodeStack.Count > 0 && i < values.Length)
					{
						nodeStack.Pop();
						current = nodeStack.Pop();
						if (values[i] != "null") current.right = new TreeNode(int.Parse(values[i]));
						nodeStack.Push(current.right);
					}
				}
				else if (values[i] != "null")
				{
					current.left = new TreeNode(int.Parse(values[i]));
					nodeStack.Push(current.left);
				}
				i++;
			}
		}
		return node;
	}
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));