import pytest
from typing import List

class Solution:
    def search(self, nums: List[int], target: int) -> int:
        left = 0
        right = len(nums) - 1
        while left <= right: 
            mid = left + (right - left) // 2
            if nums[mid] == target: 
                return mid
            if nums[mid] > target: 
                right = mid - 1
            else:
                left = mid + 1

        return -1 

"""
Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
"""
@pytest.mark.parametrize("nums, target, expected", [
    ([-1,0,3,5,9,12], 9, 4), 
    ([-1,0,3,5,9,12], 2, -1), 
    ([5], 5, 0)
])
def test_search(nums: List[int], target: int, expected: int):
    result = Solution().search(nums, target)
    assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__]) 