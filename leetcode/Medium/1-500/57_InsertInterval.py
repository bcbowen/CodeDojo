import pytest
from typing import List


class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        result = []

        begin = -1 
        end = -1

        for interval in intervals: 
            begin = 

    # first attempt, doesn't work
    def insert_1(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        result = []

        if newInterval[1] < intervals[0][0]: 
            result.append(newInterval)
            result.extend(intervals)
        elif newInterval[0] > intervals[-1][1]: 
            result.extend(intervals)
            result.append(newInterval)
        else: 
            i = 0
            while intervals[i][1] < newInterval[0]: 
                result.append(intervals[i])
                i += 1
            interval = intervals[i]
            if newInterval[1] < interval[0]: 
                result.append(newInterval)
                result.extend(intervals[i:])
            else: 
                begin = newInterval[0]
                while i < len(intervals) and intervals[i][1] < newInterval[1]:
                    i += 1
                if i < len(intervals): 
                    end = intervals[i][1]
                    result.append([begin, end])
                    result.extend(intervals[i + 1:])
                else: 
                    end = max(newInterval[1], intervals[-1][1])
                    result.append([begin, end])
 
        return result
    
"""
Example 1:
Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]

Example 2:
Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
"""
@pytest.mark.parametrize("intervals, newInterval, expected", [
     ([[1,3],[6,9]], [2,5], [[1,5],[6,9]]), 
     ([[1,2],[3,5],[6,7],[8,10],[12,16]], [4,8], [[1,2],[3,10],[12,16]]), 
     ([[4, 6], [7, 8], [9, 12]], [1, 2], [[1, 2], [4, 6], [7, 8], [9, 12]]), 
     ([[5, 6], [7, 8], [10, 12]], [1, 9], [[1, 9], [10, 12]]),
     ([[1,3],[6,9]], [10,12], [[1,3],[6,9],[10,12]]), 
])
def test_insert(intervals: List[List[int]], newInterval: List[int], expected: List[List[int]]):
    result = Solution().insert(intervals, newInterval)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])