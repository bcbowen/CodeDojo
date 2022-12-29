namespace LeetCode.Solutions.P00253_MeetingRoomsII;

public class Solution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        PriorityQueue<int[], int> startTimes = new PriorityQueue<int[], int>();
        PriorityQueue<int, int> endTimes = new PriorityQueue<int, int>();

        foreach (int[] interval in intervals)
        {
            startTimes.Enqueue(interval, interval[0]);
        }

        int concurrentMeetingCount = 0;
        while (startTimes.Count > 0)
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