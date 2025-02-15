import pytest

class Solution:
    def isPowerOfFour(self, n: int) -> bool:
        if n == 1: 
            return True
        elif n < 0 or n % 2 != 0: 
            return False
        
        val = 4
        for i in range(16):
            if val == n: 
                return True
            if val > n: 
                return False
            val *= 4
        return False


"""
Example 1:
Input: n = 16
Output: true

Example 2:
Input: n = 5
Output: false

Example 3:
Input: n = 1
Output: true
"""
@pytest.mark.parametrize("n, expected", [
    (16, True),
    (2, False),
    (1, True)
])
def test_isPowerOfFour(n: int, expected: bool):
    sol = Solution()
    result = sol.isPowerOfFour(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])