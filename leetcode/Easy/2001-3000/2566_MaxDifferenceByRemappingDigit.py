import pytest

class Solution:
    def minMaxDifference(self, num: int) -> int:
        maxVal = str(num)
        minVal = str(num)
        for c in maxVal: 
            if c != '9': 
                maxVal = maxVal.replace(c, '9')
                break
        for c in minVal: 
            if c != '0': 
                minVal = minVal.replace(c, '0')
                break
        return int(maxVal) - int(minVal)

"""
Example 1:
Input: num = 11891
Output: 99009
Explanation: 
To achieve the maximum value, Bob can remap the digit 1 to the digit 9 to yield 99899.
To achieve the minimum value, Bob can remap the digit 1 to the digit 0, yielding 890.
The difference between these two numbers is 99009.

Example 2:
Input: num = 90
Output: 99
Explanation:
The maximum value that can be returned by the function is 99 (if 0 is replaced by 9) and the minimum value that can be returned by the function is 0 (if 9 is replaced by 0).
Thus, we return 99.

TC 34
num = 456
expected = 900
"""
@pytest.mark.parametrize("num, expected", [
    (11891, 99009), 
    (90, 99), 
    (456, 900)
])
def test_minMaxDifference(num: int, expected: int):
    result = Solution().minMaxDifference(num)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 