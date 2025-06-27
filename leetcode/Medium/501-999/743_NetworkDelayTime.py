import heapq
import math
import pytest
from collections import deque, defaultdict
from typing import List

class Solution:
    def networkDelayTime(self, times: List[List[int]], n: int, k: int) -> int:
        graph = defaultdict(list)
        for start, end, time in times: 
            graph[start - 1].append((end - 1, time))
        distances = [math.inf] * n
        distances[k - 1] = 0
        heap = [(0, k - 1)]
        while heap: 
            total_dist, node = heapq.heappop(heap)
            if total_dist > distances[node]: 
                continue
            for end, dist in graph[node]:
                new_dist = dist + total_dist
                if new_dist < distances[end]: 
                    distances[end] = new_dist
                    heapq.heappush(heap, (new_dist, end))
        result = max(distances)
        return int(result) if result < math.inf else -1

"""
Example 1
Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
Output: 2

Example 2:
Input: times = [[1,2,1]], n = 2, k = 1
Output: 1

Example 3:
Input: times = [[1,2,1]], n = 2, k = 2
Output: -1
"""
@pytest.mark.parametrize("times, n, k, expected", [
    ([[2,1,1],[2,3,1],[3,4,1]], 4, 2, 2), 
    ([[1,2,1]], 2, 1, 1), 
    ([[1,2,1]], 2, 2, -1)
])
def test_networkDelayTime(times: List[List[int]], n: int, k: int, expected: int):
    result = Solution().networkDelayTime(times, n, k)
    assert(result == expected)
    

if __name__ == "__main__":
    pytest.main([__file__]) 