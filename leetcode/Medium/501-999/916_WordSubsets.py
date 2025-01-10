import pytest
from collections import defaultdict

"""
For example, "wrr" is a subset of "warrior" but is not a subset of "world".

Example 1:
Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 = ["e","o"]
Output: ["facebook","google","leetcode"]

Example 2:
Input: words1 = ["amazon","apple","facebook","google","leetcode"], words2 = ["l","e"]
Output: ["apple","google","leetcode"]

Constraints:
1 <= words1.length, words2.length <= 104
1 <= words1[i].length, words2[i].length <= 10
words1[i] and words2[i] consist only of lowercase English letters.
All the strings of words1 are unique.

"""
class Solution:
    def wordSubsets(self, words1: list[str], words2: list[str]) -> list[str]:
        subsetCounts = defaultdict(int)
        for subset in words2: 
            subsetCount = defaultdict(int)
            for c in subset: 
                subsetCount[c] += 1
            for key in subsetCount: 
                subsetCounts[key] = max(subsetCount[key], subsetCounts[key])
        
        
        result = []
        for word in words1:
            wordCount = defaultdict(int)
            for c in word: 
                wordCount[c] += 1
            match = True
            for key in subsetCounts: 
                if wordCount[key] < subsetCounts[key]: 
                    match = False
            if match: 
                result.append(word)        
        return result
    
@pytest.mark.parametrize("words1, words2, expected", [
    (["warrior", "world"], ["wrr"], ["warrior"]), 
    (["amazon","apple","facebook","google","leetcode"], ["e","o"], ["facebook","google","leetcode"]), 
    (["amazon","apple","facebook","google","leetcode"], ["l","e"], ["apple","google","leetcode"]), 
    (["amazon","apple","facebook","google","leetcode"], ["lo","eo"], ["google","leetcode"]), 
])
def test_wordSubsets(words1: list[str], words2: list[str], expected: list[str]): 
    solution = Solution()
    result = solution.wordSubsets(words1, words2)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])