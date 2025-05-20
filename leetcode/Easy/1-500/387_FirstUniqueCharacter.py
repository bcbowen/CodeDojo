import pytest
from collections import deque

class Solution:
    def firstUniqChar(self, s: str) -> int:
        charQ = deque()
        charCounts = {}

        for i, c in enumerate(s): 
            charQ.append(c)
            if not c in charCounts: 
                charCounts[c] = (i, 1)
            else:
                firstIndex, count =  charCounts[c]
                charCounts[c] = (firstIndex, count + 1)
            

        while charQ: 
            c = charQ.popleft()
            firstIndex, count = charCounts[c]
            if count == 1: 
                return firstIndex
        
        return -1

"""
Example 1:
Input: s = "leetcode"
Output: 0
Explanation:
The character 'l' at index 0 is the first character that does not occur at any other index.

Example 2:
Input: s = "loveleetcode"
Output: 2

Example 3:
Input: s = "aabb"
Output: -1
"""
@pytest.mark.parametrize("s, expected", [
    ("leetcode", 0), 
    ("loveleetcode", 2), 
    ("aabb", -1)
])
def test_firstUniqChar(s: str, expected: int):
    result = Solution().firstUniqChar(s)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])