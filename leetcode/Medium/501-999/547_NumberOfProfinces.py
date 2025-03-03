import pytest

class Solution:
    def findCircleNum(self, isConnected: list[list[int]]) -> int:
        pass

"""
Example 1:
Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2

Example 2:
Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
"""
@pytest.mark.parametrize("isConnected, expected", [
    ([[1,1,0],[1,1,0],[0,0,1]], 2), 
    ([[1,0,0],[0,1,0],[0,0,1]], 3)
])
def test_findCircleNum(isConnected: list[list[int]], expected: int):
    result = Solution().findCircleNum(isConnected)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 