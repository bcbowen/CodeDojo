import pytest
from typing import List

class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        intervals.sort()
        merged = []
        start = intervals[0][0]
        end = intervals[0][1]
        for i in range(1, len(intervals)): 
            if end < intervals[i][0]: 
                end = max(end, intervals[i - 1][1])
                merged.append([start, end])
                start = intervals[i][0]
                end = intervals[i][1]
        end = max(end, intervals[-1][1])
        merged.append([start, end])

        return merged

"""
Example 1:
Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

Example 1a:
Input: intervals = [[8,10],[15,18],[2,6],[1,3]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Same as 1, making sure we get the same result when input is out of order

Example 2:
Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.

TC 119: 
intervals: [[1,4],[2,3]]
expected: [[1,4]]

TC 122: 
intervals: [[2,3],[4,5],[6,7],[8,9],[1,10]]
expected: [[1,10]]

TC 47: 
intervals: [[1,4],[0,2],[3,5]]
Expected: [[0,5]]
"""
@pytest.mark.parametrize("intervals, expected", [
    ([[1,3],[2,6],[8,10],[15,18]], [[1,6],[8,10],[15,18]]), 
    ([[8,10],[15,18],[2,6],[1,3]], [[1,6],[8,10],[15,18]]), 
    ([[1,4],[4,5]], [[1,5]]), 
    ([[1,4],[2,3]], [[1,4]]), 
    ([[2,3],[4,5],[6,7],[8,9],[1,10]], [[1,10]]), 
    ([[1,4],[0,2],[3,5]], [[0,5]])
])
def test_merge(intervals: List[List[int]], expected: List[List[int]]):
    result = Solution().merge(intervals)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])