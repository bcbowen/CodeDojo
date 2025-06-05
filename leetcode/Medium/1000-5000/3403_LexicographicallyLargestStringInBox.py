import pytest
from typing import List

class Solution:
    # This works but returns MLE for test case 775: 
    def answerString_1(self, word: str, numFriends: int) -> str:
        if numFriends == 1: 
            return word
        
        max_len = len(word) - numFriends + 1
        sections = []
        i = 0
        j = 1
        while i < len(word): 
            while j <= len(word) and j <= i + max_len: 
                sections.append(word[i:j])
                j += 1
            i += 1
            j = i + 1
        sections.sort()
        return sections[-1]
    
    def answerString(self, word: str, numFriends: int) -> str:
        if numFriends == 1: 
            return word
        # Find the max char
        max_char = word[0]
        max_len = len(word) - numFriends + 1
        for i in range(len(word)): 
            if word[i] > max_char: 
                max_char = word[i]
        # Find the indexes of max char in case it appears multiple times in the string
        max_char_indexes = [] 
        for i in range(len(word)): 
            if word[i] == max_char: 
                max_char_indexes.append(i)
        # For each index, store the max word that can be created from that position - either max length or to the end of the string
        sections = [] 
        for i in max_char_indexes: 
            if i + max_len > len(word): 
                sections.append(word[i:])
            else:
                sections.append(word[i:i + max_len])
        sections.sort()
        return sections[-1]

"""
Example 1:
Input: word = "dbca", numFriends = 2
Output: "dbc"
Explanation: 
All possible splits are:
"d" and "bca".
"db" and "ca".
"dbc" and "a".

Example 2:
Input: word = "gggg", numFriends = 4
Output: "g"
Explanation: 
The only possible split is: "g", "g", "g", and "g".

TC 684: 
Input: word = "gh", numFriends = 1
Output: "gh"


"""
@pytest.mark.parametrize("word, numFriends, expected", [
    ("dbca", 2, "dbc"), 
    ("gggg", 4, "g"), 
    ("gh", 1, "gh")
])
def test_answerString(word: str, numFriends: int, expected: str):
    result = Solution().answerString(word, numFriends)
    assert(result == expected)

"""
TC 775: (MLE)
word =
(5000 'a's followed by 'z')
numFriends =
2

"""

def test_TC775MLE():
    word = 'a' * 5000 + 'z'
    numFriends = 2
    result = Solution().answerString(word, numFriends)
    expected = 'z'
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 