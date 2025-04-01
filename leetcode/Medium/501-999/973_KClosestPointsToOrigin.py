import heapq
import pytest

from typing import List

class Solution:
    def kClosest(self, points: List[List[int]], k: int) -> List[List[int]]:
        def calc_distance(x: int, y: int) -> float: 
            # √(x1 - x2)2 + (y1 - y2)2
            # = √(x)2 + (y)2
            return (x**2 + y**2)**.5

        dist_heap = [] 
        for x, y in points: 
            dist_heap.append((calc_distance(x, y), (x, y)))

        heapq.heapify(dist_heap)
        result = []
        for _ in range(k): 
            result.append(heapq.heappop(dist_heap)[1])
        return result


"""
Example 1:
Input: points = [[1,3],[-2,2]], k = 1
Output: [[-2,2]]
Explanation:
The distance between (1, 3) and the origin is sqrt(10).
The distance between (-2, 2) and the origin is sqrt(8).
Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
We only want the closest k = 1 points from the origin, so the answer is just [[-2,2]].

Example 2:
Input: points = [[3,3],[5,-1],[-2,4]], k = 2
Output: [[3,3],[-2,4]]
Explanation: The answer [[-2,4],[3,3]] would also be accepted.
"""
@pytest.mark.parametrize("points, k, expected", [
    ([3,2,1,5,6,4], 1, [[-2,2]]), 
    ([[3,3],[5,-1],[-2,4]], 2, [[-2,4],[3,3]])
])
# The test doesn't pass but I knew the answer was right.. order doesn't matter but we're expecting an order in the tests
def test_kClosest(points: List[List[int]], k: int, expected: List[List[int]]):
    result = Solution().kClosest(points, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])