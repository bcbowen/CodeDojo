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
	public int[] FindOrder(int numCourses, int[][] prerequisites)
	{
		/*
		if (prerequisites == null ||
			prerequisites.Length == 0 ||
			prerequisites[0].Length == 0) return new int[] { 0 };
			
			*/

		Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
		for (int i = 0; i < numCourses; i++)
		{
			adjacencyList.Add(i, new List<int>());
		}

		foreach (int[] prereq in prerequisites)
		{
			if (prereq.Length == 2) adjacencyList[prereq[0]].Add(prereq[1]);
		}

		int[] order = new int[numCourses];

		for (int i = 0; i < numCourses; i++)
		{
			int nextCourse = -1;
			for (int j = 0; j < numCourses; j++)
			{
				if (adjacencyList.ContainsKey(j) && adjacencyList[j].Count == 0)
				{
					nextCourse = j;
					break;
				}
			}
			if (nextCourse == -1) return new int[0];

			for (int j = 0; j < numCourses; j++)
			{
				if (j == nextCourse || !adjacencyList.ContainsKey(j)) continue;

				if (adjacencyList[j].Contains(nextCourse)) adjacencyList[j].Remove(nextCourse);
			}
			adjacencyList.Remove(nextCourse);
			order[i] = nextCourse;
		}

		return order;
	}

}

/*
Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

Example 3:
Input: numCourses = 1, prerequisites = []
Output: [0]

2
[]
*/

[Theory]
[InlineData(new[] { 0, 1 }, 2, new[] { 1, 0 })]
[InlineData(new[] { 0, 1, 2, 3 }, 4, new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 1 }, new[] { 3, 2 })]
[InlineData(new int[] { 0 }, 1, new int[0])]
[InlineData(new int[] { 0, 1 }, 2, new int[0])]

void Test(int[] expected, int numCourses, params int[][] prereqs)
{
	int[] result = new Solution().FindOrder(numCourses, prereqs);
	Assert.Equal(expected, result);
}
