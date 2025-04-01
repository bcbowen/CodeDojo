import pytest

class Solution:
    def maximum69Number (self, num: int) -> int:
        digits = [int(d) for d in str(num)]
        for i in range(len(digits)): 
            if digits[i] == 6: 
                digits[i] = 9
                break
        return int("".join(map(str, digits)))

"""
Example 1:
Input: num = 9669
Output: 9969
Explanation: 
Changing the first digit results in 6669.
Changing the second digit results in 9969.
Changing the third digit results in 9699.
Changing the fourth digit results in 9666.
The maximum number is 9969.

Example 2:
Input: num = 9996
Output: 9999
Explanation: Changing the last digit 6 to 9 results in the maximum number.

Example 3:
Input: num = 9999
Output: 9999
Explanation: It is better not to apply any change.
"""

@pytest.mark.parametrize("num, expected", [
     (9669, 9969), 
     (9996, 9999), 
     (9999, 9999)
])
def test_maximum69Number (num: int, expected: int):
    result = Solution().maximum69Number(num)
    assert(result == expected)    

if __name__ == "__main__":
    pytest.main([__file__]) 