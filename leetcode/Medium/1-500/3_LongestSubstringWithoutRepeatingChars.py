import pytest

class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        if s == None: 
            return 0
        i = 0
        chars = set()
        longest = 0
        current = 0 
        for i in range(len(s)):
            for j in range(i, len(s)): 
                c = s[j]
                if not c in chars: 
                    current += 1
                    chars.add(c)
                else: 
                    chars.clear()
                    longest = max(current, longest)
                    current = 0
                    break
        longest = max(current, longest)
        return longest
    
"""
Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    
"""
@pytest.mark.parametrize("val, expected", [
    ("abcabcbb", 3),
    ("bbbbb", 1),
    ("pwwkew", 3), 
    (" ", 1), 
    ("dvdf", 3), 
    (None, 0), 
    ("", 0)
])
def test_lengthOfLongestSubstring(val: str, expected: int):
    sol = Solution() 
    result = sol.lengthOfLongestSubstring(val)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])