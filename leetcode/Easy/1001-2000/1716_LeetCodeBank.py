import pytest

class Solution:
    def totalMoney(self, n: int) -> int:
        weeklyOffset = 0
        dailyOffset = 0
        total = 0
        for i in range(n): 
            weeklyOffset = i // 7
            dailyOffset = i % 7

            total += weeklyOffset + dailyOffset + 1

        return total
    
"""

Example 1:
Input: n = 4
Output: 10
Explanation: After the 4th day, the total is 1 + 2 + 3 + 4 = 10.

Example 2:
Input: n = 10
Output: 37
Explanation: After the 10th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4) = 37. Notice that on the 2nd Monday, Hercy only puts in $2.

Example 3:
Input: n = 20
Output: 96
Explanation: After the 20th day, the total is (1 + 2 + 3 + 4 + 5 + 6 + 7) + (2 + 3 + 4 + 5 + 6 + 7 + 8) + (3 + 4 + 5 + 6 + 7 + 8) = 96.

"""
@pytest.mark.parametrize("n, expected", [
    (4, 10), 
    (10, 37), 
    (20, 96)
])
def test(n: int, expected: int): 
    result = Solution().totalMoney(n)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])