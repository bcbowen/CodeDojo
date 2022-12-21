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
	public TreeNode(int x) { val = x; }
}

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

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));

#region Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
public void FullTest1() 
{
	TreeNode node = new TreeNode(1); 
	node.left = new TreeNode(2); 
	node.right = new TreeNode(3); 
	node.right.left = new TreeNode(4);
	node.right.right = new TreeNode(5);
	
	Codec c = new Codec(); 
	string serialized = c.serialize(node); 
	
	TreeNode deserilized = c.deserialize(serialized); 
	
	Assert.Equal(1, deserilized.val);
	Assert.Equal(2, deserilized.left.val);
	Assert.Equal(3, deserilized.right.val);
	Assert.Equal(4, deserilized.right.left.val);
	Assert.Equal(5, deserilized.right.right.val);
	
}



/*
Input: root = [1,2,3,null,null,4,5]
Output: [1,2,3,null,null,4,5]
Example 2:

Input: root = []
Output: []

 
*/
#region serialize

[Fact]
void SerializeEmptyTree() 
{
	Codec c = new Codec();
	TreeNode root = null; 
	string result = c.serialize(root); 
	string expected = "null";
	Assert.Equal(expected, result);
}

[Fact]
void SerializeSingleNodeTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	string result = c.serialize(root);
	string expected = "1,null,null";
	Assert.Equal(expected, result);
}

[Fact]
void SerializeFullTwoLevelTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2); 
	root.right = new TreeNode(3); 
	string result = c.serialize(root);
	string expected = "1,2,null,null,3,null,null";
	Assert.Equal(expected, result);
}

[Fact]
void SerializePartialTwoLevelTree()
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	string result = c.serialize(root);
	string expected = "1,2,null,null,null";
	Assert.Equal(expected, result);
}

[Fact]
void SerializeFiveNodeTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.left.left = new TreeNode(3); 
	root.left.right = new TreeNode(4); 
	root.right = new TreeNode(5);
	string result = c.serialize(root);
	string expected = "1,2,3,null,null,4,null,null,5,null,null";
	Assert.Equal(expected, result);
}

[Fact]
void SerializeFullThreeLevelTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.left.left = new TreeNode(3);
	root.left.right = new TreeNode(4);
	root.right = new TreeNode(5);
	root.right.left = new TreeNode(6);
	root.right.right = new TreeNode(7);
	string result = c.serialize(root);
	string expected = "1,2,3,null,null,4,null,null,5,6,null,null,7,null,null";
	Assert.Equal(expected, result);

}

#endregion

#region deserialize

[Fact]
void DeSerializeSingleNodeTree() 
{
	Codec c = new Codec();
	string s = "1,null,null";
	TreeNode root = c.deserialize(s);
	Assert.Equal(1, root.val);
	Assert.Null(root.left); 
	Assert.Null(root.right); 
}

[Fact]
void DeSerializeFullTwoLevelTree() 
{
	Codec c = new Codec();
	string data = "1,2,null,null,3,null,null";
	TreeNode root = c.deserialize(data);
	Assert.Equal(1, root.val);
	Assert.Equal(2, root.left.val);
	Assert.Equal(3, root.right.val);
	Assert.Null(root.left.left);
	Assert.Null(root.left.right);
	Assert.Null(root.right.left);
	Assert.Null(root.right.right);
}

[Fact]
void DeSerializePartialTwoLevelTree()
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	string result = c.serialize(root);
	string expected = "1,2,null,null,null";
	Assert.Equal(expected, result);
}

#endregion

#region troubleshooting

/*

 [4,-7,-3,null,null,-9,-3,9,-7,-4,null,6,null,-6,-6,null,null,0,6,5,null,9,null,null,-1,-4,null,null,null,-2]
 
*/

[Fact]
void BigHonkingTreeTest() 
{
	TreeNode node = new TreeNode(4); 
	node.left = new TreeNode(-7); 
	node.right = new TreeNode(-3);
	
	TreeNode current = node.right;
	current.left = new TreeNode(-9); 
	current.right = new TreeNode(-3); 
	current.right.left = new TreeNode(-4);
	
	current = current.left;
	current.left = new TreeNode(9); 
	current.right = new TreeNode(-7);
	
	// left side from 9
	current.left.left = new TreeNode(6); 
	current.left.left.left = new TreeNode(0);
	current.left.left.left.right = new TreeNode(-1); 
	current.left.left.right = new TreeNode(6); 
	current.left.left.right.left = new TreeNode(-4); 
	
	// right side from -7
	current = current.right; 
	current.left = new TreeNode(-6); 
	current.left.left = new TreeNode(5); 
	current.right = new TreeNode(-6); 
	current = current.right; 
	current.left = new TreeNode(9); 
	current.left.left = new TreeNode(-2); 
	
	Codec c = new Codec();
	string s = c.serialize(node);
	Assert.Equal("4,-7,null,null,-3,-9,9,6,0,null,-1,null,null,6,-4,null,null,null,null,-7,-6,5,null,null,null,-6,9,-2,null,null,null,null,-3,-4,null,null,null", s); 
	TreeNode d = c.deserialize(s); 
	d.Dump();
}

[Fact]
public void OneLevelMissingLeftChild() 
{
	TreeNode node = new TreeNode(1); 
	node.right = new TreeNode(2); 
	Codec c = new Codec(); 
	string s = c.serialize(node); 
	Assert.Equal("1,null,2,null,null", s);
	TreeNode d = c.deserialize(s); 
	Assert.Equal(1, d.val); 
	Assert.Null(d.left); 
	Assert.Equal(2, d.right.val);
	Assert.Null(d.right.left);
	Assert.Null(d.right.right);
}
#endregion troubleshooting



/*

Input:
[1,null,2]
Output:
[1,2]
Expected:
[1,null,2]


[Fact]
void SerializeFiveNodeTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.left.left = new TreeNode(3); 
	root.left.right = new TreeNode(4); 
	root.right = new TreeNode(5);
	string result = c.serialize(root);
	string expected = "[1,2,3,null,null,4,null,null,5,null,null]";
	Assert.Equal(expected, result);
}

[Fact]
void SerializeFullThreeLevelTree() 
{
	Codec c = new Codec();
	TreeNode root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.left.left = new TreeNode(3);
	root.left.right = new TreeNode(4);
	root.right = new TreeNode(5);
	root.right.left = new TreeNode(6);
	root.right.right = new TreeNode(7);
	string result = c.serialize(root);
	string expected = "[1,2,3,null,null,4,null,null,5,6,null,null,7,null,null]";
	Assert.Equal(expected, result);

}
*/


#endregion