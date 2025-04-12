import pytest
from typing import List


class Solution:
    def minimumEffortPath(self, heights: List[List[int]]) -> int:
        def is_valid(y: int, x: int) -> bool:
            if y < 0 or y >= len(heights):
                return False
            if x < 0 or x >= len(heights[0]):
                return False
            return True

        def check(effort : int) -> bool:
            # N E S W
            directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]
            stack = [(0, 0)]
            seen = set()
            while stack:
                row, col = stack.pop()
                if row == len(heights) - 1 and col == len(heights[0]) - 1:
                  return True
                seen.add((row, col))
                for dy, dx in directions:
                  next = (row + dy, col + dx)
                  if is_valid(next[0], next[1]) and not next in seen and abs(heights[row][col] - heights[next[0]][next[1]]) <= effort:
                      stack.append(next)
            return False

        left = 0
        right = max(max(row) for row in heights)
        while left <= right:
            mid = (left + right) // 2
            if check(mid):
                right = mid - 1
            else:
                left = mid + 1

        return left

"""
Input: heights = [[1,2,2],[3,8,2],[5,3,5]]
Output: 2
Explanation: The route of [1,3,5,3,5] has a maximum absolute difference of 2 in consecutive cells.
This is better than the route of [1,2,2,2,5], where the maximum absolute difference is 3.

Example 2:
Input: heights = [[1,2,3],[3,8,4],[5,3,5]]
Output: 1
Explanation: The route of [1,2,3,4,5] has a maximum absolute difference of 1 in consecutive cells, which is better than route [1,3,5,3,5].

Example 3:
Input: heights = [[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]]
Output: 0
Explanation: This route does not require any effort.
"""
@pytest.mark.parametrize("heights, expected", [
    ([[1,2,2],[3,8,2],[5,3,5]], 2),
    ([[1,2,3],[3,8,4],[5,3,5]], 1),
    ([[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]], 0)
])
def test_minimumEffortPath(heights: List[List[int]], expected: int):
    result = Solution().minimumEffortPath(heights)
    assert(result == expected)

if __name__ == "__main__":
  pytest.main([__file__])