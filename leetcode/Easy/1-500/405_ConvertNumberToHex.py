import pytest

class Solution:
    def toHex(self, num: int) -> str:
        if num == 0: 
            return '0'
        if num < 0: 
            num = (1 << 32) + num

        hex_digits = "0123456789abcdef"
        remaining = num
        result = ''
        while remaining: 
            remainder = remaining % 16
            result = hex_digits[remainder] + result
            remaining //= 16
        return result

"""
Example 1:
Input: num = 26
Output: "1a"

Example 2:
Input: num = -1
Output: "ffffffff"

Decimal	32-bit Binary (truncated)	Hexadecimal	Notes
+0	00000000 00000000 00000000 00000000	0x00000000	Zero
+1	00000000 00000000 00000000 00000001	0x00000001	
+123	00000000 00000000 00000000 01111011	0x0000007B	
+2147483647	01111111 11111111 11111111 11111111	0x7FFFFFFF	Max 32-bit signed int
-1	11111111 11111111 11111111 11111111	0xFFFFFFFF	2s complement of +1
-2	11111111 11111111 11111111 11111110	0xFFFFFFFE	2s complement of +2
-123	11111111 11111111 11111111 10000101	0xFFFFFF85	2s complement of +123

"""
@pytest.mark.parametrize("num, expected", [
    (26, "1a"), 
    (-1, "ffffffff"), 
    (0, "0"), 
    (1, "1"), 
    (123, "7b"),
    (2147483647, "7fffffff"),
    (-2, "fffffffe"),
    (-123, "ffffff85"), 
    (-2147483648, "80000000")
])
def test_toHex(num: int, expected: str):
    result = Solution().toHex(num)
    assert(result == expected)    

if __name__ == "__main__":
    pytest.main([__file__]) 