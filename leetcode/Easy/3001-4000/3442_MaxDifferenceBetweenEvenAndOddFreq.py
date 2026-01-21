import pytest
from collections import Counter

class Solution:
    def maxDifference(self, s: str) -> int:
        counts = Counter(s)
        min_evens = float('inf')
        max_odds = 0
        for c in counts: 
            if counts[c] % 2 == 0: 
                min_evens = min(min_evens, counts[c])
            else: 
                max_odds = max(max_odds, counts[c])
        return max_odds - int(min_evens)


"""
Example 1:
Input: s = "aaaaabbc"
Output: 3
Explanation:
The character 'a' has an odd frequency of 5, and 'b' has an even frequency of 2.
The maximum difference is 5 - 2 = 3.

Example 2:
Input: s = "abcabcab"
Output: 1
Explanation:

The character 'a' has an odd frequency of 3, and 'c' has an even frequency of 2.
The maximum difference is 3 - 2 = 1.

TC 265: 
s: "tzt" 
expected: -1

TC 449: 
s = "mmsmsym"
expected: -1
"""
@pytest.mark.parametrize("s, expected", [
    ("aaaaabbc", 3), 
    ("abcabcab", 1), 
    ("tzt", -1), 
    ("mmsmsym", -1)
])
def test_maxDifference(s: str, expected: int): 
    result = Solution().maxDifference(s)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 