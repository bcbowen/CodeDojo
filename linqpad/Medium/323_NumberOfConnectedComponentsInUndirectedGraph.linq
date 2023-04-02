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
	int[] _parents;
	int[] _ranks;
	int _groups;

	public int CountComponents(int n, int[][] edges)
	{
		_parents = new int[n];
		for (int i = 0; i < n; i++)
		{
			_parents[i] = i;
		}

		_ranks = new int[n];
		_groups = n;
		foreach (int[] edge in edges)
		{
			Union(edge[0], edge[1]);
		}

		return _groups;
	}

	private void Union(int i, int j)
	{
		if (IsConnected(i, j)) return;

		int rootI = Find(i);
		int rootJ = Find(j);
		if (_ranks[rootI] > _ranks[rootJ])
		{
			_parents[rootJ] = _parents[rootI];
		}
		else if (_ranks[rootI] < _ranks[rootJ])
		{
			_parents[rootI] = _parents[rootJ];
		}
		else
		{
			_parents[rootJ] = _parents[rootI];
			_ranks[rootI]++;
		}

		_groups--;
	}

	private int Find(int i)
	{
		if (_parents[i] == i) return i;

		return Find(_parents[i]);
	}

	private bool IsConnected(int i, int j)
	{
		return Find(i) == Find(j);
	}
}

/*
Input: n = 5, edges = [[0,1],[1,2],[3,4]]
Output: 2

Input: n = 5, edges = [[0,1],[1,2],[2,3],[3,4]]
Output: 1

*/

[Theory]
[InlineData(5, 2, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 3, 4 })]
[InlineData(5, 1, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 })]
void Test(int n, int expected, params int[][] edges)
{
	int result = new Solution().CountComponents(n, edges);
	Assert.Equal(expected, result);
}
