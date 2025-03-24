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
	private int[] _parent;
	private int[] _rank;
	private int _groups;

	public int EarliestAcq(int[][] logs, int n)
	{
		_groups = n;
		_parent = new int[n];
		_rank = new int[n];
		for (int i = 0; i < n; i++)
		{
			_parent[i] = i;
		}

		Array.Sort(logs, (a, b) => a[0].CompareTo(b[0]));
		foreach(int[] log in logs)
		{
			Union(log[1], log[2]);
			if (_groups == 1) return log[0];
		}
		return -1;
	}

	private int Find(int value)
	{
		if (_parent[value] == value) return value;

		return Find(_parent[value]);
	}

	private void Union(int i, int j)
	{
		if (IsConnected(i, j)) return;

		int rootI = Find(i); 
		int rootJ = Find(j); 
		if (_rank[rootI] > _rank[rootJ])
		{
			_parent[rootJ] = _parent[rootI]; 
		}
		else if (_rank[rootI] < _rank[rootJ])
		{
			_parent[rootI] = _parent[rootJ]; 
		}
		else 
		{
			_parent[rootI] = _parent[rootJ]; 
			_rank[rootJ] ++;
		}
		_groups--;
	}

	private bool IsConnected(int i, int j)
	{
		return Find(i) == Find(j);
	}
}

#region private::Tests

[Theory]
/**/
[InlineData(6, 20190301, new[] { 20190101, 0, 1 }, new[] { 20190104, 3, 4 }, new[] { 20190107, 2, 3 }, new[] { 20190211, 1, 5 }, new[] { 20190224, 2, 4 }, new[] { 20190301, 0, 3 }, new[] { 20190312, 1, 2 }, new[] { 20190322, 4, 5 })]
[InlineData(4, 3, new[] { 0, 2, 0 }, new[] { 1, 0, 1 }, new[] { 3, 0, 3 }, new[] { 4, 1, 2 }, new[] { 7, 3, 1 })]
[InlineData(4, 3, new[] { 0, 2, 0 }, new[] { 1, 0, 1 }, new[] { 7, 3, 1 }, new[] { 3, 0, 3 }, new[] { 4, 1, 2 })]
[InlineData(5, -1, new[] { 0, 2, 0 }, new[] { 1, 0, 1 }, new[] { 3, 0, 3 }, new[] { 4, 1, 2 }, new[] { 7, 3, 1 })]
void Test(int n, int expected, params int[][] logs)
{
	int result = new Solution().EarliestAcq(logs, n);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: logs = [[20190101,0,1],[20190104,3,4],[20190107,2,3],[20190211,1,5],[20190224,2,4],[20190301,0,3],[20190312,1,2],[20190322,4,5]], n = 6
Output: 20190301
Explanation: 
The first event occurs at timestamp = 20190101, and after 0 and 1 become friends, we have the following friendship groups [0,1], [2], [3], [4], [5].
The second event occurs at timestamp = 20190104, and after 3 and 4 become friends, we have the following friendship groups [0,1], [2], [3,4], [5].
The third event occurs at timestamp = 20190107, and after 2 and 3 become friends, we have the following friendship groups [0,1], [2,3,4], [5].
The fourth event occurs at timestamp = 20190211, and after 1 and 5 become friends, we have the following friendship groups [0,1,5], [2,3,4].
The fifth event occurs at timestamp = 20190224, and as 2 and 4 are already friends, nothing happens.
The sixth event occurs at timestamp = 20190301, and after 0 and 3 become friends, we all become friends.
Example 2:

Input: logs = [[0,2,0],[1,0,1],[3,0,3],[4,1,2],[7,3,1]], n = 4
Output: 3
Explanation: At timestamp = 3, all the persons (i.e., 0, 1, 2, and 3) become friends.
 
*/

#endregion