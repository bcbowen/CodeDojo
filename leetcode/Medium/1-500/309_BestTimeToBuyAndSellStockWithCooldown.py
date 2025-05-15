import pytest
from typing import List

class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        profit = 0
        hold = [0] * len(prices)
        free = [0] * len(prices)
        hold[0] = -(prices[0])

        for i in range(): 
            pass 
        return profit

"""
Example 1:
Input: prices = [1,2,3,0,2]
Output: 3
Explanation: transactions = [buy, sell, cooldown, buy, sell]

Example 2:
 Input: prices = [1]
Output: 0
"""
@pytest.mark.parametrize("prices, expected", [
    ([1,2,3,0,2], 3), 
    ([1], 0)
])
def test_maxProfit(prices: List[int], expected: int):
    result = Solution().maxProfit(prices)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])