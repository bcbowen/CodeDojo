import pytest
from collections import deque

class Solution:
    # N E S W
    directions = [(-1, 0), (0, 1), (1, 0), (0, -1)]
    def maxAreaOfIsland(self, grid: list[list[int]]) -> int:
        max_size = 0
        size = 0
        seen = set() 
        queue : tuple[int, int] = deque()

        def is_valid(row: int, col: int) -> bool: 
            if row < 0 or row >= len(grid): 
                return False
            if col < 0 or col >= len(grid[0]):
                return False
            return True 

        for row in range(len(grid)): 
            for col in range(len(grid[row])): 
                if grid[row][col] == 1 and not (row, col) in seen:
                    queue.append((row, col))
                    seen.add((row, col))
                    while queue:  
                        row, col = queue.popleft()
                        size += 1
                        for dy, dx in Solution.directions: 
                            nextY = row + dy
                            nextX = col + dx
                            if is_valid(nextY, nextX) and grid[nextY][nextX] == 1 and not (nextY, nextX) in seen: 
                                seen.add((nextY, nextX))
                                queue.append((nextY, nextX))
                    max_size = max(max_size, size)
                    size = 0
        return max_size


"""
Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]
Output: 6
Explanation: The answer is not 11, because the island must be connected 4-directionally.
Example 2:

Input: grid = [[0,0,0,0,0,0,0,0]]
Output: 0
"""
@pytest.mark.parametrize("grid, expected", [
    ([[0,0,1,0,0,0,0,1,0,0,0,0,0],
      [0,0,0,0,0,0,0,1,1,1,0,0,0],
      [0,1,1,0,1,0,0,0,0,0,0,0,0],
      [0,1,0,0,1,1,0,0,1,0,1,0,0],
      [0,1,0,0,1,1,0,0,1,1,1,0,0],
      [0,0,0,0,0,0,0,0,0,0,1,0,0],
      [0,0,0,0,0,0,0,1,1,1,0,0,0],
      [0,0,0,0,0,0,0,1,1,0,0,0,0]], 6), 
    ([[0,0,0,0,0,0,0,0]], 0)
])
def test_maxAreaOfIsland(grid: list[list[int]], expected: int):
    result = Solution().maxAreaOfIsland(grid)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])