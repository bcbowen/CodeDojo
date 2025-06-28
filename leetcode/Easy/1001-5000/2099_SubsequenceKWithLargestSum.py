from typing import List

class Solution:
    def maxSubsequence(self, nums: List[int], k: int) -> List[int]:
        values = sorted(nums)[-k:]
        result = [] 
        for num in nums: 
            if num in values: 
                result.append(num)
                values.remove(num)
                if len(values) == 0: 
                    break
        return result    