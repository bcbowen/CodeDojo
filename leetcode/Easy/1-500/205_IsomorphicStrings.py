import pytest

class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        if len(s) != len(t): 
            return False
        
        char_map = {}
        for i in range(len(s)):
            if not s[i] in char_map: 
                if t[i] in char_map.values(): 
                    return False
                char_map[s[i]] = t[i]
            else: 
                if char_map[s[i]] != t[i]:
                    return False
         
        return True
    
"""
Example 1:
Input: s = "egg", t = "add"
Output: true

Explanation:

The strings s and t can be made identical by:

Mapping 'e' to 'a'.
Mapping 'g' to 'd'.

Example 2:
Input: s = "foo", t = "bar"
Output: false

Explanation:

The strings s and t can not be made identical as 'o' needs to be mapped to both 'a' and 'r'.

Example 3:
Input: s = "paper", t = "title"
Output: true

s: "badc"; t: "baba"; Expected: false

"""
@pytest.mark.parametrize("s, t, expected", [
    ("egg", "add", True), 
    ("foo", "bar", False), 
    ("paper", "title", True), 
    ("badc", "baba", False)
])
def test_isIsomorphic(s: str, t: str, expected: bool):
    result = Solution().isIsomorphic(s, t)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])