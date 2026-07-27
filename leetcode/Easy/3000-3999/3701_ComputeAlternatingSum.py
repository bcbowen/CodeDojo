from typing import List

class Solution:
    def alternatingSum(self, nums: List[int]) -> int:
        val = 0
        even = True
        for i in range(len(nums)): 
            val += nums[i] if even else -nums[i]
            even = not even
        return val