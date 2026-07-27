import pytest

class Solution:
    def numberOfSubstrings(self, s: str) -> int:
        def is_valid(): 
            return counts['a'] > 0 and counts['b'] > 0 and counts['c'] > 0
        
        l = 0
        r = 2
        n = len(s) - 1
        counts = {'a': 0, 'b': 0, 'c': 0}
        result = 0

        counts[s[0]] += 1
        counts[s[1]] += 1
        counts[s[2]] += 1

        # while l is 3 from the end and r is less than the end, move l and r to the right and count substrings
        # note: once we have a valid substring, every substring that is one letter longer is also valid
        while l < len(s) - 2 and r < n: 
            while not is_valid() and r < n: 
                r += 1
                counts[s[r]] += 1
            if is_valid(): 
                result += 1
                if r < n:
                    result += len(s) - r - l - 1

            if counts[s[l]] > 0: 
                counts[s[l]] -= 1
            l += 1
            #r += 1

        # once r is at the end, keep moving l to the right and checking valid substrings 
        # note: once a substring is invalid, we can stop because no other substring will be valid
        while l < len(s) - 2 and is_valid(): 
            result += 1
            l += 1


        return result


"""
Example 1:
Input: s = "abcabc"
Output: 10
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "abc", "abca", "abcab", "abcabc", "bca", "bcab", "bcabc", "cab", "cabc" and "abc" (again). 

Example 2:
Input: s = "aaacb"
Output: 3
Explanation: The substrings containing at least one occurrence of the characters a, b and c are "aaacb", "aacb" and "acb". 

Example 3:
Input: s = "abc"
Output: 1
"""
@pytest.mark.parametrize("s, expected", [
    ("abcabc", 10), 
    ("aaacb", 3), 
    ("abc", 1)
])
def test(s: str, expected: int): 
    result = Solution().numberOfSubstrings(s)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])