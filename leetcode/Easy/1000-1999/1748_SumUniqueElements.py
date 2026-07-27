from typing import List
from collections import Counter

class Solution:
    def sumOfUnique(self, nums: List[int]) -> int:
        counts = Counter(nums)
        result = 0
        for k, v in counts.items(): 
            if v == 1: 
                result += k
        return result