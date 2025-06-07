import pytest
from collections import deque
from typing import List 

class Solution:
    

    def islandPerimeter(self, grid: List[List[int]]) -> int:
        seen = set()
        q = deque()
        perimeter = 0
        
        def is_inbounds(row: int, col: int) -> bool: 
            if row < 0 or row >= len(grid): 
                return False
            if col < 0 or col >= len(grid[0]): 
                return False 
            return True
        
        # n e s w
        directions = [(-1, 0),(0, 1),(1, 0),(0, -1)]

        for row in range(len(grid)):
            for col in range(len(grid[0])): 
                if grid[row][col] == 1: 
                    q.append((row, col))
                    seen.add((row, col))
                    break
            if q: 
                break
        while q: 
            current_row, current_col = q.popleft()
            for dy, dx in directions: 
                next_row, next_col = current_row + dy, current_col + dx
                if not is_inbounds(next_row, next_col) or grid[next_row][next_col] == 0: 
                    perimeter += 1
                elif is_inbounds(next_row, next_col) and not (next_row, next_col) in seen: 
                    seen.add((next_row, next_col))
                    q.append((next_row, next_col))
        return perimeter
"""
Example 1:
Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
Output: 16
Explanation: The perimeter is the 16 yellow stripes in the image above.

Example 2:
Input: grid = [[1]]
Output: 4

Example 3:
Input: grid = [[1,0]]
Output: 4

"""
@pytest.mark.parametrize("grid, expected", [
    ([[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]], 16), 
    ([[1]], 4), 
    ([[1,0]], 4)
])
def test_islandPerimeter(grid: List[List[int]], expected: int):
    result = Solution().islandPerimeter(grid)
    assert(result == expected)

    

if __name__ == "__main__":
    pytest.main([__file__])