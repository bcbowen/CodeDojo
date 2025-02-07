import pytest
from collections import defaultdict

class Solution:
    def canConstruct(self, ransomNote: str, magazine: str) -> bool:
        magazine_char_counts = defaultdict(int)
        for c in magazine: 
            magazine_char_counts[c] += 1

        for c in ransomNote: 
            if not c in magazine_char_counts or magazine_char_counts[c] < 1: 
                return False
            magazine_char_counts[c] -= 1

        return True


"""
Example 1:
Input: ransomNote = "a", magazine = "b"
Output: false

Example 2:
Input: ransomNote = "aa", magazine = "ab"
Output: false

Example 3:
Input: ransomNote = "aa", magazine = "aab"
Output: true
"""
@pytest.mark.parametrize("ransomNote, magazine, expected", [
    ("a", "b", False),
    ("aa", "ab", False),
    ("aa", "aab", True) 
])
def test_canConstruct(ransomNote: str, magazine: str, expected: bool):
    sol = Solution() 
    result = sol.canConstruct(ransomNote, magazine)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])