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
	public int[] KWeakestRows(int[][] mat, int k)
	{
		PriorityQueue<int, int[]> queue = new PriorityQueue<int, int[]>(new ScoreComparer());
		for (int i = 0; i < mat.Length; i++)
		{
			int score = 0;
			for (int j = 0; j < mat[i].Length; j++)
			{
				if (mat[i][j] == 1)
				{
					score++;
				}
				else
				{
					queue.Enqueue(i, new[] { i, score });
					break;
				}
				
				if (j == mat[i].Length - 1) 
				{
					queue.Enqueue(i, new[] { i, score });
				}
			}
		}

		int[] result = new int[k];
		for (int i = 0; i < k; i++)
		{
			result[i] = queue.Dequeue();
		}

		return result;
	}
}

internal class ScoreComparer : IComparer<int[]>
{
	public int Compare(int[] score1, int[] score2)
	{
		if (score1.Length != 2) throw new ArgumentException("Bad score dickface", "score1");
		if (score2.Length != 2) throw new ArgumentException("Bad score dickface", "score2");

		if (score1[1] != score2[1]) return score1[1].CompareTo(score2[1]);
		return score1[0].CompareTo(score2[0]);
	}
}


#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(3, new[] { 2, 0, 3 }, new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 0 }, new[] { 1, 0, 0, 0, 0 }, new[] { 1, 1, 0, 0, 0 }, new[] { 1, 1, 1, 1, 1 })]
[InlineData(1, new[] { 2 }, new[] { 1, 1, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1, 1 }, new[] { 1, 1, 1, 1, 1 })]
void TestWeakestRows(int k, int[] expected, params int[][] matrix)
{
	int[] result = new Solution().KWeakestRows(matrix, k);
	Assert.Equal(expected, result);
}

/*

[[1,1,1,1,1,1],[1,1,1,1,1,1],[1,1,1,1,1,1]]
1
0

You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's (representing civilians). The soldiers are positioned in front of the civilians. That is, all the 1's will appear to the left of all the 0's in each row.

A row i is weaker than a row j if one of the following is true:

The number of soldiers in row i is less than the number of soldiers in row j.
Both rows have the same number of soldiers and i < j.
Return the indices of the k weakest rows in the matrix ordered from weakest to strongest.


Example 1:

Input: mat = 
[[1,1,0,0,0],
 [1,1,1,1,0],
 [1,0,0,0,0],
 [1,1,0,0,0],
 [1,1,1,1,1]], 
k = 3
Output: [2,0,3]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 2 
- Row 1: 4 
- Row 2: 1 
- Row 3: 2 
- Row 4: 5 
The rows ordered from weakest to strongest are [2,0,3,1,4].
Example 2:

Input: mat = 
[[1,0,0,0],
 [1,1,1,1],
 [1,0,0,0],
 [1,0,0,0]], 
k = 2
Output: [0,2]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 1 
- Row 1: 4 
- Row 2: 1 
- Row 3: 1 
The rows ordered from weakest to strongest are [0,2,3,1].

*/
#endregion