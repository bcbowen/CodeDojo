import pytest 


class Solution:
    def numSteps(self, s: str) -> int:
        steps = 0
        val = int(s, 2)
        while val != 1: 
            if val % 2 == 0: 
                val //= 2
            else: 
                val += 1
            steps += 1

        return steps