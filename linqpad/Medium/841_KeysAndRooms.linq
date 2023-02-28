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
	public bool CanVisitAllRooms(IList<IList<int>> rooms)
	{
		Stack<int> keys = new Stack<int>();
		bool[] visited = new bool[rooms.Count]; 
		keys.Push(0);
		while (keys.Count > 0)
		{
			int key = keys.Pop();
			foreach (int k in rooms[key])
			{
				if (!visited[key]) 
				{
					keys.Push(k);	
				}
			}
			visited[key] = true;
		}
		return visited.All(r => r == true);
	}
}

#region private::Tests

[Theory]
[InlineData(true, new[] { 1 }, new[] { 2 }, new[] { 3 }, new int[0])]
[InlineData(false, new[] { 1, 3 }, new[] { 3, 0, 1 }, new[] { 2 }, new[] { 0 })]
[InlineData(true, new[] { 2 }, new int [0], new[] { 1 })]
void Test(bool expected, params int[][] rooms)
{
	bool result = new Solution().CanVisitAllRooms(rooms);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: rooms = [[1],[2],[3],[]]
Output: true
Explanation: 
We visit room 0 and pick up key 1.
We then visit room 1 and pick up key 2.
We then visit room 2 and pick up key 3.
We then visit room 3.
Since we were able to visit every room, we return true.

Example 2:
Input: rooms = [[1,3],[3,0,1],[2],[0]]
Output: false
Explanation: We can not enter room number 2 since the only key that unlocks it is in that room.
*/


#endregion