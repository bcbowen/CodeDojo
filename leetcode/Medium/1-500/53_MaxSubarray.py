import pytest
from typing import List


class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        if len(nums) == 1: 
            return nums[0]
        
        max_value = nums[0]
        current = nums[0]
        for i in range(1, len(nums)):         
            current = max(current + nums[i], nums[i])
            max_value = max(max_value, current)

        return max_value





"""
Example 1:
Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
Output: 6
Explanation: The subarray [4,-1,2,1] has the largest sum 6.

Example 2:
Input: nums = [1]
Output: 1
Explanation: The subarray [1] has the largest sum 1.

Example 3:
Input: nums = [5,4,-1,7,8]
Output: 23
Explanation: The subarray [5,4,-1,7,8] has the largest sum 23.
"""
@pytest.mark.parametrize("nums, expected", [
    ([-2,1,-3,4,-1,2,1,-5,4], 6), 
    ([1], 1), 
    ([5,4,-1,7,8], 23)
])
def test_maxSubArray(nums: List[int], expected: int):
    result = Solution().maxSubArray(nums)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__])
