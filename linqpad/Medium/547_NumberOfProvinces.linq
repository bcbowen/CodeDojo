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
	private int[] _root;
	private int[] _rank;
	private int _sets;
	public int FindCircleNum(int[][] isConnected)
	{
		_root = new int[isConnected[0].Length];
		_rank = new int[isConnected[0].Length];
		_sets = isConnected[0].Length;
		for (int i = 0; i < _root.Length; i++)
		{
			_root[i] = i;
			_rank[i] = 1;
		}

		for (int i = 0; i < isConnected.Length; i++)
		{
			for (int j = 0; j < isConnected[i].Length; j++)
			{
				if (i != j && isConnected[i][j] == 1)
				{
					Union(i, j);
				}
			}
		}

		return _sets;
	}

	internal int Find(int x)
	{
		if (x == _root[x])
		{
			return x;
		}
		return _root[x] = Find(x);
	}

	internal void Union(int x, int y)
	{
		int rootX = Find(x);
		int rootY = Find(y);
		if (rootX != rootY)
		{
			if (_rank[rootX] > _rank[rootY])
			{
				_root[rootY] = rootX;
			}
			else if (_rank[rootY] > _rank[rootX])
			{
				_root[rootX] = rootY;
			}
			else
			{
				_root[rootY] = rootX;
				_rank[rootX]++;
			}
			_sets--;
		}
	}

	internal bool Connected(int x, int y)
	{
		return Find(x) == Find(y);
	}
}

#region private::Tests

[Theory]
//[InlineData(2, new[] { 1, 1, 0 }, new[] { 1, 1, 0 }, new[] { 0, 0, 1 })]
[InlineData(3, new[] { 1, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 1 })]
void Test(int expected, params int[][] isConnected)
{
	int result = new Solution().FindCircleNum(isConnected);
	Assert.Equal(expected, result);
}

/*
Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2

Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3

*/

#endregion