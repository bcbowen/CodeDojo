
import pytest


class Solution:
    def bitwiseComplement(self, n: int) -> int:
        if n == 0: 
            return 1
        
        result = 0
        
        next = 1
        while n > 0: 
            if (n & 1) == 0: 
                result |= next
            next *= 2
            n >>= 1
        return result
    

"""
Example 1:
Input: n = 5
Output: 2
Explanation: 5 is "101" in binary, with complement "010" in binary, which is 2 in base-10.

Example 2:
Input: n = 7
Output: 0
Explanation: 7 is "111" in binary, with complement "000" in binary, which is 0 in base-10.

Example 3:
Input: n = 10
Output: 5
Explanation: 10 is "1010" in binary, with complement "0101" in binary, which is 5 in base-10.
"""
@pytest.mark.parametrize("n, expected", [
    (5, 2),
    (7, 0),
    (10, 5)
])
def test_bitwiseComplement(n: int, expected: int):
    result = Solution().bitwiseComplement(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 