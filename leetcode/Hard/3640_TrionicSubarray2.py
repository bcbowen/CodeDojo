import pytest

from typing import List


class Solution:
    def maxSumTrionic(self, nums: List[int]) -> int:
        changes = []
        is_decreasing = False 
        is_increasing = False 
        total = 0

        for i in range(1, len(nums)): 
            if nums[i] > nums[i - 1]: 
                if is_decreasing: 
                    changes.append(total)
                    total = nums[i]
                    is_decreasing = False
                elif not is_increasing: 
                    
                    total = nums[i]
                else: 
                    total += nums[i]
                is_increasing = True
            else: 
                if is_increasing: 
                    changes.append(total)
                    total = nums[i]
                    is_increasing = False
                elif not is_decreasing:
                    total = nums[i]
                else: 
                    total += nums[i]
                is_decreasing = True

        max_sum = -(10**10)
        for i in range(2, len(nums)): 
            if nums[i] > 0: 
                max_sum = max(max_sum, sum(nums[i - 2:i + 1]))
        return max_sum


"""
Example 1:

Input: nums = [0,-2,-1,-3,0,2,-1]
Output: -4
Explanation:

Pick l = 1, p = 2, q = 3, r = 5:

nums[l...p] = nums[1...2] = [-2, -1] is strictly increasing (-2 < -1).
nums[p...q] = nums[2...3] = [-1, -3] is strictly decreasing (-1 > -3)
nums[q...r] = nums[3...5] = [-3, 0, 2] is strictly increasing (-3 < 0 < 2).
Sum = (-2) + (-1) + (-3) + 0 + 2 = -4.

Example 2:

Input: nums = [1,4,2,7]
Output: 14
Explanation:

Pick l = 0, p = 1, q = 2, r = 3:

nums[l...p] = nums[0...1] = [1, 4] is strictly increasing (1 < 4).
nums[p...q] = nums[1...2] = [4, 2] is strictly decreasing (4 > 2).
nums[q...r] = nums[2...3] = [2, 7] is strictly increasing (2 < 7).
Sum = 1 + 4 + 2 + 7 = 14.
"""
@pytest.mark.parametrize("nums, expected", [
    ([0,-2,-1,-3,0,2,-1], -4),
    ([1,4,2,7], 14) 
])
def test_maxSumTrionic(nums: List[int], expected: int):
    result = Solution().maxSumTrionic(nums)
    assert(result == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 