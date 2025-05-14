import pytest
from typing import List

class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        local_max = prices[0]
        local_min = prices[0]
        profit = 0
        for price in prices: 
            if price < local_max: 
                profit += local_max - local_min
                local_min = price
                local_max = price
            elif price > local_max: 
                local_max = price

        profit += local_max - local_min
        return profit

"""
Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 7
Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
Total profit is 4 + 3 = 7.

Example 2:
Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Total profit is 4.

Example 3:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
"""
@pytest.mark.parametrize("prices, expected", [
    ([7,1,5,3,6,4], 7), 
    ([1,2,3,4,5], 4), 
    ([7,6,4,3,1], 0)
])
def test_maxProfit(prices: List[int], expected: int):
    result = Solution().maxProfit(prices)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 