using LeetCode.Solutions.Models.Tree.BinaryTree;
using System.Text;

namespace LeetCode.Solutions.Hard.P00297_SerializeAndDeserializeBinaryTree;

public class Codec
{
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        StringBuilder result = new StringBuilder();
        NodePreorderDfs(root, result);
        if (result[result.Length - 1] == ',')
        {
            result.Length--;
        }
        return result.ToString();
    }

    internal void NodePreorderDfs(TreeNode node, StringBuilder builder)
    {
        if (node == null)
        {
            builder.Append("null,");
        }
        else
        {
            builder.Append($"{node.val},");
            NodePreorderDfs(node.left, builder);
            NodePreorderDfs(node.right, builder);
        }
    }

    internal TreeNode deserialize(List<string> values)
    {
        if (values[0] == "null")
        {
            values.RemoveAt(0);
            return null;
        }

        TreeNode node = new TreeNode(int.Parse(values[0]));
        values.RemoveAt(0);
        node.left = deserialize(values);
        node.right = deserialize(values);

        return node;
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        List<string> values = data.Split(',').ToList();
        return deserialize(values);
    }
}
