import pytest

class Solution:
    def reverseBits(self, n: int) -> int:
        ret, power = 0, 31
        while n:
            ret += (n & 1) << power
            n = n >> 1
            power -= 1
        return ret
"""
Example 1:
Input: n = 00000010100101000001111010011100
Output:    964176192 (00111001011110000010100101000000)
Explanation: The input binary string 00000010100101000001111010011100 represents the unsigned integer 43261596, so return 964176192 which its binary representation is 00111001011110000010100101000000.

Example 2:
Input: n = 11111111111111111111111111111101
Output:   3221225471 (10111111111111111111111111111111)
Explanation: The input binary string 11111111111111111111111111111101 represents the unsigned integer 4294967293, so return 3221225471 which its binary representation is 10111111111111111111111111111111.

"""
@pytest.mark.parametrize("n, expected", [
    (0b00000010100101000001111010011100, 0b00111001011110000010100101000000), 
    (0b11111111111111111111111111111101, 0b10111111111111111111111111111111)
])
def test_reverseBits(n: int, expected: int):
    result = Solution().reverseBits(n)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 