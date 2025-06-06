import pytest

class Solution:
    def ladderLength(self, beginWord: str, endWord: str, wordList: List[str]) -> int:
        pass

def test_ladderLength(beginWord: str, endWord: str, wordList: List[str], expected int):
    result = Solution().ladderLength(beginWord, endWord, wordList)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 