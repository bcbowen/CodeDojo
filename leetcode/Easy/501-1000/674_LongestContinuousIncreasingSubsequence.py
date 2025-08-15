import pytest
from typing import List

class Solution:
    def findLengthOfLCIS(self, nums: List[int]) -> int:
        i = 0
        j = 0
        max_len = 1
        while i < len(nums) and j < len(nums): 
            if j < len(nums) - 1 and nums[j + 1] > nums[j]: 
                j += 1
                max_len = max(max_len, j - i + 1)
            else: 
                i = j + 1
                j = i
        return max_len
    

"""
Example 1:
Input: nums = [1,3,5,4,7]
Output: 3
Explanation: The longest continuous increasing subsequence is [1,3,5] with length 3.
Even though [1,3,5,7] is an increasing subsequence, it is not continuous as elements 5 and 7 are separated by element
4.

Example 2:
Input: nums = [2,2,2,2,2]
Output: 1
Explanation: The longest continuous increasing subsequence is [2] with length 1. Note that it must be strictly
increasing.
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,3,5,4,7], 3), 
    ([2,2,2,2,2], 1)
])
def test_findLengthOfLCIS(nums: List[int], expected: int):
    result = Solution().findLengthOfLCIS(nums)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])