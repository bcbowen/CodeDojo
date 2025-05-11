import pytest
from typing import List

class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        buy = prices[0]
        sell = -1
        diff = -1
        for i in range(1, len(prices)): 
            price = prices[i]
            if price < buy:
                if sell > buy: 
                    diff = max(diff, sell - buy) 
                buy = price
                sell = -1
            elif price > sell: 
                sell = price
        if sell > buy: 
            diff = max(diff, sell - buy)

        return 0 if diff == -1 else diff


"""
Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.
"""
@pytest.mark.parametrize("prices, expected", [
     ([7,1,5,3,6,4], 5), 
     ([7,6,4,3,1], 0)

])
def test_maxProfit(prices: List[int], expected: int):
    result = Solution().maxProfit(prices)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])