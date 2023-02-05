using LeetCode.Solutions.P00253_MeetingRoomsII;

namespace Medium;

public class Tests
{
    [TestCase(2, new[] { 0, 30 }, new[] { 5, 10 }, new[] { 15, 20 })]
    [TestCase(1, new[] { 7, 10 }, new[] { 2, 4 })]
    [TestCase(1, new[] { 13, 15 }, new[] { 1, 13 })]
    public void TestAllocation(int expected, params int[][] intervals)
    {
        int result = new Solution().MinMeetingRooms(intervals);
        Assert.That(result, Is.EqualTo(expected));
    }

}