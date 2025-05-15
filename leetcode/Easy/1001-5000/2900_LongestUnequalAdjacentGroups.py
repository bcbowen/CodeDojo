import pytest
from typing import List

class Solution:
    def getLongestSubsequence(self, words: List[str], groups: List[int]) -> List[str]:
        result = [words[0]]
        for i in range(1, len(groups)): 
            if groups[i] != groups[i - 1]: 
                result.append(words[i])
        return list(result)
    
"""
Example 1:
Input: words = ["e","a","b"], groups = [0,0,1]
Output: ["e","b"]
Explanation: A subsequence that can be selected is ["e","b"] because groups[0] != groups[2]. Another subsequence that can be selected is ["a","b"] because groups[1] != groups[2]. It can be demonstrated that the length of the longest subsequence of indices that satisfies the condition is 2.

Example 2:
Input: words = ["a","b","c","d"], groups = [1,0,1,1]
Output: ["a","b","c"]
Explanation: A subsequence that can be selected is ["a","b","c"] because groups[0] != groups[1] and groups[1] != groups[2]. Another subsequence that can be selected is ["a","b","d"] because groups[0] != groups[1] and groups[1] != groups[3]. It can be shown that the length of the longest subsequence of indices that satisfies the condition is 3.
"""
@pytest.mark.parametrize("words, groups, expected", [
    (["e","a","b"], [0,0,1], ["e","b"]), 
    (["a","b","c","d"], [1,0,1,1], ["a","b","c"]), 
    (["e"], [0], ["e"]), 
    (["f"], [1], ["f"]), 
    (["fe"], [0], ["fe"])
])
def test_getLongestSubsequence(words: List[str], groups: List[int], expected: List[str]):
    result = Solution().getLongestSubsequence(words, groups)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__])