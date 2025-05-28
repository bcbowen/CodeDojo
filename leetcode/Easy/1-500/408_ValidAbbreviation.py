import pytest

class Solution:
    def validWordAbbreviation(self, word: str, abbr: str) -> bool:
        i = 0
        while i < len(word): 
            j = i
            jump = 0
            while j < len(abbr) and abbr[j].isdigit(): 
                j += 1
            if j > i:
                jump = int(word[i:j - 1])
                i += jump
                jump = 0
                if i >= len(word): 
                    return False
            if word[i] != abbr[i]: 
                return False
            i += 1 
        return True

"""
Example 1:
Input: word = "internationalization", abbr = "i12iz4n"
Output: true
Explanation: The word "internationalization" can be abbreviated as "i12iz4n" ("i nternational iz atio n").

Example 2:
Input: word = "apple", abbr = "a2e"
Output: false
Explanation: The word "apple" cannot be abbreviated as "a2e".
"""
@pytest.mark.parametrize("word, abbr, expected", [
    ("internationalization", "i12iz4n", True), 
    ("apple", "a2e", False)
])
def test_validWordAbbreviation(word: str, abbr: str, expected: bool):
    result = Solution().validWordAbbreviation(word, abbr)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])