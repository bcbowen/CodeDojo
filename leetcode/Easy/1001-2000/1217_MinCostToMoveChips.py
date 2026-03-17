from typing import List

class Solution:
    def minCostToMoveChips(self, position: List[int]) -> int:
        evens = 0
        odds = 0
        for i in range(len(position)): 
            val = position[i]
            if val % 2 == 0: 
                evens += 1
            else: 
                odds += 1

        return min(evens, odds)