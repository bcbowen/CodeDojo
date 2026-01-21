import pytest
from typing import List

class Solution:
    def findEvenNumbers(self, digits: List[int]) -> List[int]:
        found = set()
        def backtrack(s: str, used: List[int]): 
            if len(s) == 3: 
                val = int(s)
                if val % 2 == 0 and not val in found: 
                    found.add(val)
                return 
            for i in range(len(digits)):
                d = digits[i] 
                if (len(s) == 0 and d == 0) or i in used: 
                    continue
                used.append(i)
                backtrack(s + str(d), used.copy())
                used.pop()

        backtrack("", [])

        result = list(found)
        result.sort()
        return result

"""
Example 1:
Input: digits = [2,1,3,0]
Output: [102,120,130,132,210,230,302,310,312,320]
Explanation: All the possible integers that follow the requirements are in the output array. 
Notice that there are no odd integers or integers with leading zeros.

Example 2:
Input: digits = [2,2,8,8,2]
Output: [222,228,282,288,822,828,882]
Explanation: The same digit can be used as many times as it appears in digits. 
In this example, the digit 8 is used twice each time in 288, 828, and 882. 

Example 3:
Input: digits = [3,7,5]
Output: []
Explanation: No even integers can be formed using the given digits.
"""
@pytest.mark.parametrize("digits, expected", [
    ([2,1,3,0], [102,120,130,132,210,230,302,310,312,320]), 
    ([2,2,8,8,2], [222,228,282,288,822,828,882]), 
    ([3,7,5], [])
])

def test_findEvenNumbers(digits: List[int], expected: List[int]):
    result = Solution().findEvenNumbers(digits)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 