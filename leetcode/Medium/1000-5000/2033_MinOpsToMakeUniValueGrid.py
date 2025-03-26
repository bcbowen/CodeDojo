import pytest 
from typing import List

class Solution:
    def minOperations(self, grid: List[List[int]], x: int) -> int:
        # if a solution is possible, each value must be divisible by x
        total_sum = 0
        total_count = len(grid) * len(grid[0])
        for row in grid: 
            total_sum += sum(row)
            for val in row: 
                if val % x != 0: 
                    return -1
        avg = total_sum // total_count
        


def test_minOperations(grid: List[List[int]], x: int, expected: int):
    result = Solution().minOperations(grid, x)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 