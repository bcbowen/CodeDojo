class Solution:
    def sumAndMultiply(self, n: int) -> int:
        digit_sum = 0
        multiplier = 1
        total = 0
        while n > 0: 
            
            digit = n % 10 
            if digit != 0: 
                total += multiplier * digit
                digit_sum += digit
                multiplier *= 10
            n //= 10
        return digit_sum * total
        
