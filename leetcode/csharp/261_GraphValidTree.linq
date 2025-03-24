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
	public bool ValidTree(int n, int[][] edges)
	{
		if (edges.Length == 0 || edges[0].Length == 0) return n == 1;

		Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
		foreach (int[] edge in edges)
		{
			if (!adjacencyList.ContainsKey(edge[0]))
			{
				adjacencyList.Add(edge[0], new List<int>());
			}
			adjacencyList[edge[0]].Add(edge[1]);

			if (!adjacencyList.ContainsKey(edge[1]))
			{
				adjacencyList.Add(edge[1], new List<int>());
			}
			adjacencyList[edge[1]].Add(edge[0]);
		}

		Dictionary<int, int> parent = new Dictionary<int, int>();
		parent.Add(edges[0][0], edges[0][0]);
		Stack<int> stack = new Stack<int>();
		stack.Push(edges[0][0]);
		while (stack.Count > 0)
		{
			int node = stack.Pop();
			foreach (int neighbor in adjacencyList[node])
			{
				if (parent[node] == neighbor)
				{
					continue;
				}

				if (parent.ContainsKey(neighbor)) return false;

				stack.Push(neighbor);
				parent.Add(neighbor, node);
			}
		}

		return parent.Count == n;
	}
}

#region private::Tests

/*
Input: n = 5, edges = [[0,1],[0,2],[0,3],[1,4]]
Output: true
Example 2:


Input: n = 5, edges = [[0,1],[1,2],[2,3],[1,3],[1,4]]
Output: false

4
edges =
[[2,3],[1,2],[1,3]]
false
*/

[Theory]
[InlineData(4, false, new[] { 2, 3 }, new[] { 1, 2 }, new[] { 1, 3 })]
[InlineData(5, true, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 }, new[] { 1, 4 })]
[InlineData(5, false, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 1, 3 }, new[] { 1, 4 })]
/**/
void Test(int n, bool expected, params int[][] edges)
{
	bool result = new Solution().ValidTree(n, edges);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(2, false)]
[InlineData(1, true)]
void TestEmptyArrayCases(int n, bool expected)
{
	int[][] edges = new int[0][]; 
	bool result = new Solution().ValidTree(n, edges);
	Assert.Equal(expected, result);
}



#endregion