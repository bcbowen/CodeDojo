import pytest


"""
Example 1:
Input: s = "abc", shift = [[0,1],[1,2]]
Output: "cab"
Explanation: 
[0,1] means shift to left by 1. "abc" -> "bca"
[1,2] means shift to right by 2. "bca" -> "cab"

Example 2:
Input: s = "abcdefg", shift = [[1,1],[1,1],[0,2],[1,3]]
Output: "efgabcd"
Explanation:  
[1,1] means shift to right by 1. "abcdefg" -> "gabcdef"
[1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
[0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
[1,3] means shift to right by 3. "abcdefg" -> "efgabcd"
 

Constraints:

1 <= s.length <= 100
s only contains lower case English letters.
1 <= shift.length <= 100
shift[i].length == 2
directioni is either 0 or 1.
0 <= amounti <= 100
"""

class Solution:
    def stringShift(self, s: str, shift: list[list[int]]) -> str:
        shift_total = 0
        for val in shift: 
            if val[0] == 0: 
                shift_total -= val[1]
            else:
                shift_total += val[1]
        shift_total =  shift_total % len(s)


        """
        [1,1] means shift to right by 1. "gabcdef" -> "fgabcde"
        [0,2] means shift to left by 2. "fgabcde" -> "abcdefg"
        """
        if shift_total == 0: 
            return s 
        elif shift_total < 0: 
            shift_total *= -1
            shifted = s[shift_total:] + s[0:shift_total]
        else:
            left = s[len(s) - shift_total :] 
            right = s[0:len(s) - shift_total]
            #shifted = s[len(s) - shift_total :] + s[0:shift_total + 1] 
            shifted = left + right
        return shifted

@pytest.mark.parametrize("s, shift, expected", [
    ("abc", [[0,1],[1,2]], "cab"),
    ("abcdefg", [[1,1],[1,1],[0,2],[1,3]], "efgabcd"), 
    ("mecsk", [[1,4],[0,5],[0,4],[1,1],[1,5]], "kmecs") 
])
def test_stringShift(s: str, shift: list[list[int]], expected: str):
    solution = Solution()
    result = solution.stringShift(s, shift)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])