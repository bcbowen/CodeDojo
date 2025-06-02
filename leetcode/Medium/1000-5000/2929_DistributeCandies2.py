import pytest

class Solution:
    def distributeCandies(self, n: int, limit: int) -> int:
        pass

"""
Example 1:
Input: n = 5, limit = 2
Output: 3
Explanation: There are 3 ways to distribute 5 candies such that no child gets more than 2 candies: (1, 2, 2), (2, 1, 2) and (2, 2, 1).

Example 2:
Input: n = 3, limit = 3
Output: 10
Explanation: There are 10 ways to distribute 3 candies such that no child gets more than 3 candies: (0, 0, 3), (0, 1, 2), (0, 2, 1), (0, 3, 0), (1, 0, 2), (1, 1, 1), (1, 2, 0), (2, 0, 1), (2, 1, 0) and (3, 0, 0).
"""
@pytest.mark.parametrize("", [
    (), 
])
def test_distributeCandies(n: int, limit: int, expected: int):
    result = Solution().distributeCandies(n, limit)
    assert(result == expected)    

if __name__ == "__main__":
    pytest.main([__file__]) 