from typing import List

import pytest

class Solution:
    def get_digits(self, n: int) -> List[int]: 
        digits = [] 
        while n > 0: 
            d = n % 10
            digits.insert(0, d)
            n //= 10

        return digits
    
    def isArmstrong(self, n: int) -> bool:
        digits = self.get_digits(n)
        count = len(digits)
        total = 0
        for d in digits: 
            total += d**count
        return total == n

"""
Example 1:
Input: n = 153
Output: true
Explanation: 153 is a 3-digit number, and 153 = 13 + 53 + 33.

Example 2:
Input: n = 123
Output: false
Explanation: 123 is a 3-digit number, and 123 != 13 + 23 + 33 = 36.
"""
@pytest.mark.parametrize("n, expected", [
    (153, True), 
    (123, False)
])
def test_isArmstrong(n: int, expected: bool):
    result = Solution().isArmstrong(n)
    assert(result == expected)  

@pytest.mark.parametrize("n, expected", [
    (1234, [1, 2, 3, 4]),
    (5, [5]) 
])
def test_get_digits(n: int, expected: List[int]): 
    result = Solution().get_digits(n)
    assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__]) 