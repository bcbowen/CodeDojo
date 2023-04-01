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
		List<IList<int>> adjacencyList = new List<IList<int>>();
		int target = 0;
		for (int i = 0; i < graph.Length; i++)
		{
			adjacencyList.Add(new List<int>());
			List<int> list = adjacencyList[i] as List<int>;
			if (graph[i] != null && graph[i].Length > 0)
			{
				list.AddRange(graph[i]);
				target = Math.Max(target, list.Max()); 
			}
		}

		List<IList<int>> result = new List<IList<int>>();

		Queue<List<int>> paths = new Queue<List<int>>();
		foreach (int i in graph[0])
		{
			paths.Enqueue(new List<int>(new []{ 0,  i }));
		}
		while(paths.Count > 0) 
		{
			List<int> list = paths.Dequeue();
			int last = list.Last(); 
			if (last == target)
			{
				result.Add(list); 
			}
			else
			{
				foreach(int next in adjacencyList[last]) 
				{
					List<int> newPath = new List<int>(); 
					newPath.AddRange(list); 
					newPath.Add(next); 
					paths.Enqueue(newPath); 
				}
			}
		}
		
		return result;
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

	List<IList<int>> expected = new List<IList<int>>();
	expected.Add(new List<int> {0, 1, 3});
	expected.Add(new List<int> { 0, 2, 3 });
	Assert.Equal(expected.Count, result.Count);
	for (int i = 0; i < expected.Count; i++) 
	{
		Assert.Equal(expected[i].Count, result[i].Count);
		for (int j = 0; j < expected[i].Count; j++) 
		{
			Assert.Equal(expected[i][j], result[i][j]);
		}
	}
}


[Fact]
void Test2()
{
	int[][] graph = new int[][]
	{
		new []{4, 3, 1},
		new []{3, 2, 4},
		new []{3},
		new []{4},
		new int[0]
	};
	IList<IList<int>> result = new Solution().AllPathsSourceTarget(graph);

	List<IList<int>> expected = new List<IList<int>>();
	expected.Add(new List<int> { 0, 4 });
	expected.Add(new List<int> { 0, 3, 4 });
	expected.Add(new List<int> { 0, 1, 4 });
	expected.Add(new List<int> { 0, 1, 3, 4 });
	expected.Add(new List<int> { 0, 1, 2, 3, 4 });
	
	Assert.Equal(expected.Count, result.Count);
	for (int i = 0; i < expected.Count; i++)
	{
		Assert.Equal(expected[i].Count, result[i].Count);
		for (int j = 0; j < expected[i].Count; j++)
		{
			Assert.Equal(expected[i][j], result[i][j]);
		}
	}
}
