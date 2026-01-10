import pytest

class Solution:
    def minimumDeleteSum(self, s1: str, s2: str) -> int:
        cache = {}

        def get_min_cost(s1: str, s2: str, i: int, j: int) -> int: 
            if i < 0 and j < 0: 
                return 0
            
            if i < 0:
                val = ord(s2[j])
                if not(i, j - 1) in cache: 
                    cache[(i, j - 1)] = get_min_cost(s1, s2, i, j - 1) 
                return val + cache[(i, j - 1)]
            
            if j < 0:
                val = ord(s1[i])
                if not(i - 1, j) in cache: 
                    cache[(i - 1, j)] = get_min_cost(s1, s2, i - 1, j) 
                return val + cache[(i - 1, j)]
            
            if s1[i] == s2[j]: 
                if not(i - 1, j - 1) in cache: 
                    cache[(i - 1, j - 1)] = get_min_cost(s1, s2, i - 1, j - 1)
                return cache[(i - 1, j - 1)]
            
            # return min i - 1, j - 1, or (i - 1 and j - 1)  
            # i - 1, j: 
            val1 = ord(s1[i])
            if not(i - 1, j) in cache: 
                cache[(i - 1, j)] = get_min_cost(s1, s2, i - 1, j)
            val1 += cache[(i - 1, j)] 

            # i, j - 1: 
            val2 = ord(s2[j])
            if not(i, j - 1) in cache: 
                cache[(i, j - 1)] = get_min_cost(s1, s2, i, j - 1) 
            val2 += cache[(i, j - 1)]

            # i - 1, j - 1
            val3 = ord(s1[i]) + ord(s2[j])
            if not(i - 1, j - 1) in cache: 
                cache[(i - 1, j - 1)] = get_min_cost(s1, s2, i - 1, j - 1) 
            val3 += cache[(i - 1, j - 1)]

            return min(val1, val2, val3)
        return get_min_cost(s1, s2, len(s1) - 1, len(s2) - 1)
    
"""
Example 1:
Input: s1 = "sea", s2 = "eat"
Output: 231
Explanation: Deleting "s" from "sea" adds the ASCII value of "s" (115) to the sum.
Deleting "t" from "eat" adds 116 to the sum.
At the end, both strings are equal, and 115 + 116 = 231 is the minimum sum possible to achieve this.

Example 2:
Input: s1 = "delete", s2 = "leet"
Output: 403
Explanation: Deleting "dee" from "delete" to turn the string into "let",
adds 100[d] + 101[e] + 101[e] to the sum.
Deleting "e" from "leet" adds 101[e] to the sum.
At the end, both strings are equal to "let", and the answer is 100+101+101+101 = 403.
If instead we turned both strings into "lee" or "eet", we would get answers of 433 or 417, which are higher.
"""
@pytest.mark.parametrize("s1, s2, expected", [
    ("sea", "eat", 231), 
    ("delete", "leet", 403)
])
def test_minimumDeleteSum(s1: str, s2: str, expected: int):
    result = Solution().minimumDeleteSum(s1, s2)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 