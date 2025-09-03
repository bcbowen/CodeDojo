from typing import List
from collections import deque

class Solution:
    def anagramMappings(self, nums1: List[int], nums2: List[int]) -> List[int]:
        num2_map = {}
        for index, num in enumerate(nums2): 
            if not num in num2_map: 
                num2_map[num] = deque()
            num2_map[num].append(index)
        result = [] 
        for num in nums1: 
            result.append(num2_map[num].popleft())
        
        return result