from typing import List

class Solution:
    def lateFee(self, daysLate: List[int]) -> int:
        fee = 0
        for n in daysLate: 
            if n == 1: 
                fee += 1
            elif n > 5: 
                fee += 3 * n
            else: 
                fee += 2 * n
        return fee