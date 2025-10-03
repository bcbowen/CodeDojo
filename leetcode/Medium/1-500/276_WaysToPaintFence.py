import pytest

class Solution:
    
    def __init__(self):
        self.cache = {} 
    
    def numWays(self, n: int, k: int) -> int:
        
        if n == 0:
            return 0
        if n == 1:
            return k
        if n == 2:
            return k * k
        
        self.cache[1] = k
        self.cache[2] = k * k

        if not n - 1 in self.cache:
            self.cache[n - 1] = self.numWays(n - 1, k)

        if not n - 2 in self.cache:
            self.cache[n - 2] = self.numWays(n - 2, k)

        return self.cache[n - 1] * (k - 1) + self.cache[n - 2] * (k - 1)    


"""
Example 1:
Input: n = 3, k = 2
Output: 6
Explanation: All the possibilities are shown.
Note that painting all the posts red or all the posts green is invalid because there cannot be three posts in a row with the same color.

Example 2:
Input: n = 1, k = 1
Output: 1

Example 3:
Input: n = 7, k = 2
Output: 42
"""

@pytest.mark.parametrize("n, k, expected", [
    (3, 2, 6),
    (1, 1, 1),
    (7, 2, 42),
    (5, 3, 180),
    (0, 3, 0),
    (2, 4, 16),
])
def test_numWays(n: int, k: int, expected: int):
    result = Solution().numWays(n, k)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])