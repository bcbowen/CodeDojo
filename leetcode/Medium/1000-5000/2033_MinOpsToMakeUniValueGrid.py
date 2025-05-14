import pytest 
from typing import List

class Solution:
    def minOperations(self, grid: List[List[int]], x: int) -> int:
        if len(grid) == 1 and len(grid[0]) == 1: 
            return 0

        # if a solution is possible, each value must be divisible by x
        total_sum = 0
        total_count = len(grid) * len(grid[0])
        for row in grid: 
            total_sum += sum(row)
            for val in row: 
                if val % x != 0: 
                    return -1
        avg = total_sum // total_count
        min_cell = (0, 0)
        min_diff = float('inf')

        for row in range(len(grid)): 
            for col in range(len(grid[0])):
                val = grid[row][col] 
                diff = abs(avg - val)
                if diff < min_diff: 
                    min_diff = diff
                    min_cell = (row, col)
        op_count = 0
        target_value = grid[min_cell[0]][min_cell[1]]
        for row in range(len(grid)): 
            for col in range(len(grid[0])):
                if (row, col) == min_cell: 
                    continue
                val = grid[row][col] 
                while val < target_value: 
                    op_count += 1
                    val += x
                while val > target_value: 
                    op_count += 1
                    val -= x
        return op_count

"""
Example 1:
Input: grid = [[2,4],[6,8]], x = 2
Output: 4
Explanation: We can make every element equal to 4 by doing the following: 
- Add x to 2 once.
- Subtract x from 6 once.
- Subtract x from 8 twice.
A total of 4 operations were used.

Example 2:
Input: grid = [[1,5],[2,3]], x = 1
Output: 5
Explanation: We can make every element equal to 3.

Example 3:
Input: grid = [[1,2],[3,4]], x = 2
Output: -1
Explanation: It is impossible to make every element equal.

"""
@pytest.mark.parametrize("grid, x, expected", [
    ([[2,4],[6,8]], 2, 4), 
    ([[1,5],[2,3]], 1, 5), 
    ([[1,2],[3,4]], 2, -1), 
    ([[146]], 86, 0)
])
def test_minOperations(grid: List[List[int]], x: int, expected: int):
    result = Solution().minOperations(grid, x)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 