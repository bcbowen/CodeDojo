from typing import List

class Solution:
    def sumOfDigits(self, nums: List[int]) -> int:
        min_value = min(nums)

        sum_digits = 0
        while min_value > 0: 
            sum_digits += min_value % 10
            min_value //= 10

        return 1 if sum_digits % 2 == 0 else 0
