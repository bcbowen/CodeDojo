import pytest
from typing import List

class Solution:
    def largeGroupPositions(self, s: str) -> List[List[int]]:
        result = [] 
        start = 0
        end = -1
        last = s[0]
        for i, c in enumerate(s): 
            if last != c: 
                end = i - 1
                if end - start > 1: 
                    result.append([start, end])
                start = i
                last = c
        end = len(s) - 1
        if end - start > 1: 
            result.append([start, end])

        return result
    
"""
Example 1:
Input: s = "abbxxxxzzy"
Output: [[3,6]]
Explanation: "xxxx" is the only large group with start index 3 and end index 6.

Example 2:
Input: s = "abc"
Output: []
Explanation: We have groups "a", "b", and "c", none of which are large groups.

Example 3:
Input: s = "abcdddeeeeaabbbcd"
Output: [[3,5],[6,9],[12,14]]
Explanation: The large groups are "ddd", "eeee", and "bbb".

TC 138

Input: "aaa"
Output: [[0,2]]
"""
@pytest.mark.parametrize("s, expected", [
    ("abbxxxxzzy", [[3,6]]), 
    ("abc", []), 
    ("abcdddeeeeaabbbcd", [[3,5],[6,9],[12,14]]), 
    ("aaa", [[0,2]])
])
def test_largeGroupPositions(s: str, expected: List[List[int]]):
    result = Solution().largeGroupPositions(s)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])