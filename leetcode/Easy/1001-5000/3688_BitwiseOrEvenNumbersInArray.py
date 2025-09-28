from typing import List

class Solution:
    def evenNumberBitwiseORs(self, nums: List[int]) -> int:
        result = 0
        for n in nums:
            if n % 2 == 0:  
                result |= n
        return result