import pytest
import math

class Solution:
    def isPowerOfTwo(self, n: int) -> bool:
        if n < 1: 
            return False
     
        l = math.log2(n)        
        return l.is_integer()
"""
Example 1:
Input: n = 1
Output: true
Explanation: 20 = 1

Example 2:
Input: n = 16
Output: true
Explanation: 24 = 16

Example 3:
Input: n = 3
Output: false
"""
@pytest.mark.parametrize("n, expected", [
    (1, True), 
    (16, True), 
    (3, False), 
    (6, False)
])
def test_isPowerOfTwo(n: int, expected: bool):
    result = Solution().isPowerOfTwo(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 