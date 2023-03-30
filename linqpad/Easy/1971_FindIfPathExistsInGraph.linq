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
	public bool ValidPath(int n, int[][] edges, int source, int destination)
	{
		if (n == 1) return true;
		
		List<int> visited = new List<int>();
		Queue<int[]> edgeQ = new Queue<int[]>();
		foreach(int[] edge in GetEdges(edges, source))
		{
			edgeQ.Enqueue(edge);
		}
		while(edgeQ.Count > 0) 
		{
			int[] edge = edgeQ.Dequeue();
			
			if (edge[1] == destination) return true;
			
			if (!visited.Contains(edge[0])) visited.Add(edge[0]);
			foreach(int[] connectedEdge in GetEdges(edges, edge[1])) 
			{
				if (!visited.Contains(connectedEdge[1])) edgeQ.Enqueue(connectedEdge);
			}
		}
		
		return false;
	}

	private List<int[]> GetEdges(int[][] edges, int source) 
	{
		List<int[]> result = new List<int[]>();
		foreach(int[] edge in edges)
		{
			if (edge[0] == source) 
			{
				result.Add(edge);
			}
		}
		
		return result;
	}
}

#region private::Tests

/*
Input: n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
Output: false
Explanation: There is no path from vertex 0 to vertex 5.

Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
Output: true
Explanation: There are two paths from vertex 0 to vertex 2:
- 0 → 1 → 2
- 0 → 2


10
[[0,7],[0,8],[6,1],[2,0],[0,4],[5,8],[4,7],[1,3],[3,5],[6,5]]
7
5
true

*/

[Theory]
[InlineData(10, 7, 5, true, new[] { 0, 7 }, new[] { 0, 8 }, new[] { 6, 1 }, new[] { 2, 0 }, new[] { 0, 4}, new[] {5, 8}, new[] {4, 7}, new[] {1, 3}, new[] {3, 5}, new[] {6, 5})]
[InlineData(6, 0, 5, false, new[] {0, 1}, new[] {0, 2}, new[] {3, 5}, new[] {5, 4}, new[] {4, 3})]
[InlineData(3, 0, 2, true, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 })]
[InlineData(1, 0, 0, true, new int[0])]
void Test(int n, int source, int destination, bool expected, params int [][] edges) 
{
	bool result = new Solution().ValidPath(n, edges, source, destination); 
	Assert.Equal(expected, result);
}

#endregion