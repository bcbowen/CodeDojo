import pytest
from typing import List

class Solution:
    def searchInsert(self, nums: List[int], target: int) -> int:
        if target < nums[0]:
            return 0
        if target > nums[-1]:
            return len(nums)

        left = 0
        right = len(nums) - 1
        mid = 0
        while left <= right:
            mid = left + (right - left) // 2
            if nums[mid] == target:
                return mid
            elif nums[mid] < target:
                if mid < len(nums) - 1 and nums[mid + 1] > target:
                    return mid + 1
                else:
                    left = mid + 1
            else:
                if mid > 0 and nums[mid - 1] < target:
                    return mid
                else:
                  right = mid - 1
        return mid
"""
Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4
"""
@pytest.mark.parametrize("nums, target, expected", [
     ([1,3,5,6], 5, 2),
     ([1,3,5,6], 2, 1),
     ([1,3,5,6], 7, 4),
     ([3], 2, 0),
     ([3], 4, 1)
])
def test_searchInsert(nums: List[int], target: int, expected: int):
      result = Solution().searchInsert(nums, target)
      assert(result == expected)

if __name__ == "__main__":
  pytest.main([__file__])