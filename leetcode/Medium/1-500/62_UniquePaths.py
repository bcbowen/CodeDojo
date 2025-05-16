import pytest

class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        dp = [[col for col in range(m)] for row in range(n)]
        
        for row in range(n): 
            for col in range(m):
                val = 0
                if row == 0 and col == 0: 
                    val = 1
                else: 
                    if row > 0: 
                        val += dp[row - 1][col]
                    if col > 0: 
                        val += dp[row][col - 1]
                dp[row][col] = val
        return dp[-1][-1]


"""
Ex1: 
Input: m = 3, n = 7
Output: 28
Example 2:

Input: m = 3, n = 2
Output: 3
Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Down -> Down
2. Down -> Down -> Right
3. Down -> Right -> Down
"""
@pytest.mark.parametrize("rows, cols, expected", [
    (3, 7, 28), 
    (3, 2, 3)
])
def test_uniquePaths(rows: int, cols: int, expected: int):
    result = Solution().uniquePaths(rows, cols)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 