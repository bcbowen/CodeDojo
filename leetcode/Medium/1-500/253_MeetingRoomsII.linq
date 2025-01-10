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
	public int MinMeetingRooms(int[][] intervals)
	{
		PriorityQueue<int[], int> startTimes = new PriorityQueue<int[], int>();
		PriorityQueue<int, int> endTimes = new PriorityQueue<int, int>();

		foreach(int[] interval in intervals)
		{
			startTimes.Enqueue(interval, interval[0]);
		}
		
		int concurrentMeetingCount = 0;
		while(startTimes.Count > 0)
		{
			int[] interval = startTimes.Dequeue();
			while (endTimes.Count > 0 && endTimes.Peek() <= interval[0]) 
			{
				endTimes.Dequeue();
			}
			endTimes.Enqueue(interval[1], interval[1]);
			concurrentMeetingCount = Math.Max(concurrentMeetingCount, endTimes.Count);
			
		}
		return concurrentMeetingCount;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(2, new[] {0,30}, new[] {5,10}, new[] {15,20})]
[InlineData(1, new[] {7,10}, new[] {2,4})]
[InlineData(1, new[] {13,15}, new[] {1,13})]
void TestAllocation(int expected, params int[][] intervals)
{
	int result = new Solution().MinMeetingRooms(intervals);
	Assert.Equal(expected, result);
}

/*
Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], return the minimum number of conference rooms required.

 Input:
[[13,15],[1,13]]
Output:
2
Expected:
1

Example 1:

Input: intervals = [[0,30],[5,10],[15,20]]
Output: 2
Example 2:

Input: intervals = [[7,10],[2,4]]
Output: 1
 
*/
#endregion