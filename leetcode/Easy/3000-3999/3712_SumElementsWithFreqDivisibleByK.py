from collections import Counter
from typing import List

class Solution:
    def sumDivisibleByK(self, nums: List[int], k: int) -> int:
        counts = Counter(nums)
        result = 0
        for val, count in counts.items(): 
            if count % k == 0: 
                result += val * count
        return result