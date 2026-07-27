import pytest

class Solution:
    def countPrefixSuffixPairs(self, words: list[str]) -> int:
        count = 0
        for i in range(len(words) -1): 
            for j in range(i + 1, len(words)): 
                if self.isPrefixAndSuffix(words[i], words[j]): 
                    count += 1

        return count

    def isPrefixAndSuffix(self, s1 : str, s2: str) -> bool: 
        if len(s1) > len(s2): 
            return False
        
        return s2[0:len(s1)] == s1 and s2[-len(s1):] == s1

"""

Example 1:
Input: words = ["a","aba","ababa","aa"]
Output: 4
Explanation: In this example, the counted index pairs are:
i = 0 and j = 1 because isPrefixAndSuffix("a", "aba") is true.
i = 0 and j = 2 because isPrefixAndSuffix("a", "ababa") is true.
i = 0 and j = 3 because isPrefixAndSuffix("a", "aa") is true.
i = 1 and j = 2 because isPrefixAndSuffix("aba", "ababa") is true.
Therefore, the answer is 4.

Example 2:
Input: words = ["pa","papa","ma","mama"]
Output: 2
Explanation: In this example, the counted index pairs are:
i = 0 and j = 1 because isPrefixAndSuffix("pa", "papa") is true.
i = 2 and j = 3 because isPrefixAndSuffix("ma", "mama") is true.
Therefore, the answer is 2.  

Example 3:
Input: words = ["abab","ab"]
Output: 0
Explanation: In this example, the only valid index pair is i = 0 and j = 1, and isPrefixAndSuffix("abab", "ab") is false.
Therefore, the answer is 0.

Constraints:

1 <= words.length <= 50
1 <= words[i].length <= 10
words[i] consists only of lowercase English letters.

"""

@pytest.mark.parametrize("words, expected", [
    (["a","aba","ababa","aa"], 4), 
    (["pa","papa","ma","mama"], 2), 
    (["abab","ab"], 0)
])
def test_countPrefixSuffixPairs(words: list[str], expected: int): 
    solution = Solution() 
    result = solution.countPrefixSuffixPairs(words)
    assert(result == expected)

@pytest.mark.parametrize("s1, s2, expected", [
    ("a", "aba", True), 
    ("a", "ababa", True), 
    ("a", "aa", True), 
    ("aba", "ababa", True), 
    ("aba", "aa", False), 
    ("pa", "papa", True), 
    ("ma", "mama", True), 
    ("abab", "ab", False)
])
def test_isPrefixSuffix(s1 : str, s2: str, expected: bool): 
    solution = Solution() 
    result = solution.isPrefixAndSuffix(s1, s2)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])