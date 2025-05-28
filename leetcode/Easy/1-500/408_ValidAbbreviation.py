import pytest
import re

class Solution:
    def validWordAbbreviation(self, word: str, abbr: str) -> bool:
        pattern = r"\d+|[a-z]+"

        i = 0
        for group in re.findall(pattern, abbr): 
            if group[0].isdigit():
                if group[0] == '0': 
                    return False
                i += int(group)
                if i > len(word): 
                    return False
            else: 
                for j in range(len(group)):
                    if i == len(word): 
                        return False 
                    if word[i] != group[j]: 
                        return False
                    i += 1
        
        return i == len(word)

"""
Example 1:
Input: word = "internationalization", abbr = "i12iz4n"
Output: true
Explanation: The word "internationalization" can be abbreviated as "i12iz4n" ("i nternational iz atio n").

Example 2:
Input: word = "apple", abbr = "a2e"
Output: false
Explanation: The word "apple" cannot be abbreviated as "a2e".

TC9: 
word = "abbde" abbr = "a1b01e" expected: False

TC11: 
word = "a" abbr = "2" expected: False

TC14: 
word = "hi" abbr = "2i" expected False (RTE)

TC173: 
word = "internationalization" abbr = "i5a11o1" expected: True

TC318: 
word = "hi" abbr = "1" expected: False

"""
@pytest.mark.parametrize("word, abbr, expected", [
    ("internationalization", "i12iz4n", True), 
    ("apple", "a2e", False), 
    ("abbde", "a1b01e", False), 
    ("a", "2", False), 
    ("internationalization", "i5a11o1", True),
    ("hi", "2i", False), 
    ("hi", "1", False)
])
def test_validWordAbbreviation(word: str, abbr: str, expected: bool):
    result = Solution().validWordAbbreviation(word, abbr)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])