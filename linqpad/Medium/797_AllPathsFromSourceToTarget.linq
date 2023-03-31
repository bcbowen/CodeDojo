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
	public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
	{
		List<List<int>> adjacencyList = new List<List<int>>();
		
		for (int i = 0; i < graph.Length; i++) 
		{
			adjacencyList.Add(new List<int>());
		}

		List<List<int>> result = new List<List<int>>();
		
		
	}
	
	
	
	
}


/*

Input: graph = [[1,2],[3],[3],[]]
Output: [[0,1,3],[0,2,3]]
Explanation: There are two paths: 0 -> 1 -> 3 and 0 -> 2 -> 3.

Input: graph = [[4,3,1],[3,2,4],[3],[4],[]]
Output: [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]

*/

[Fact]
void Test1()
{
	int[][] graph = new int[][]
	{
		new []{1, 2},
		new []{3},
		new []{3},
		new int[0]
	};
	IList<IList<int>> result = new Solution().AllPathsSourceTarget(graph);

	List<List<int>> expected = new List<List<int>>();
	expected.Add(new List<int> {0, 1, 3});
	expected.Add(new List<int> { 0, 2, 3 });
	foreach (IList<int> path in result) 
	{
		Assert.True(expected.Contains(path));
	}
}


[Fact]
void Test2()
{

}
