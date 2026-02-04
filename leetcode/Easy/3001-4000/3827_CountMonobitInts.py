class Solution:
    def countMonobit(self, n: int) -> int:
        if n == 0: 
            return 1
        elif n == 1: 
            return 2
        
        accumulator = 3
        power = 1
        result = 2

        while accumulator <= n:
            result += 1
            power += 1
            accumulator += 2 ** power
            
        return result