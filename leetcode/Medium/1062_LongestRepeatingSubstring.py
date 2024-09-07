import pytest

class Solution:
    def longestRepeatingSubstring(self, s: str) -> int:
        substrings = {}
        size = len(s) - 1
        maxLen = 0
        while(size > 0):
            l = 0
            r = l + size - 1
            
            while r < len(s): 
                ss = s[l: r + 1]
                if not ss in substrings: 
                    substrings[ss] = 0
                substrings[ss] += 1
                if substrings[ss] > 1 and len(ss) > maxLen: 
                    maxLen = len(ss)
                l += 1
                r += 1
            size -= 1
        
        return maxLen
        

"""
Given a string s, return the length of the longest repeating substrings. If no repeating 
substring exists, return 0.


Example 1:
Input: s = "abcd"
Output: 0
Explanation: There is no repeating substring.

Example 2:
Input: s = "abbaba"
Output: 2
Explanation: The longest repeating substrings are "ab" and "ba", each of which occurs twice.

Example 3:
Input: s = "aabcaabdaab"
Output: 3
Explanation: The longest repeating substring is "aab", which occurs 3 times.
"""

@pytest.mark.parametrize("s, expected", [
    ("abcd", 0),
    ("abbaba", 2),
    ("aabcaabdaab", 3), 
    ("aaaaa", 4)
])
def test_longestRepeatingSubstring(s: str, expected: int):
    result = Solution().longestRepeatingSubstring(s)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])