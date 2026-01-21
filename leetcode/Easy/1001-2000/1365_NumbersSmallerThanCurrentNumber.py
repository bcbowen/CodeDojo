from typing import List 

class Solution:
    def smallerNumbersThanCurrent(self, nums: List[int]) -> List[int]:
        result = [0] * len(nums)
        totals = {} 
        for i in range(len(nums)): 
            if not nums[i] in totals: 
                smaller_count = 0
                for j in range(len(nums)): 
                    if j != i and nums[j] < nums[i]: 
                        smaller_count += 1
                totals[nums[i]] = smaller_count
        
        for i in range(len(nums)): 
            result[i] = totals[nums[i]]
        return result