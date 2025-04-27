import pytest
from typing import List

class Solution:
    def shortestDistance(self, wordsDict: List[str], word1: str, word2: str) -> int:
        waiting1 = False 
        waiting2 = False
        currentCount = 0
        min_distance = len (wordsDict)
        for word in wordsDict: 
            if waiting1 or waiting2: 
                currentCount += 1
            if word == word1: 
                
                if waiting1: 
                    min_distance = min(min_distance, currentCount)
                    waiting1 = False
            
                waiting2 = True
                currentCount = 0
            elif word == word2: 
                if waiting2: 
                    min_distance = min(min_distance, currentCount)
                    waiting2 = False
                    currentCount = 0
            
                waiting1 = True
                currentCount = 0
        return min_distance
"""
Example 1:
Input: wordsDict = ["practice", "makes", "perfect", "coding", "makes"], word1 = "coding", word2 = "practice"
Output: 3

Example 2:
Input: wordsDict = ["practice", "makes", "perfect", "coding", "makes"], word1 = "makes", word2 = "coding"
Output: 1
"""
@pytest.mark.parametrize("wordsDict, word1, word2, expected", [
    (["practice", "makes", "perfect", "coding", "makes"], "coding", "practice", 3), 
    (["practice", "makes", "perfect", "coding", "makes"], "makes", "coding", 1)
])
def test_shortestDistance(wordsDict: List[str], word1: str, word2: str, expected: int):
    result = Solution().shortestDistance(wordsDict, word1, word2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 