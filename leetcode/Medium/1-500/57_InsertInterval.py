import pytest
from typing import List


class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        result = []

        # if new interval comes before the first interval, we can prepend
        if newInterval[1] < intervals[0][0]: 
            return self.prepend(intervals, newInterval)
        
        # if new interval comes after the last interval, we can append
        if newInterval[0] > intervals[-1][1]: 
            return self.append(intervals, newInterval)

        return self.merge(intervals, newInterval)


    
    def prepend(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        if newInterval[1] > intervals[0][0]: 
            return self.merge(intervals, newInterval)
        return [newInterval] + intervals
    
    def append(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        if newInterval[0] < intervals[-1][1]: 
            return self.merge(intervals, newInterval)
        return intervals + [newInterval]

    def merge(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        in_progress = False
        begin = -1
        result = []
        for interval in intervals: 
            if in_progress: 
                if interval[0] > newInterval[1]: 
                    result.append([begin, newInterval[1]])
                    result.append(interval)
                    in_progress = False
                    begin = -1
                elif interval[1] >= newInterval[1]:
                    result.append([begin, interval[1]])
                    begin = -1
                    in_progress = False                   
            else: 
                if newInterval[0] < interval[1] and newInterval[1] >= interval[0]: 
                    in_progress = True
                    begin = min(newInterval[0], interval[0])
                    if newInterval[1] <= interval[1]: 
                        result.append([begin, interval[1]])
                        begin = -1
                        in_progress = False
                else: 
                    result.append(interval)

        return result


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
@pytest.mark.skip()
@pytest.mark.parametrize("intervals, newInterval, expected", [
     ([[4, 6], [11, 15], [20, 25]], [1,3], [[1, 3], [4, 6], [11, 15], [20, 25]]), 
     
     ([[4, 6], [11, 15], [20, 25]], [1,4], [[1, 6], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,5], [[1, 6], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,6], [[1, 6], [11, 15], [20, 25]]), 


     ([[4, 6], [11, 15], [20, 25]], [1, 10], [[1, 10], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1, 11], [[1, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,21], [[1, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1, 30], [[1, 30]]), 
     ([[4, 6], [11, 15], [20, 25]], [7, 8], [[4, 6], [7, 8], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [4, 8], [[4, 8], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [5, 8], [[4, 8], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [6, 8], [[4, 8], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [8, 12], [[4, 6], [8, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [8, 16], [[4, 6], [8, 16], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [8, 20], [[4, 6], [8, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 19], [[4, 6], [11, 15], [17, 19], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,3], [[1, 3], [4, 6], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [17, 20], [[4, 6], [11, 15], [17, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 22], [[4, 6], [11, 15], [17, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 25], [[4, 6], [11, 15], [17, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [26, 30], [[1, 3], [4, 6], [11, 15], [20, 25], [26, 30]])
])
def test_insert(intervals: List[List[int]], newInterval: List[int], expected: List[List[int]]):
    result = Solution().insert(intervals, newInterval)
    assert(expected == result)

@pytest.mark.parametrize("intervals, newInterval, expected", [
     ([[4, 6], [11, 15], [20, 25]], [1,3], [[1, 3], [4, 6], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,2], [[1, 2], [4, 6], [11, 15], [20, 25]]), 
])
def test_prepend(intervals: List[List[int]], newInterval: List[int], expected: List[List[int]]):
    result = Solution().insert(intervals, newInterval)
    assert(expected == result)

@pytest.mark.parametrize("intervals, newInterval, expected", [
     ([[4, 6], [11, 15], [20, 25]], [26, 30], [[4, 6], [11, 15], [20, 25], [26, 30]]),
    ([[4, 6], [11, 15], [20, 25]], [56, 80], [[4, 6], [11, 15], [20, 25], [56, 80]])
])
def test_append(intervals: List[List[int]], newInterval: List[int], expected: List[List[int]]):
    result = Solution().insert(intervals, newInterval)
    assert(expected == result)

@pytest.mark.parametrize("intervals, newInterval, expected", [
     ([[4, 6], [11, 15], [20, 25]], [1,4], [[1, 6], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,5], [[1, 6], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,6], [[1, 6], [11, 15], [20, 25]]), 


     ([[4, 6], [11, 15], [20, 25]], [1, 10], [[1, 10], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1, 11], [[1, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,21], [[1, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1, 30], [[1, 30]]), 
     ([[4, 6], [11, 15], [20, 25]], [7, 8], [[4, 6], [7, 8], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [4, 8], [[4, 8], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [5, 8], [[4, 8], [11, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [6, 8], [[4, 8], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [8, 12], [[4, 6], [8, 15], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [8, 16], [[4, 6], [8, 16], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [8, 20], [[4, 6], [8, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 19], [[4, 6], [11, 15], [17, 19], [20, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [1,3], [[1, 3], [4, 6], [11, 15], [20, 25]]), 

     ([[4, 6], [11, 15], [20, 25]], [17, 20], [[4, 6], [11, 15], [17, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 22], [[4, 6], [11, 15], [17, 25]]), 
     ([[4, 6], [11, 15], [20, 25]], [17, 25], [[4, 6], [11, 15], [17, 25]])
])
def test_merge(intervals: List[List[int]], newInterval: List[int], expected: List[List[int]]):
    result = Solution().insert(intervals, newInterval)
    assert(expected == result)




if __name__ == "__main__": 
    pytest.main([__file__])