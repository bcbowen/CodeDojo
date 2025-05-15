import pytest
import numpy
import re

class Solution:
    def isPowerOfThree(self, n: int) -> bool:
        ternary = numpy.base_repr(n, base=3)
        pattern = r"^10*$"
        return re.match(pattern, ternary) is not None
      

"""
Example 1:
Input: n = 27
Output: true
Explanation: 27 = 33

Example 2:
Input: n = 0
Output: false
Explanation: There is no x where 3x = 0.

Example 3:
Input: n = -1
Output: false
Explanation: There is no x where 3x = (-1).
"""
@pytest.mark.parametrize("n, expected", [
    (27, True), 
    (0, False),
    (-1, False), 
    (15, False), 
    (-3, False), 
    (-9, False)
])
def test_isPowerOfThree(n: int, expected: bool):
    result = Solution().isPowerOfThree(n)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])