import pytest
from typing import List


class Solution:
    def maxProfit(self, prices: List[int], fee: int) -> int:
        
        hold = [0] * len(prices)
        free = [0] * len(prices)

        hold[0] = -prices[0]
        for i in range(1, len(prices)): 
            hold[i] = max(hold[i - 1], free[i - 1] - prices[i])
            free[i] = max(free[i - 1], hold[i - 1] + prices[i] - fee)

        return free[-1]

"""
Example 1:
Input: prices = [1,3,2,8,4,9], fee = 2
Output: 8
Explanation: The maximum profit can be achieved by:
- Buying at prices[0] = 1
- Selling at prices[3] = 8
- Buying at prices[4] = 4
- Selling at prices[5] = 9
The total profit is ((8 - 1) - 2) + ((9 - 4) - 2) = 8.

Example 2:
Input: prices = [1,3,7,5,10,3], fee = 3
Output: 6
"""
@pytest.mark.parametrize("prices, fee, expected", [
    ([1,3,2,8,4,9], 2, 8), 
    ([1,3,7,5,10,3], 3, 6)
])
def test_maxProfit(prices: List[int], fee: int, expected: int):
    result = Solution().maxProfit(prices, fee)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 