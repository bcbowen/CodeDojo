import pytest
from typing import List

class Solution:
    def canAttendMeetings(self, intervals: List[List[int]]) -> bool:
        intervals.sort(key=lambda x: x[0])
        for i in range(1, len(intervals)): 
            if intervals[i][0] < intervals[i - 1][1]:
                return False
            
        return True

"""
Example 1:
Input: intervals = [[0,30],[5,10],[15,20]]
Output: false

Example 2:
Input: intervals = [[7,10],[2,4]]
Output: true

"""
@pytest.mark.parametrize("intervals, expected", [
    ([[0,30],[5,10],[15,20]], False), 
    ([[7,10],[2,4]], True), 
    ([[7, 10]], True), 
    ([[6,15],[13,20],[6,17]], False), 
    ([[19,20],[1,10],[5,14]], False), 
    ([[13,15],[1,13]], True)
])
def test_canAttendMeetings(intervals: List[List[int]], expected: bool):
    result = Solution().canAttendMeetings(intervals)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])