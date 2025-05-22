import pytest
from typing import List

class Solution:
    def minFallingPathSum(self, matrix: List[List[int]]) -> int:
        rows = len(matrix)
        cols = len(matrix[0])
        dp = [[float('inf') for _ in range(cols)] for _ in range(rows)]

        for col in range(cols):
            dp[0][col] = matrix[0][col]
        
        for row in range(1, rows): 
            for col in range(cols): 
                # previous val can be up left, up, or up right
                prev_val = dp[row - 1][col]
                if col > 0: 
                    prev_val = min(prev_val, dp[row - 1][col - 1])
                if col < len(matrix[0]) - 1:
                    prev_val = min(prev_val, dp[row - 1][col + 1])
                dp[row][col] = matrix[row][col] + prev_val
        return int(min(dp[-1]))

"""

Example 1:
Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
Output: 13
Explanation: There are two falling paths with a minimum sum as shown.

Example 2:
Input: matrix = [[-19,57],[-40,-5]]
Output: -59
Explanation: The falling path with a minimum sum is shown.

"""
@pytest.mark.parametrize("matrix, expected", [
     ([[2,1,3],[6,5,4],[7,8,9]], 13), 
     ([[-19,57],[-40,-5]], -59)
])
def test_minFallingPathSum(matrix: List[List[int]], expected: int):
    result = Solution().minFallingPathSum(matrix)
    assert(result == expected) 

if __name__ == "__main__": 
    pytest.main([__file__])