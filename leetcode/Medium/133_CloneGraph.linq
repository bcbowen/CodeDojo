<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Node
{
	public int val;
	public IList<Node> neighbors;

	public Node()
	{
		val = 0;
		neighbors = new List<Node>();
	}

	public Node(int _val)
	{
		val = _val;
		neighbors = new List<Node>();
	}

	public Node(int _val, List<Node> _neighbors)
	{
		val = _val;
		neighbors = _neighbors;
	}
}

public class Solution
{
	public Node CloneGraph(Node node)
	{
		if (node == null) return null;
		Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
		Queue<Node> nodeQueue = new Queue<Node>();
		nodeQueue.Enqueue(node);
		visited.Add(node, new Node(node.val));
		while (nodeQueue.Count > 0)
		{
			Node currentNode = nodeQueue.Dequeue();
			foreach (Node neighbor in currentNode.neighbors)
			{
				if (!visited.ContainsKey(neighbor))
				{
					visited.Add(neighbor, new Node(neighbor.val));
					nodeQueue.Enqueue(neighbor);
				}
				visited[neighbor].neighbors.Add(visited[currentNode]);
			}
		}

		return visited[node];
	}
}

[Fact]
public void P00133_CloneGraph_4NodeGraphTest()
{
	/*
	Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
	Output: [[2,4],[1,3],[2,4],[1,3]]
	Explanation: There are 4 nodes in the graph.
	1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
	2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
	3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
	4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).

	*/

	Node node1 = new Node(1);
	Node node2 = new Node(2);
	Node node3 = new Node(3);
	Node node4 = new Node(4);

	node1.neighbors.Add(node2);
	node1.neighbors.Add(node4);

	node2.neighbors.Add(node1);
	node2.neighbors.Add(node3);

	node3.neighbors.Add(node2);
	node3.neighbors.Add(node4);

	node4.neighbors.Add(node1);
	node4.neighbors.Add(node3);

	Node clone = new Solution().CloneGraph(node1);
	Assert.Equal(1, clone.val);
	Assert.Equal(2, clone.neighbors.Count());
	Assert.Equal(2, clone.neighbors[0].val);
	Assert.Equal(4, clone.neighbors[1].val);

	clone = clone.neighbors[0];
	Assert.Equal(2, clone.val);
	Assert.Equal(2, clone.neighbors.Count());
	Assert.Equal(1, clone.neighbors[0].val);
	Assert.Equal(3, clone.neighbors[1].val);

	clone = clone.neighbors[1];
	Assert.Equal(3, clone.val);
	Assert.Equal(2, clone.neighbors.Count());
	Assert.Equal(2, clone.neighbors[0].val);
	Assert.Equal(4, clone.neighbors[1].val);

	clone = clone.neighbors[1];

	Assert.Equal(4, clone.val);
	Assert.Equal(2, clone.neighbors.Count);
	Assert.Equal(1, clone.neighbors[0].val);
	Assert.Equal(3, clone.neighbors[1].val);

}

[Fact]
public void P00133_CloneGraph_1NodeNoNeighbors()
{
	/*
	Input: adjList = [[]]
	Output: [[]]
	Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.

	*/
	Node node1 = new Node(1);

	Node clone = new Solution().CloneGraph(node1);
	Assert.Equal(1, clone.val);
	Assert.Equal(0, clone.neighbors.Count());

}

[Fact]
public void P00133_CloneGraph_EmptyGraphTest()
{
	/*
	 Input: adjList = []
	 Output: []
	 Explanation: This an empty graph, it does not have any nodes.
	*/

	Node node1 = null;

	Node clone = new Solution().CloneGraph(node1);
	Assert.Null(clone);
}