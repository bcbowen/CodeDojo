from typing import List

class Solution:
    def minimumCost(self, nums: List[int]) -> int:
        rest = nums[1:]
        rest.sort()
        return nums[0] + sum(rest[:2])