import pytest
from typing import List

class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:
        m = len(obstacleGrid)
        n = len(obstacleGrid[0])
        dp = [[-1 for _ in range(n)] for _ in range(m)]
        
        for row in range(m): 
            for col in range(n):
                val = 0
                if obstacleGrid[row][col] == 1: 
                    val = 0
                elif row == 0 and col == 0: 
                    val = 1
                else: 
                    if row > 0: 
                        val += dp[row - 1][col]
                    if col > 0: 
                        val += dp[row][col - 1]
                dp[row][col] = val
        return dp[-1][-1]

"""
Example 1:
Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
Output: 2
Explanation: There is one obstacle in the middle of the 3x3 grid above.
There are two ways to reach the bottom-right corner:
1. Right -> Right -> Down -> Down
2. Down -> Down -> Right -> Right

Example 2:
Input: obstacleGrid = [[0,1],[0,0]]
Output: 1
"""
@pytest.mark.parametrize("obstacleGrid, expected", [
    ([[0,0,0],[0,1,0],[0,0,0]], 2), 
    ([[0,1],[0,0]], 1), 
    ([[0, 0]], 1)
])
def test_uniquePathsWithObstacles(obstacleGrid: List[List[int]], expected: int):
    result = Solution().uniquePathsWithObstacles(obstacleGrid)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 