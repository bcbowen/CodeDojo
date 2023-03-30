<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
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
		if (n == 1 || source == destination) return true;

		UnionFind uf = new UnionFind(n);

		foreach (int[] edge in edges)
		{
			uf.Union(edge[0], edge[1]);
			if (edge[0] == source ||
			edge[0] == destination ||
			edge[1] == source ||
			edge[1] == destination)
			{
				if (uf.IsConnected(source, destination)) return true;
			}
		}

		return uf.IsConnected(source, destination);
	}

	/// <summary>
	/// Works for small tests, runs forever for big test... 
	/// switching to union find since it makes more sense for this problem
	/// </summary>
	public bool ValidPathDFS(int n, int[][] edges, int source, int destination)
	{
		if (n == 1 || source == destination) return true;

		bool[] visited = new bool[n];
		List<List<int>> adjacencyList = new List<List<int>>();
		Queue<int> cue = new Queue<int>();

		for (int i = 0; i < n; i++)
		{
			adjacencyList.Add(new List<int>());
		}

		foreach (int[] edge in edges)
		{
			if (!adjacencyList[edge[0]].Contains(edge[1])) adjacencyList[edge[0]].Add(edge[1]); 
			if (!adjacencyList[edge[1]].Contains(edge[0])) adjacencyList[edge[1]].Add(edge[0]); 
		}

		cue.Enqueue(source); 

		while (cue.Count > 0)
		{
			int v = cue.Dequeue();

			foreach(int c in adjacencyList[v]) 
			{
				if (c == destination) return true;
				if (!visited[c]) cue.Enqueue(c); 
			}
			visited[v] = true;
		}

		return false;
	}

}

public class UnionFind
{
	private int[] _root;
	private int[] _rank;

	public UnionFind(int len)
	{
		_root = new int[len];
		_rank = new int[len];

		for (int i = 0; i < len; i++)
		{
			_root[i] = i;
		}
	}

	public int Find(int i)
	{
		if (_root[i] == i) return i;

		// Add path compression to make subsequent calls faster
		return _root[i] = Find(_root[i]);
	}

	public void Union(int i, int j)
	{
		if (IsConnected(i, j)) return;

		int rootI = Find(i);
		int rootJ = Find(j);

		if (_rank[rootI] >= _rank[rootJ])
		{
			_root[rootJ] = _root[rootI];
			_rank[rootI] += _rank[rootJ];

		}
		else if (_rank[rootI] < _rank[rootJ])
		{
			_root[rootI] = _root[rootJ];
			_rank[rootJ] += _rank[rootI];
		}
	}

	internal bool IsConnected(int i, int j)
	{
		return Find(i) == Find(j);
	}

}


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
[InlineData(10, 7, 5, true, new[] { 0, 7 }, new[] { 0, 8 }, new[] { 6, 1 }, new[] { 2, 0 }, new[] { 0, 4 }, new[] { 5, 8 }, new[] { 4, 7 }, new[] { 1, 3 }, new[] { 3, 5 }, new[] { 6, 5 })]
[InlineData(6, 0, 5, false, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 3, 5 }, new[] { 5, 4 }, new[] { 4, 3 })]
[InlineData(3, 0, 2, true, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 })]
[InlineData(3, 0, 0, true, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 })]
[InlineData(1, 0, 0, true, new int[0])]
void TestUnionFind(int n, int source, int destination, bool expected, params int[][] edges)
{
	bool result = new Solution().ValidPath(n, edges, source, destination);
	Assert.Equal(expected, result);
}

[Fact]
void BigTestUnionFind()
{
	string path = Path.Combine(GetDataDirectoryPath(), "1971_BigTestEdges.txt");
	Assert.True(File.Exists(path));
	int[][] edges = JsonConvert.DeserializeObject<int[][]>(File.ReadAllText(path));
	int n = 20000;
	int source = 0;
	int destination = 19999;
	bool result = new Solution().ValidPath(n, edges, source, destination);
	bool expected = false;
	Assert.Equal(expected, result);
}

[Fact]
//[InlineData(10, 7, 5, true, new[] { 0, 7 }, new[] { 0, 8 }, new[] { 6, 1 }, new[] { 2, 0 }, new[] { 0, 4 }, new[] { 5, 8 }, new[] { 4, 7 }, new[] { 1, 3 }, new[] { 3, 5 }, new[] { 6, 5 })]
void TroubleshootDFS()
{
	int n = 10; 
	int source = 7; 
	int destination = 5;
	bool expected = true;
	int[][] edges = new []
	{
		new[] { 0, 7 }, 
		new[] { 0, 8 }, 
		new[] { 6, 1 }, 
		new[] { 2, 0 }, 
		new[] { 0, 4 }, 
		new[] { 5, 8 }, 
		new[] { 4, 7 }, 
		new[] { 1, 3 }, 
		new[] { 3, 5 }, 
		new[] { 6, 5 }
	};
	bool result = new Solution().ValidPathDFS(n, edges, source, destination);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(10, 7, 5, true, new[] { 0, 7 }, new[] { 0, 8 }, new[] { 6, 1 }, new[] { 2, 0 }, new[] { 0, 4 }, new[] { 5, 8 }, new[] { 4, 7 }, new[] { 1, 3 }, new[] { 3, 5 }, new[] { 6, 5 })]
[InlineData(6, 0, 5, false, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 3, 5 }, new[] { 5, 4 }, new[] { 4, 3 })]
[InlineData(3, 0, 2, true, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 })]
[InlineData(3, 0, 0, true, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 0 })]
[InlineData(1, 0, 0, true, new int[0])]
void TestDFS(int n, int source, int destination, bool expected, params int[][] edges)
{
	bool result = new Solution().ValidPathDFS(n, edges, source, destination);
	Assert.Equal(expected, result);
}

[Fact]
void BigTestDFS()
{
	string path = Path.Combine(GetDataDirectoryPath(), "1971_BigTestEdges.txt");
	Assert.True(File.Exists(path));
	int[][] edges = JsonConvert.DeserializeObject<int[][]>(File.ReadAllText(path));
	int n = 20000;
	int source = 0;
	int destination = 19999;
	bool result = new Solution().ValidPathDFS(n, edges, source, destination);
	bool expected = false;
	Assert.Equal(expected, result);
}


private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}
