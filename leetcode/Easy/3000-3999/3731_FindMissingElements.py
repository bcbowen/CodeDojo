from typing import List

class Solution:
    def findMissingElements(self, nums: List[int]) -> List[int]:
        answer = [] 
        nums.sort()
        
        current = nums[0]; 
        for i in range(1, len(nums)):
            current += 1
            while current < nums[i]: 
                answer.append(current)
                current += 1
        return answer