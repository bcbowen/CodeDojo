import pytest

class Solution:
    def checkPerfectNumber(self, num: int) -> bool:
        if num == 1: 
            return False
        
        factor_sum = 1
        i = 2
        limit = int(num**.5) + 1
        while i < limit: 
            if num % i == 0: 
                factor_sum += i
                limit = num // i
                factor_sum += limit
                if factor_sum > num: 
                    return False
            i += 1
        return factor_sum == num
    


"""
Example 1:
Input: num = 28
Output: true
Explanation: 28 = 1 + 2 + 4 + 7 + 14
1, 2, 4, 7, and 14 are all divisors of 28.

Example 2:
Input: num = 7
Output: false

TC 98: 1, False
"""
@pytest.mark.parametrize("num, expected", [
    (28, True), 
    (7, False), 
    (1, False)
])
def test_checkPerfectNumber(num: int, expected: bool):
    result = Solution().checkPerfectNumber(num)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])