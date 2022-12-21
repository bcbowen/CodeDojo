<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

// You can define other methods, fields, classes and namespaces here

public class Solution
{
	public IList<int> Preorder(Node root)
	{
		List<int> values = new List<int>();
		if (root == null) return values;
		values.Add(root.val);
		if (root.children != null)
		{
			foreach (Node child in root.children)
			{
				values.AddRange(Preorder(child));
			}
		}
		return values;
	}
}

// First version had a lot of code for supportibg classes that weren't necessary for the second version 

Node HydrateNode(int[] nodeMap)
{
	Node root = new Node(nodeMap[0]);
	Node parent = root;
	List<Node> siblings = new List<Node>();
	List<Node> parentSiblings = new List<Node>(new List<Node> { root});
	int currentIndex = 0;
	for(int i = 2; i < nodeMap.Length; i++)
	{
		if (nodeMap[i] != -1) 
		{
			Node node = new Node(nodeMap[i]);
			parent.children.Add(node); 
			siblings.Add(node);
		}
		else if (currentIndex < parentSiblings.Count - 1) 
		{
			// next node current level
			parent = parentSiblings[++currentIndex];
		}
		else
		{
			// next level
			parent = siblings[0];
			parentSiblings = siblings;
			siblings = new List<Node>();
			currentIndex = 0;
		}
	}
	return root;
}

// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
		children = new List<Node>();
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}


public class SolutionFirst
{
	public IList<int> Preorder(Node root)
	{
		List<int> visited = new List<int>();
		if (root != null) 
		{
			Dfs(root, visited);	
		}
		return visited;
	}

	private void Dfs(Node node, List<int> visited)
	{
		visited.Add(node.val);
		foreach(Node child in node.children) 
		{
			Dfs(child, visited); 
		}
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);


[Theory]
[InlineData(new[] { 1, -1, 3, 2, 4, -1, 5, 6 }, new[] { 1, 3, 5, 6, 2, 4 })]
[InlineData(new[] { 1, -1, 2, 3, 4, 5, -1, -1, 6, 7, -1, 8, -1, 9, 10, -1, -1, 11, -1, 12, -1, 13, -1, -1, 14 }, new[] { 1, 2, 3, 6, 7, 11, 14, 4, 8, 12, 5, 9, 13, 10 })]
void Tests(int[] nodeMap, int[] expected)
{
	Node root = HydrateNode(nodeMap);
	IList<int> result = new Solution().Preorder(root);
	Assert.Equal(expected.ToList(), result);
}
#region HydrateNodeTests

[Fact]
void HydrateNode_BasicCompleteTreeRoot2Kids()
{
	int[] map = { 1, -1, 2, 3 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(2, root.children.Count);
}

[Fact]
void HydrateNode_BasicCompleteTree3Levels2Kids()
{
	int[] map = { 1, -1, 2, 3, -1, 4, 5, -1, 6, 7 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(2, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(2, current.val);
	Assert.Equal(4, current.children[0].val);
	Assert.Equal(5, current.children[1].val);
	current = root.children[1];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(3, current.val);
	Assert.Equal(6, current.children[0].val);
	Assert.Equal(7, current.children[1].val);
}

/// <summary></summary>
[Fact]
void HydrateNode_3Levels2Kids1GrandKidNoSkips()
{
	int[] map = { 1, -1, 2, 3, -1, 4 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(2, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(1, current.children.Count);
	Assert.Equal(4, current.children[0].val);
}

/// <summary></summary>
[Fact]
void HydrateNode_3Levels3Kids1GrandKidNoSkips()
{
	int[] map = { 1, -1, 2, 3, 4, -1, 5 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(3, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(1, current.children.Count);
	Assert.Equal(5, current.children[0].val);
}

/// <summary></summary>
[Fact]
void HydrateNode_3Levels3Kids2GrandKidsNoSkips()
{
	int[] map = { 1, -1, 2, 3, 4, -1, 5, 6 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(3, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(6, current.children[1].val);
}

/// <summary></summary>
[Fact]
void HydrateNode_3Levels3Kids3GrandKidsWithOneSkip()
{
	int[] map = { 1, -1, 2, 3, 4, -1, 5, 6, -1, 7 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(3, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(6, current.children[1].val);
	current = root.children[1];
	Assert.Equal(1, current.children.Count);
	Assert.Equal(7, current.children[0].val);
}

/// <summary></summary>
[Fact]
void HydrateNode_BasicTreeRoot3Levels3Kids3GrandKidsWithOneSkip()
{
	int[] map = { 1, -1, 2, 3, 4, -1, 5, 6, -1, 7 };
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(3, root.children.Count);
	Node current = root.children[0];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(6, current.children[1].val);
	current = root.children[1];
	Assert.Equal(1, current.children.Count);
	Assert.Equal(7, current.children[0].val);
}

[Fact]
void HydrateNode_LeetCode589Example2()
{
	// 1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14
	int[] map = { 1, -1, 2, 3, 4, 5, -1, -1, 6, 7, -1, 8, -1, 9, 10, -1, -1, 11, -1, 12, -1, 13, -1, -1, 14 };
	// 1
	Node root = HydrateNode(map);
	Assert.Equal(1, root.val);
	Assert.Equal(4, root.children.Count);

	//2
	Node current = root.children[0];
	Assert.Equal(0, current.children.Count);
	Assert.Equal(2, current.val);

	//3
	current = root.children[1];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(3, current.val);
	Assert.Equal(6, current.children[0].val);
	Assert.Equal(7, current.children[1].val);

	//4
	current = root.children[2];
	Assert.Equal(1, current.children.Count);
	Assert.Equal(4, current.val);
	Assert.Equal(8, current.children[0].val);

	//5
	current = root.children[3];
	Assert.Equal(2, current.children.Count);
	Assert.Equal(5, current.val);
	Assert.Equal(9, current.children[0].val);
	Assert.Equal(10, current.children[1].val);

	//6 
	current = root.children[1].children[0];
	Assert.Equal(6, current.val);
	Assert.Equal(0, current.children.Count);

	//7
	current = root.children[1].children[1];
	Assert.Equal(7, current.val);
	Assert.Equal(1, current.children.Count);
	Assert.Equal(11, current.children[0].val);

	//8
	current = root.children[2].children[0];
	Assert.Equal(8, current.val);
	Assert.Equal(1, current.children.Count);
	Assert.Equal(12, current.children[0].val);

	//9
	current = root.children[3].children[0];
	Assert.Equal(9, current.val);
	Assert.Equal(1, current.children.Count);
	Assert.Equal(13, current.children[0].val);

	//10
	current = root.children[3].children[1];
	Assert.Equal(10, current.val);
	Assert.Equal(0, current.children.Count);

	//11
	current = root.children[1].children[1].children[0];
	Assert.Equal(11, current.val);
	Assert.Equal(1, current.children.Count);
	Assert.Equal(14, current.children[0].val);

	//12
	current = root.children[2].children[0].children[0];
	Assert.Equal(12, current.val);
	Assert.Equal(0, current.children.Count);

	//13
	current = root.children[3].children[0].children[0];
	Assert.Equal(13, current.val);
	Assert.Equal(0, current.children.Count);

	//14
	current = root.children[1].children[1].children[0].children[0];
	Assert.Equal(14, current.val);
	Assert.Equal(0, current.children.Count);
}

#endregion HydrateNodeTests


#endregion