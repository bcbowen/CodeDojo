from typing import List
class Solution:
    def intersect(self, nums1: List[int], nums2: List[int]) -> List[int]:
        result = []
        nums1.sort() 
        nums2.sort() 
        p1 = 0
        p2 = 0

        while p1 < len(nums1) and p2 < len(nums2): 
            while(p1 < len(nums1) and nums1[p1] < nums2[p2]): 
                p1 += 1
            if p1 >= len(nums1): 
                break

            while(p2 < len(nums2) and nums2[p2] < nums1[p1]): 
                p2 += 1
            if p2 >= len(nums2): 
                break

            while p1 < len(nums1) and p2 < len(nums2) and nums1[p1] == nums2[p2]: 
                result.append(nums1[p1])
                p1 += 1
                p2 += 1

        return result