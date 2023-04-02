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
	public IList<int> Postorder(Node root)
	{
		List<int> result = new List<int>();
		if (root == null) return result;
		foreach(Node child in root.children) 
		{
			result.AddRange(Postorder(child));
		}
		result.Add(root.val);
		
		return result;
	}
}

public class Node
{
	public int val;
	public IList<Node> children;

	public Node() 
	{
		children = new List<Node>();
	}

	public Node(int _val) : this()
	{
		val = _val;
	}

	public Node(int _val, IList<Node> _children)
	{
		val = _val;
		children = _children;
	}
}

[Fact]
void Example1Test()
{
	Node root = new Node(1);
	Node current = root;
	current.children.Add(new Node(3));
	current.children.Add(new Node(2));
	current.children.Add(new Node(4));
	current = current.children[0];
	current.children.Add(new Node(5));
	current.children.Add(new Node(6));

	int[] result = new Solution().Postorder(root).ToArray();
	int[] expected = new int[] { 5, 6, 3, 2, 4, 1 };

	Assert.Equal(expected, result);
}

[Fact]
void Example2Test()
{
	Node root = new Node(1);
	Node current = root;
	current.children.Add(new Node(2));
	current.children.Add(new Node(3));
	current.children.Add(new Node(4));
	current.children.Add(new Node(5));

	// 3
	current = current.children[1];
	current.children.Add(new Node(6));
	current.children.Add(new Node(7));

	// 4
	current = root.children[2];
	current.children.Add(new Node(8));
	// 5
	current = root.children[3];
	current.children.Add(new Node(9));
	current.children.Add(new Node(10));
	
	// 7
	current = root.children[1].children[1];
	current.children.Add(new Node(11));
	current = current.children[0];
	current.children.Add(new Node(14));

	// 8
	current = root.children[2].children[0];
	current.children.Add(new Node(12));

	// 9
	current = root.children[3].children[0];
	current.children.Add(new Node(13));

	int[] result = new Solution().Postorder(root).ToArray();
	int[] expected = new int[] { 2, 6, 14, 11, 7, 3, 12, 8, 4, 13, 9, 10, 5, 1 };

	Assert.Equal(expected, result);
}

/*
1
Input: root = [1,null,3,2,4,null,5,6]
Output: [5,6,3,2,4,1]

2
Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [2,6,14,11,7,3,12,8,4,13,9,10,5,1]
*/
