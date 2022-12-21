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

public static class TreeNodeParser
{
	public static TreeNode Parse(string serialized)
	{
		if (string.IsNullOrEmpty(serialized) || serialized == "[]") 
		{
			return null;
		}
		
		serialized = serialized.Replace("[", "").Replace("]", "");
		string[] nodes = serialized.Split(',');
		TreeNode root = new TreeNode(int.Parse(nodes[0]));
		Queue<TreeNode> nodeQ = new Queue<TreeNode>();
		TreeNode node = root;
		nodeQ.Enqueue(node);
		int index = 1;
		while (nodeQ.Count > 0 && index < nodes.Length)
		{
			node = nodeQ.Dequeue(); 
			int value;
			if (nodes[index] != "null") 
			{
				value = int.Parse(nodes[index]);
				node.left = new TreeNode(value);
				nodeQ.Enqueue(node.left);
			}
			index++;
			
			if (index >= nodes.Length) break;
			
			if (nodes[index] != "null")
			{
				value = int.Parse(nodes[index]);
				node.right = new TreeNode(value);
				nodeQ.Enqueue(node.right);
			}
			index++;
		}
		
		return root;
	}
}

#region private::Tests

[Fact]
public void FullOneLevelTest() 
{
	string values = "[1,2,3]";
	TreeNode root = TreeNodeParser.Parse(values); 
	Assert.Equal(1, root.val);
	Assert.NotNull(root.left);
	Assert.NotNull(root.right);
	Assert.Equal(2, root.left.val);
	Assert.Equal(3, root.right.val);
}

[Fact]
public void RootAndLeftOneLevelTest()
{
	string values = "[1,2,null]";
	TreeNode root = TreeNodeParser.Parse(values);
	Assert.Equal(1, root.val);
	Assert.NotNull(root.left);
	Assert.Null(root.right);
	Assert.Equal(2, root.left.val);
}

[Fact]
public void RootAndRightOneLevelTest()
{
	string values = "[1,null,3]";
	TreeNode root = TreeNodeParser.Parse(values);
	Assert.Equal(1, root.val);
	Assert.Null(root.left);
	Assert.NotNull(root.right);
	Assert.Equal(3, root.right.val);
}

// [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
/*
         1
	  /     \
     4       4
      \     /
       2   2 
      /   / \ 
     1   6   8
	        / \
		   1   3
*/
[Fact]
public void FiveLevelPartialTreeTest()
{
	string values = "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]";
	TreeNode root = TreeNodeParser.Parse(values);
	Assert.Equal(1, root.val);
	Assert.NotNull(root.left);
	Assert.NotNull(root.right);
	Assert.Equal(4, root.left.val);
	Assert.Equal(2, root.left.right.val);
	Assert.Equal(1, root.left.right.left.val);
	
	Assert.Equal(4, root.right.val);
	Assert.Equal(2, root.right.left.val);
	Assert.Equal(6, root.right.left.left.val);
	Assert.Equal(8, root.right.left.right.val);
	Assert.Equal(1, root.right.left.right.left.val);
	Assert.Equal(3, root.right.left.right.right.val);
}

#endregion