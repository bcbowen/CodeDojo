from typing import List

import pytest

class Solution:
    

    def is_match(self, start: int, word: str, phrase: str) -> bool: 
        current = start
        for i in range(len(word)): 
            if current >= len(phrase) or phrase[current] != word[i]: 
                return False
            current += 1
        return True 
    
    def indexPairs(self, text: str, words: List[str]) -> List[List[int]]:
        matches = [] 
        for i in range(len(text)): 
            for word in words: 
                if self.is_match(i, word, text): 
                    matches.append([i, i + len(word) - 1])

        matches.sort(key=lambda m: (m[0], m[1]))
        return matches


@pytest.mark.parametrize("start, word, phrase, expected", [
    (6, "test", "thisisatest", False), 
    (7, "test", "thisisatest", True), 
    (7, "testicles", "thisisatest", False),
    (10, "test", "thisisatest", False), 
    (0, "test", "thisisatest", False), 
    (7, "tesm", "thisisatest", False), 
])
def test_is_match(start: int, word: str, phrase: str, expected: bool): 
    result = Solution().is_match(start, word, phrase)
    assert(result == expected)

"""
Example 1:
Input: text = "thestoryofleetcodeandme", words = ["story","fleet","leetcode"]
Output: [[3,7],[9,13],[10,17]]

Example 2:
Input: text = "ababa", words = ["aba","ab"]
Output: [[0,1],[0,2],[2,3],[2,4]]
Explanation: Notice that matches can overlap, see "aba" is found in [0,2] and [2,4].
"""
@pytest.mark.parametrize("text, words, expected", [
    ("thestoryofleetcodeandme", ["story","fleet","leetcode"], [[3,7],[9,13],[10,17]]),
    ("ababa", ["aba","ab"], [[0,1],[0,2],[2,3],[2,4]])   
])
def test_index_pairs(text: str, words: List[str], expected: List[List[int]]): 
    result = Solution().indexPairs(text, words)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 