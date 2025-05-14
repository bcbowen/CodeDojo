import pytest
from collections import deque 
from typing import List

class Solution:
    def coinChange(self, coins: List[int], amount: int) -> int:
        if amount == 0: 
            return 0
        
        q = deque()
        seen = set()
        for coin in coins: 
            if coin == amount: 
                return 1
            if coin < amount: 
                remaining_amount = amount - coin
                q.append((1, amount - coin))
                seen.add(remaining_amount)
        while q: 
            coin_count, remaining_amount = q.popleft()
            for coin in coins: 
                next_amount = remaining_amount - coin
                if next_amount == 0: 
                    return coin_count + 1
                elif next_amount > 0 and not next_amount in seen: 
                    q.append((coin_count + 1, next_amount))
                    seen.add(next_amount)
        return -1

"""
Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0

TC 40 (TLE)
[411,412,413,414,415,416,417,418,419,420,421,422], amount = 9864
"""
@pytest.mark.parametrize("coins, amount, expected", [
     ([1,2,5], 11, 3), 
     ([2], 3, -1), 
     ([1], 0, 0)
])
def test_coinChange(coins: List[int], amount: int, expected: int):
    result = Solution().coinChange(coins, amount)
    assert(result == expected)

# This returns TLE with the first few implementations
def test_longRunningTestCase40(): 
    coins = [411,412,413,414,415,416,417,418,419,420,421,422]
    amount = 9864
    expected = 24
    result = Solution().coinChange(coins, amount)
    assert(result == expected)

if __name__ ==  "__main__":
    pytest.main([__file__]) 