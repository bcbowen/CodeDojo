import pytest 

from typing import List 

class Solution:
    def largestSumAfterKNegations(self, nums: List[int], k: int) -> int:
        nums.sort()
        has_zero = 0 in nums
        i = 0
        while k > 0:
            if nums[i] < 0: 
                nums[i] *= -1

            elif has_zero:
                break 
            else: 
                nums[i] *= -1

            if i < len(nums) - 1 and nums[i + 1] < nums[i]:
                i += 1 

            k -= 1
        return sum(nums)

"""
Example 1:
Input: nums = [4,2,3], k = 1
Output: 5
Explanation: Choose index 1 and nums becomes [4,-2,3].

Example 2:
Input: nums = [3,-1,0,2], k = 3
Output: 6
Explanation: Choose indices (1, 2, 2) and nums becomes [3,1,0,2].

Example 3:
Input: nums = [2,-3,-1,5,-4], k = 2
Output: 13
Explanation: Choose indices (1, 4) and nums becomes [2,3,-1,5,4].

tc 9: 
[-2,9,9,8,4]
k = 5
Expected 32
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([4, 2, 3], 1, 5), 
    ([3,-1,0,2], 3, 6), 
    ([2,-3,-1,5,-4], 2, 13), 
    ([-2,9,9,8,4], 5, 32)
])
def test_largestSumAfterKNegations(nums: List[int], k: int, expected: int):  
    result = Solution().largestSumAfterKNegations(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])