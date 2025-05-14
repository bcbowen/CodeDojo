import pytest
from typing import List

class Solution:
    def countDays(self, days: int, meetings: List[List[int]]) -> int:
        meetings.sort()
        free_days = 0
        latest_end = 0
        for start, end in meetings: 
            if start > latest_end + 1: 
                free_days += start - latest_end - 1
            
            latest_end = max(end, latest_end)

        free_days += days - latest_end
        return free_days

"""
Example 1:
Input: days = 10, meetings = [[5,7],[1,3],[9,10]]
Output: 2
Explanation:
There is no meeting scheduled on the 4th and 8th days.

Example 2:
Input: days = 5, meetings = [[2,4],[1,3]]
Output: 1
Explanation:
There is no meeting scheduled on the 5th day.

Example 3:
Input: days = 6, meetings = [[1,6]]
Output: 0
Explanation:
Meetings are scheduled for all working days.

"""
@pytest.mark.parametrize("days, meetings, expected", [
    (10, [[5,7],[1,3],[9,10]], 2), 
    (5, [[2,4],[1,3]],1), 
    (6, [[1,6]],0)
])
def test_countDays(days: int, meetings: List[List[int]], expected: int):
    result = Solution().countDays(days, meetings)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])