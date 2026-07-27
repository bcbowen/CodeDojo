from typing import List

import pytest

class Solution:
    def reverseSubmatrix(self, grid: List[List[int]], top: int, left: int, k: int) -> List[List[int]]:
        if k < 2: 
            return grid
        
        bottom = top + k - 1
        right = left + k

        for x in range(left, right): 
            y1 = top
            y2 = bottom
            while y1 < y2: 
                grid[y2][x], grid[y1][x] = grid[y1][x], grid[y2][x]
                y1 += 1
                y2 -= 1
        return grid
    
"""
Example 1:
Input: grid = [[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]], x = 1, y = 0, k = 3
Output: [[1,2,3,4],[13,14,15,8],[9,10,11,12],[5,6,7,16]]
Explanation:
The diagram above shows the grid before and after the transformation.

Example 2:
Input: grid = [[3,4,2,3],[2,3,4,2]], x = 0, y = 2, k = 2
Output: [[3,4,4,2],[2,3,2,3]]
Explanation:
The diagram above shows the grid before and after the transformation.

TC 316
grid = [[4,20,8,20],[2,16,3,12],[3,12,17,1],[3,13,2,13]]
x = 1
y = 1
k = 1

Use Testcase
Output
[[4,20,8,20],[2,13,3,12],[3,12,17,1],[3,16,2,13]]
Expected
[[4,20,8,20],[2,16,3,12],[3,12,17,1],[3,13,2,13]]

"""
@pytest.mark.parametrize("grid, row, col, k, expected", [
    ([[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]], 1, 0, 3, [[1,2,3,4],[13,14,15,8],[9,10,11,12],[5,6,7,16]]), 
    ([[3,4,2,3],[2,3,4,2]], 0, 2, 2, [[3,4,4,2],[2,3,2,3]]), 
    ([[4,20,8,20],[2,16,3,12],[3,12,17,1],[3,13,2,13]], 1, 1, 1, [[4,20,8,20],[2,16,3,12],[3,12,17,1],[3,13,2,13]])
])
def test_reverseSubmatrix(grid: List[List[int]], row: int, col: int, k: int, expected: List[List[int]]):
    result = Solution().reverseSubmatrix(grid, row, col, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 