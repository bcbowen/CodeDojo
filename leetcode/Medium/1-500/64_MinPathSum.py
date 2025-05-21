import pytest
from collections import deque
from typing import List

class Solution:
    def minPathSum(self, grid: List[List[int]]) -> int:
        m = len(grid)
        n = len(grid[0])
        dp = [[0 for _ in range(n)] for _ in range(m)]
        dp[0][0] = grid[0][0]
        for row in range(m): 
            for col in range(n): 
                if row + col == 0: 
                    continue
                ans = float('inf')
                if col > 0: 
                    ans = min(ans, dp[row][col - 1])
                if row > 0: 
                    ans = min(ans, dp[row - 1][col])
                dp[row][col] = int(grid[row][col] + ans)
        return dp[m - 1][n - 1]


    def minPathSum_1(self, grid: List[List[int]]) -> int:
        result_grid = [[float('inf') for _ in range(len(grid[0]))] for _ in range(len(grid))]
        
        # E S only valid directions are E and S
        directions = [(0, 1), (1, 0)]
        def is_valid(y: int, x: int) -> bool: 
            if y >= len(grid) or x >= len(grid[0]):
                return False
            return True
        q = deque([(0, 0, grid[0][0])])
        while q: 
            y, x, dist = q.popleft()
            result_grid[y][x] = min(result_grid[y][x], dist)
            for d in directions: 
                next_y = y + d[0]
                next_x = x + d[1]
                if is_valid(next_y, next_x): 
                    next_dist = dist + grid[next_y][next_x]
                    q.append((next_y, next_x, next_dist))
        return int(result_grid[-1][-1])
"""
Example 1: 
Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
Output: 7
Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.

Example 2:
Input: grid = [[1,2,3],[4,5,6]]
Output: 12

TC 21: 
[[7,1,3,5,8,9,9,2,1,9,0,8,3,1,6,6,9,5],[9,5,9,4,0,4,8,8,9,5,7,3,6,6,6,9,1,6],[8,2,9,1,3,1,9,7,2,5,3,1,2,4,8,2,8,8],[6,7,9,8,4,8,3,0,4,0,9,6,6,0,0,5,1,4],[7,1,3,1,8,8,3,1,2,1,5,0,2,1,9,1,1,4],[9,5,4,3,5,6,1,3,6,4,9,7,0,8,0,3,9,9],[1,4,2,5,8,7,7,0,0,7,1,2,1,2,7,7,7,4],[3,9,7,9,5,8,9,5,6,9,8,8,0,1,4,2,8,2],[1,5,2,2,2,5,6,3,9,3,1,7,9,6,8,6,8,3],[5,7,8,3,8,8,3,9,9,8,1,9,2,5,4,7,7,7],[2,3,2,4,8,5,1,7,2,9,5,2,4,2,9,2,8,7],[0,1,6,1,1,0,0,6,5,4,3,4,3,7,9,6,1,9]]
"""
@pytest.mark.parametrize("grid, expected", [
    ([[1,3,1],[1,5,1],[4,2,1]], 7), 
    ([[1,2,3],[4,5,6]], 12), 
    ([
        [7,1,3,5,8,9,9,2,1,9,0,8,3,1,6,6,9,5],
        [9,5,9,4,0,4,8,8,9,5,7,3,6,6,6,9,1,6],
        [8,2,9,1,3,1,9,7,2,5,3,1,2,4,8,2,8,8],
        [6,7,9,8,4,8,3,0,4,0,9,6,6,0,0,5,1,4],
        [7,1,3,1,8,8,3,1,2,1,5,0,2,1,9,1,1,4],
        [9,5,4,3,5,6,1,3,6,4,9,7,0,8,0,3,9,9],
        [1,4,2,5,8,7,7,0,0,7,1,2,1,2,7,7,7,4],
        [3,9,7,9,5,8,9,5,6,9,8,8,0,1,4,2,8,2],
        [1,5,2,2,2,5,6,3,9,3,1,7,9,6,8,6,8,3],
        [5,7,8,3,8,8,3,9,9,8,1,9,2,5,4,7,7,7],
        [2,3,2,4,8,5,1,7,2,9,5,2,4,2,9,2,8,7],
        [0,1,6,1,1,0,0,6,5,4,3,4,3,7,9,6,1,9]
    ], 85)
])
def test_minPathSum(grid: List[List[int]], expected: int):
    result = Solution().minPathSum(grid)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])