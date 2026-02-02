from typing import List

class Solution:
    def minOperations(self, nums: List[int]) -> int:
        vals = set(nums)
        return 0 if len(vals) == 1 else 1