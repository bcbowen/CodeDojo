from typing import List

class Solution:
    def sum_digits(self, num: int) -> int: 
        result = 0
        while num > 0: 
            result += num % 10
            num //= 10
        return result
    
    def minElement(self, nums: List[int]) -> int:
        result = 100000
        for num in nums: 
            result = min(result, self.sum_digits(num))
        return result