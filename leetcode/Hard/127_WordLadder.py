import pytest
from collections import deque
from typing import List

class Solution:
    def ladderLength(self, beginWord: str, endWord: str, wordList: List[str]) -> int:
        if not endWord in wordList: 
            return 0
        def diff_count(w1: str, w2: str): 
            count = 0
            for i in range(len(w1)): 
                if w1[i] != w2[i]: 
                    count += 1
            return count 
        
        q = deque()
        q.append(([beginWord], wordList))

        while q: 
            used_words, remaining_words = q.popleft()
            last_word = used_words[-1]
            for wi in range(len(remaining_words)): 
                if diff_count(remaining_words[wi], last_word) == 1:
                    if remaining_words[wi] == endWord: 
                        return len(used_words) + 1
                    
                    new_words = used_words.copy()
                    new_remaining = remaining_words.copy()
                    new_words.append(remaining_words[wi])
                    del new_remaining[wi]
                    q.append((new_words, new_remaining)) 
        return 0
"""
Example 1:
Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
Output: 5
Explanation: One shortest transformation sequence is "hit" -> "hot" -> "dot" -> "dog" -> cog", which is 5 words long.

Example 2:
Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
Output: 0
Explanation: The endWord "cog" is not in wordList, therefore there is no valid transformation sequence.
"""
@pytest.mark.parametrize("beginWord, endWord, wordList, expected", [
    ("hit", "cog", ["hot","dot","dog","lot","log","cog"], 5), 
    ("hit", "cog", ["hot","dot","dog","lot","log"], 0)
])
def test_ladderLength(beginWord: str, endWord: str, wordList: List[str], expected: int):
    result = Solution().ladderLength(beginWord, endWord, wordList)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 