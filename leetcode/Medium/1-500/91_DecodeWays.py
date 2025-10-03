import pytest

class Solution:
    def __init__(self) -> None:
        self.letter_map = {str(i): chr(64 + i) for i in range(1, 27)}

    def numDecodings(self, s: str) -> int:
        if not s or s[0] == '0':
            return 0

        n = len(s)
        dp = [0] * (n + 1)
        dp[0] = 1  # Base case: empty string has one way to decode
        dp[1] = 1  # First character is guaranteed to be valid (not '0')

        for i in range(2, n + 1): 
            one_digit = s[i-1:i]  # Single digit
            two_digit = s[i-2:i]  # Two digits

            if one_digit in self.letter_map:
                dp[i] += dp[i - 1]
            if two_digit in self.letter_map:
                dp[i] += dp[i - 2]
        return dp[n]
    
"""
Example 1:

Input: s = "12"
Output: 2
Explanation:
"12" could be decoded as "AB" (1 2) or "L" (12).

Example 2:
Input: s = "226"
Output: 3
Explanation:
"226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).

Example 3:
Input: s = "06"
Output: 0
Explanation:
"06" cannot be mapped to "F" because of the leading zero ("6" is different from "06"). In this case, the string is not a valid encoding, so return 0.

"""
@pytest.mark.parametrize("s, expected", [
    ("12", 2), 
    ("226", 3), 
    ("06", 0), 
])
def test_numDecodings(s, expected):
    solution = Solution()
    assert solution.numDecodings(s) == expected

@pytest.mark.parametrize("key, expected", [
    ('1', 'A'), 
    ('7', 'G'), 
    ('16', 'P'), 
    ('26', 'Z')
])
def test_letter_map(key: str, expected: str): 
    solution = Solution()
    val = solution.letter_map[key]
    assert val == expected
    

if __name__ == "__main__":
    pytest.main([__file__])