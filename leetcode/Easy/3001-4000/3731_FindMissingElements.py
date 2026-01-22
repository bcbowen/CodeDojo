from typing import List

class Solution:
    def findMissingElements(self, nums: List[int]) -> List[int]:
        answer = [] 
        nums.sort()
        current = nums[0]; 
        for num in range(nums[1], nums[-1]):
            current += 1
            while current < num: 
                answer.append(current)
                current += 1
        return answer