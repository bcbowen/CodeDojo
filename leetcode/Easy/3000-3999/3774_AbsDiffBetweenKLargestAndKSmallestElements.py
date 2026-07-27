from typing import List

class Solution:
    def absDifference(self, nums: List[int], k: int) -> int:
        nums.sort()
        return sum(nums[-k:len(nums)]) - sum(nums[:k])