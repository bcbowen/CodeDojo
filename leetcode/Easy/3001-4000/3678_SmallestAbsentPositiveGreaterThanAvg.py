from typing import List

class Solution:
    def smallestAbsent(self, nums: List[int]) -> int:
        a = int(sum(nums) / len(nums)) 
        if a < 0: 
            a = 0
    
        a += 1
        while a in nums: 
            a += 1

        return a         