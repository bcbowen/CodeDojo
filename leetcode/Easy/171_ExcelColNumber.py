import pytest

class Solution:
    def titleToNumber(self, columnTitle: str) -> int:
        result = 0
        power = len(columnTitle) - 1
        for c in columnTitle: 
            result += (ord(c) - 64) * 26**power
            power -= 1

        return result

"""
YZ = 25*(26^1) + 26*(26^0)
XYZ = 24*(26^2) + 25*(26^1) + 26*(26^0)

Given a string columnTitle that represents the column title as appears in an Excel sheet, 
return its corresponding column number.



For example:

A -> 1
B -> 2
C -> 3
...
Z -> 26
AA -> 27
AB -> 28 
...
 

Example 1:
Input: columnTitle = "A"
Output: 1

Example 2:
Input: columnTitle = "AB"
Output: 28

Example 3:
Input: columnTitle = "ZY"
Output: 701

"""

@pytest.mark.parametrize("columnTitle, expected", [
    ('A', 1),
    ('AB', 28),
    ('ZY', 701)
])
def test_titleToNumber(columnTitle: str, expected: int):
    result = Solution().titleToNumber(columnTitle)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])