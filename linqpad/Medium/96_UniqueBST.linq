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
	public int NumTrees(int n)
	{
		int[] G = new int[n + 1];
		G[0] = 1;
		G[1] = 1;

		for (int i = 2; i <= n; i++)
		{
			for (int j = 1; j <= i; j++)
			{
				G[i] += G[j - 1] * G[i - j];
			}
		}
		
		return G[n];
		
	}
}

#region private::Tests

[Theory]
[InlineData(3, 5)]
[InlineData(1, 1)]
void Test(int n, int expected) 
{
	int result = new Solution().NumTrees(n);
	Assert.Equal(expected, result);
}

#endregion