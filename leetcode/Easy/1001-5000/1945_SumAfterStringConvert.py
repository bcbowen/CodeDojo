import pytest

class Solution:
    def getLucky(self, s: str, k: int) -> int:
        vals = ""
        for c in s: 
            vals += str(ord(c) - ord('a') + 1)

        sum = 0
        for i in range(k): 
            sum = 0 
            for c in vals: 
                sum += int(c)
            vals = str(sum)
        return sum
"""
Example 1:
Input: s = "iiii", k = 1
Output: 36
Explanation: The operations are as follows:
- Convert: "iiii" ➝ "(9)(9)(9)(9)" ➝ "9999" ➝ 9999
- Transform #1: 9999 ➝ 9 + 9 + 9 + 9 ➝ 36
Thus the resulting integer is 36.

Example 2:
Input: s = "leetcode", k = 2
Output: 6
Explanation: The operations are as follows:
- Convert: "leetcode" ➝ "(12)(5)(5)(20)(3)(15)(4)(5)" ➝ "12552031545" ➝ 12552031545
- Transform #1: 12552031545 ➝ 1 + 2 + 5 + 5 + 2 + 0 + 3 + 1 + 5 + 4 + 5 ➝ 33
- Transform #2: 33 ➝ 3 + 3 ➝ 6
Thus the resulting integer is 6.

Example 3:
Input: s = "zbax", k = 2
Output: 8
"""

@pytest.mark.parametrize("s, k, expected", [
    ("iiii", 1, 36),
    ("leetcode", 2, 6),
    ("zbax", 2, 8)
])
def test_getLucky(s: str, k: int, expected: int):
    result = Solution().getLucky(s, k)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])