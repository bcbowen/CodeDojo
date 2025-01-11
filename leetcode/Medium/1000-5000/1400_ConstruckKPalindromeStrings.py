import pytest
from collections import defaultdict

"""
Example 1:
Input: s = "annabelle", k = 2
Output: true
Explanation: You can construct two palindromes using all characters in s.
Some possible constructions "anna" + "elble", "anbna" + "elle", "anellena" + "b"

Example 2:
Input: s = "leetcode", k = 3
Output: false
Explanation: It is impossible to construct 3 palindromes using all the characters of s.

Example 3:
Input: s = "true", k = 4
Output: true
Explanation: The only possible solution is to put each character in a separate string.
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
1 <= k <= 105
"""

class Solution:
    def canConstruct(self, s: str, k: int) -> bool:
        if len(s) < k: 
            return False
        
        char_counts = defaultdict(int)
        for c in s: 
            char_counts[c] += 1

        odd_count = 0
        for key in char_counts: 
            if char_counts[key] % 2 == 1: 
                odd_count += 1
        if odd_count > k: 
            return False
        
        return True

@pytest.mark.parametrize("val, k, expected", [
    ("annabelle", 2, True),
    ("leetcode", 3, False),
    ("true", 4, True), 
])
def test_canConstruct(val: str, k: int, expected: bool):
    solution = Solution() 
    result = solution.canConstruct(val, k)
    assert(result == expected) 


if __name__ == "__main__": 
    pytest.main([__file__])