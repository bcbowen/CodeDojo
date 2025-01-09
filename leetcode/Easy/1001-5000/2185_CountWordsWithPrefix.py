import pytest

"""
Example 1:
Input: words = ["pay","attention","practice","attend"], pref = "at"
Output: 2
Explanation: The 2 strings that contain "at" as a prefix are: "attention" and "attend".

Example 2:
Input: words = ["leetcode","win","loops","success"], pref = "code"
Output: 0
Explanation: There are no strings that contain "code" as a prefix.
 

Constraints:

1 <= words.length <= 100
1 <= words[i].length, pref.length <= 100
words[i] and pref consist of lowercase English letters.
"""

class Solution:
    def prefixCount(self, words: list[str], pref: str) -> int:
        count = 0
        for word in words: 
            if len(word) >= len(pref) and word[0: len(pref)] == pref: 
                count += 1

        return count


@pytest.mark.parametrize("words, pref, expected", [
    (["pay","attention","practice","attend"], "at", 2), 
    (["leetcode","win","loops","success"], "code", 0)
])
def test_prefixCount(words : list[str], pref: str, expected: int): 
    solution = Solution()
    result = solution.prefixCount(words, pref)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])