import pytest
from typing import List

class Solution:
    def answerString(self, word: str, numFriends: int) -> str:
        box = set()
        max_len = len(word) - numFriends + 1
        def backtrack(sections: List[str], word_index: int, letter_index: int): 
            nonlocal word
            if word_index < numFriends - 1 and letter_index >= len(word) - 1:
                return 
            elif word_index == numFriends - 1 and letter_index >= len(word) - 1: 
                for section in sections: 
                    box.add(section)
                return 
            word = sections[word_index]
            while len(word) <= max_len: 
                word += word[letter_index]
                letter_index += 1
                new_sections = sections.copy()
                new_sections[word_index] = word
                backtrack(sections, word_index, letter_index)
                if word_index < len(sections) - 1:
                    backtrack(sections, word_index + 1, letter_index) 
        sections = ["" for _ in range(numFriends)]
        backtrack(sections, 0, 0)
        words = list(box)
        words.sort()
        return words[-1]


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
"""
@pytest.mark.parametrize("word, numFriends, expected", [
    ("dbca", 2, "dbc"), 
    ("gggg", 1, "g")
])
def test_answerString(word: str, numFriends: int, expected: str):
    result = Solution().answerString(word, numFriends)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 