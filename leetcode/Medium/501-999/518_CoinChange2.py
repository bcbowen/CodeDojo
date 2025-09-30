import pytest
from typing import List

class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        result = 0
        combos = set()
        def backtrack(remaining_amount: int, current_coins: List[int]):
            nonlocal result
            nonlocal combos
            if remaining_amount == 0: 
                current_coins.sort()
                candidate = tuple(current_coins)
                if not candidate in combos: 
                    result += 1
                    combos.add(candidate)
                return
            
            for coin in coins: 
                new_coins = current_coins.copy()
                if coin <= remaining_amount: 
                    new_coins.append(coin)
                    backtrack(remaining_amount - coin, new_coins)
                
        backtrack(amount, [])

        return result

"""
Example 1:
Input: amount = 5, coins = [1,2,5]
Output: 4
Explanation: there are four ways to make up the amount:
5=5
5=2+2+1
5=2+1+1+1
5=1+1+1+1+1

Example 2:
Input: amount = 3, coins = [2]
Output: 0
Explanation: the amount of 3 cannot be made up just with coins of 2.

Example 3:
Input: amount = 10, coins = [10]
Output: 1
"""
@pytest.mark.parametrize("amount, coins, expected", [
    (5, [1, 2, 5], 4), 
    (3, [2], 0), 
    (10, [10], 1)
])
def test_change(amount: int, coins: List[int], expected: int):
    result = Solution().change(amount, coins)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 