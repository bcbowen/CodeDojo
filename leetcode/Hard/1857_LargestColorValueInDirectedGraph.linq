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
	private Dictionary<char, int> _colorCounts;
	private Dictionary<int, List<int>> _adjacencyList;
	private bool[] _visited;
	private int _nodeCount;
	private bool _cycleDetected;
	private string _colors;

	public int LargestPathValue(string colors, int[][] edges)
	{
		_colors = colors;
		_nodeCount = colors.Length;
		_colorCounts = new Dictionary<char, int>();
		_adjacencyList = new Dictionary<int, List<int>>();
		_visited = new bool[_nodeCount];
		foreach (int[] edge in edges)
		{
			if (edge[0] == edge[1]) return -1;
			if (!_adjacencyList.ContainsKey(edge[0]))
			{
				_adjacencyList.Add(edge[0], new List<int>());
			}
			_adjacencyList[edge[0]].Add(edge[1]);
		}

		_visited[0] = true;
		foreach (int next in _adjacencyList[0])
		{
			_colorCounts.Clear();
			IncrementColor(_colors[0]); 
			IncrementColor(_colors[next]);
			bool found = DFS(next);
			if (_cycleDetected) return -1;
			if (found) break;

		}
		return _colorCounts.Values.Max();
	}

	internal void IncrementColor(char c)
	{
		if (!_colorCounts.ContainsKey(c))
		{
			_colorCounts.Add(c, 0);
		}
		_colorCounts[c]++;
	}

	internal bool DFS(int val)
	{
		if (!_adjacencyList.ContainsKey(val) || _adjacencyList[val].Count == 0)
		{
			return false;
		}

		int next = _adjacencyList[val].First();
		IncrementColor(_colors[next]);
		
		if (_visited[next])
		{
			_cycleDetected = true;
			return false;
		}
		_visited[next] = true;
		if (next == _nodeCount - 1) return true;

		return DFS(next);
	}
}

/*

Input: colors = "abaca", edges = [[0,1],[0,2],[2,3],[3,4]]
Output: 3
Explanation: The path 0 -> 2 -> 3 -> 4 contains 3 nodes that are colored "a" (red in the above image).

Input: colors = "a", edges = [[0,0]]
Output: -1
Explanation: There is a cycle from 0 to 0.
*/

[Theory]
[InlineData("abaca", -1, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 3, 0 })]
[InlineData("abaca", -1, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 3, 2 })]
[InlineData("abaca", 3, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 3, 4 })]
[InlineData("a", -1, new[] { 0, 0 })]
public void Test(string colors, int expected, params int[][] edges)
{
	int result = new Solution().LargestPathValue(colors, edges);
	Assert.Equal(expected, result);
}

[Fact]
public void Troubleshooting()
{
	string colors = "abaca";
	int expected = 3;
	int[][] edges = new[] { new[] { 0, 1 }, new[] { 0, 2 }, new[] { 2, 3 }, new[] { 3, 4 } };
	int result = new Solution().LargestPathValue(colors, edges);
	Assert.Equal(expected, result);
}