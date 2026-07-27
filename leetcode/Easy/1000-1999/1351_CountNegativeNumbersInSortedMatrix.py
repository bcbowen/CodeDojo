import pytest
from typing import List

class Solution:
    def countNegatives(self, grid: List[List[int]]) -> int:
        count = 0
        for row in range(len(grid)): 
            if grid[row][0] < 0: 
                count += (len(grid) - row) * len(grid[0])
                break
            else: 
                for col in range(len(grid[row])): 
                    if grid[row][col] < 0: 
                        count += len(grid[row]) - col
                        break
        return count
    
"""
Example 1:
Input: grid = [[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]
Output: 8
Explanation: There are 8 negatives number in the matrix.

Example 2:
Input: grid = [[3,2],[1,0]]
Output: 0
"""
@pytest.mark.parametrize("grid, expected", [
    ([[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]], 8), 
    ([[3,2],[1,0]], 0)
])
def test_countNegatives(grid: List[List[int]], expected: int):
    result = Solution().countNegatives(grid)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 