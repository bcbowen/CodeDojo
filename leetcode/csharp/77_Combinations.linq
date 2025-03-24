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
	private int _n; 
    private int _k; 
    private List<IList<int>> _output = new List<IList<int>>();

	public IList<IList<int>> Combine(int n, int k)
	{
		_n = n; 
		_k = k; 
		Backtrack(1, new List<int>()); 
		return _output;
	}

    internal void Backtrack(int first, List<int> curr)
    {
        if (curr.Count == _k)
        {
			List<int> newList = new List<int>(); 
			newList.AddRange(curr);
			_output.Add(newList);
        }

        for (int i = first; i < _n + 1; i++)
        {
            curr.Add(i); 
			Backtrack(i + 1, curr);
			curr.RemoveAt(curr.Count - 1);
        }
    }
}


/*
Example 1:
Input: n = 4, k = 2
Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
Explanation: There are 4 choose 2 = 6 total combinations.
Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.

Example 2:
Input: n = 1, k = 1
Output: [[1]]
Explanation: There is 1 choose 1 = 1 total combination.
*/

[Theory]
[InlineData(4, 2, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 1, 4 }, new[] { 2, 3 }, new[] { 2, 4 }, new[] { 3, 4 })]
[InlineData(1, 1, new[] { 1 })]
[InlineData(2, 1, new[] { 1 }, new[] { 2 })]
void Test(int n, int k, params int[][] expected)
{
	IList<IList<int>> result = new Solution().Combine(n, k);
	Assert.Equal(expected, result);
}
