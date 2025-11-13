from typing import List

class Solution:
    def smallestRangeI(self, nums: List[int], k: int) -> int:
        nums.sort()
        diff = nums[-1] - nums[0]
        return 0 if diff <= 2 * k else diff - 2 * k