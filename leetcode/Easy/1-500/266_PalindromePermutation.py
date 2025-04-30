import pytest
from collections import defaultdict

class Solution:
    def canPermutePalindrome(self, s: str) -> bool:
        char_counts = defaultdict(int)
        evens = 0
        odds = 0
        for c in s: 
            char_counts[c] += 1
            if char_counts[c] == 1: 
                odds += 1
            elif char_counts[c] % 2 == 0: 
                odds -= 1
                evens += 1
            else: 
                odds += 1
                evens -= 1
        return odds < 2
"""
Example 1:
Input: s = "code"
Output: false

Example 2:
Input: s = "aab"
Output: true

Example 3:
Input: s = "carerac"
Output: true
"""
@pytest.mark.parametrize("s, expected", [
    ("code", False), 
    ("aab", True), 
    ("carerac", True)
])
def test_canPermutePalindrome(s: str, expected: bool):
    result = Solution().canPermutePalindrome(s)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 