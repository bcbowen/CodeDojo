from typing import List

class Solution:
    def missingMultiple(self, nums: List[int], k: int) -> int:
        val = k
        nums.sort()
        for i in range(len(nums)): 
            if nums[i] == val: 
                val += k
            elif nums[i] > val: 
                return val
        return val

