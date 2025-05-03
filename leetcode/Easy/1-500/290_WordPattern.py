import pytest

class Solution:
    def wordPattern(self, pattern: str, s: str) -> bool:
        word_map = {}
        words = s.split(' ')
        if len(words) != len(pattern): 
            return False 
        
        for i in range(len(pattern)): 
            if not pattern[i] in word_map: 
                if words[i] in word_map.values(): 
                    return False
                word_map[pattern[i]] = words[i]
            else: 
                if word_map[pattern[i]] != words[i]: 
                    return False
        return True

"""
Example 1:
Input: pattern = "abba", s = "dog cat cat dog"
Output: true

Explanation:

The bijection can be established as:

'a' maps to "dog".
'b' maps to "cat".

Example 2:
Input: pattern = "abba", s = "dog cat cat fish"

Output: false

Example 3:
Input: pattern = "aaaa", s = "dog cat cat dog"

Output: false
"""
@pytest.mark.parametrize("pattern, s, expected", [
    ("abba", "dog cat cat dog", True), 
    ("abba", "dog dog dog dog", False), 
    ("abba", "dog cat cat fish", False), 
    ("aaaa", "dog cat cat dog", False), 
    ("aaa", "aa aa aa aa", False)
])
def test_wordPattern(pattern: str, s: str, expected: bool):
    result = Solution().wordPattern(pattern, s)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 