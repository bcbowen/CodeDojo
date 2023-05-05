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
	public IList<IList<int>> LevelOrder(Node root)
	{
		List<IList<int>> result = new List<IList<int>>();
		if (root == null) return result;
		Queue<Node> nodeQueue = new Queue<Node>();
		nodeQueue.Enqueue(root);
		List<int> row;
		while (nodeQueue.Count > 0)
		{
			row = new List<int>();
			int rowCount = nodeQueue.Count;
			for (int i = 0; i < rowCount; i++)
			{
				Node current = nodeQueue.Dequeue();
				row.Add(current.val);
				foreach (Node child in current.children)
				{
					nodeQueue.Enqueue(child);
				}

			}
			result.Add(row);
		}
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

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

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

	IList<IList<int>> result = new Solution().LevelOrder(root);
	// Output: [[1],[3,2,4],[5,6]]
	Assert.Equal(3, result.Count);
	IList<int> row = result[0];
	Assert.Equal(1, row.Count);
	Assert.Equal(1, row[0]);

	row = result[1];
	Assert.Equal(3, row.Count);
	Assert.Equal(new List<int> { 3, 2, 4 }, row);

	row = result[2];
	Assert.Equal(2, row.Count);
	Assert.Equal(new List<int> { 5, 6 }, row);
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

	IList<IList<int>> result = new Solution().LevelOrder(root).ToArray();
	// [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
	Assert.Equal(5, result.Count);
	IList<int> row = result[0];
	Assert.Equal(1, row.Count);
	Assert.Equal(1, row[0]);

	row = result[1];
	Assert.Equal(4, row.Count);
	Assert.Equal(new List<int> { 2, 3, 4, 5 }, row);

	row = result[2];
	Assert.Equal(5, row.Count);
	Assert.Equal(new List<int> { 6, 7, 8, 9, 10 }, row);

	row = result[3];
	Assert.Equal(3, row.Count);
	Assert.Equal(new List<int> { 11, 12, 13 }, row);

	row = result[4];
	Assert.Equal(1, row.Count);
	Assert.Equal(14, row[0]);
}

/*
1
Input: root = [1,null,3,2,4,null,5,6]
Output: [[1],[3,2,4],[5,6]]

2
Input: root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,null,13,null,null,14]
Output: [[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
*/

#endregion