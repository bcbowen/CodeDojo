class Solution:
    def removeZeros(self, n: int) -> int:
        result = 0
        multiplier = 1
        while n > 0: 
            r = n % 10
            if r != 0: 
                result += r * multiplier
                multiplier *= 10
            n //= 10
        return result