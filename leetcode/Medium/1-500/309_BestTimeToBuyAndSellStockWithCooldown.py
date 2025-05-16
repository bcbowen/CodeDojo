import pytest
from typing import List

class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        sold = [0] * len(prices)
        held = [0] * len(prices)
        reset = [0] * len(prices)
        
        held[0] = -prices[0]
        reset[0] = 0

        for i in range(1, len(prices)): 
            sold[i] = held[i - 1] + prices[i]
            held[i] = max(held[i - 1], reset[i - 1] - prices[i])
            reset[i] = max(reset[i - 1], sold[i - 1])

        return max(sold[-1], held[-1], reset[-1])

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