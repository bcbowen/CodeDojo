<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution {
    public int NumSquares(int n)
    {
        int[] squares = GetSquares(n);
        Queue<(int, int)> totals = new Queue<(int, int)>();
        bool found = false;
        int count = 1;
        HashSet<int> values= new HashSet<int>();
        foreach (int i in squares) 
        {
			if (i == n) return 1;
			totals.Enqueue((count, i));
		}
		totals.Enqueue((0, 0));
		count++;
		while (!found)
		{
			(int c, int v) = totals.Dequeue();
			if (c == 0)
			{
				count++;
				totals.Enqueue((0, 0));
				continue;
			}
			foreach (int s in squares)
			{
				int value = v + s;
				if (value == n)
				{
					found = true;
					break;
				}
				if (value < n && !values.Contains(value))
				{
					totals.Enqueue((count, value));
				}
			}

		}

		return count;
	}

	private int[] GetSquares(int n)
	{
		List<int> squares = new List<int>();
		int root = 1;
		int square = 1;
		while (square <= n)
		{
			squares.Add(square);
			root++;
			square = root * root;
		}

		return squares.ToArray();
	}
}

#region Tests

[Theory]
[InlineData(12, 3)]
[InlineData(13, 2)]
void Test(int n, int expected)
{
	int result = new Solution().NumSquares(n);
	Assert.Equal(expected, result);
}
/*
Example 1:
Input: n = 12
Output: 3
Explanation: 12 = 4 + 4 + 4.

Example 2:
Input: n = 13
Output: 2
Explanation: 13 = 4 + 9.
*/
#endregion