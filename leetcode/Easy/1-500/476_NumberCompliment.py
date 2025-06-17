import pytest

class Solution:
    def findComplement(self, num: int) -> int:
        mask = 1
        result = 0
        while mask < num: 
            result += mask & (num ^ mask) 
            mask <<= 1
        return result
    

"""
Example 1:

Input: num = 5
Output: 2
Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output 2.
Example 2:

Input: num = 1
Output: 0
Explanation: The binary representation of 1 is 1 (no leading zero bits), and its complement is 0. So you need to output 0.
"""
@pytest.mark.parametrize("num, expected", [
    (5, 2), 
    (1, 0)
])
def test_findComplement(num: int, expected: int):
    result = Solution().findComplement(num)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
