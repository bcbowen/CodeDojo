from typing import List

class Solution:
    def dominantIndices(self, nums: List[int]) -> int:
        result = 0 
        for i in range(len(nums) - 1): 
           if nums[i] > sum(nums[i + 1:]) // (len(nums) - (i + 1)): 
               result += 1

        return result