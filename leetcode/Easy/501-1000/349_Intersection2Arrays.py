from typing import List
class Solution:
    def intersection(self, nums1: List[int], nums2: List[int]) -> List[int]:
        n1 = set(nums1)
        n2 = set(nums2)

        result = []
        for n in n1: 
            if n in n2: 
                result.append(n)
        return result