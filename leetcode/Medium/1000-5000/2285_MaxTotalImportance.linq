<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public long MaximumImportance(int n, int[][] roads)
{
	Dictionary<int, int> counts = new Dictionary<int, int>(); 
}

/*
Input: n = 5, roads = [[0,1],[1,2],[2,3],[0,2],[1,3],[2,4]]
Output: 43

Input: n = 5, roads = [[0,3],[2,4],[1,3]]
Output: 20
*/

[Theory]
[InlineData(5, 43, new[] { 0, 1 }, new[] { 1, 2 }, new[] { 2, 3 }, new[] { 0, 2 }, new[] { 1, 3 }, new[] { 2, 4 })]
[InlineData(5, 20, new[] { 0, 3 }, new[] { 2, 4 }, new[] { 1, 3 })]
void Test(int n, long expected, params int[][] roads)
{
	long result = MaximumImportance(n, roads);
	Assert.Equal(expected, result); 
}
