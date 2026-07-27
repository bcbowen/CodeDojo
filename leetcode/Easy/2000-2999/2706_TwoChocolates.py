from typing import List

class Solution:
    def buyChoco(self, prices: List[int], money: int) -> int:
        if len(prices) < 2: 
            return money
        prices.sort()
        spent = prices[0] + prices[1]

        return money - spent if spent <= money else money       