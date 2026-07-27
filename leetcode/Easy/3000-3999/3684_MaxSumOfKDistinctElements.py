from typing import List

class Solution:
    def maxKDistinct(self, nums: List[int], k: int) -> List[int]:
        l = list(set(nums))
        l.sort(reverse=True)
        
        return l[:k]
