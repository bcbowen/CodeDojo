import pytest
from typing import List

class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        j = 0
        swaps = 0
        last = nums[0]
        current = 0
        result = [ nums[0] ]
        for i in range(1, len(nums)): 
            if nums[i] >= last: 
                result.append(nums[i])
                j += 1
                last = nums[i]
                current = 0
            elif current >= last: 
                result.append(current)
                last = current
                current = 0
                j += 1
            elif i < len(nums) - 1: 
                current += nums[i]
                swaps += 1
            else: 
                result[j - 1] += nums[i]
                swaps += 1
        return swaps
"""
Example 1:
Input: nums = [5,2,3,1]

Output: 2

Explanation:

The pair (3,1) has the minimum sum of 4. After replacement, nums = [5,2,4].
The pair (2,4) has the minimum sum of 6. After replacement, nums = [5,6].
The array nums became non-decreasing in two operations.

Example 2:
Input: nums = [1,2,2]

Output: 0

TC 245
[2,2,-1,3,-2,2,1,1,1,0,-1]
output: 9

Explanation:

The array nums is already sorted.
"""
@pytest.mark.parametrize("nums, expected", [
    ([5,2,3,1], 2), 
    ([1,2,2], 0), 
    ([5], 0), 
    ([2,2,-1,3,-2,2,1,1,1,0,-1], 9)
])
def test_minimumPairRemoval(nums: List[int], expected: int):
    result = Solution().minimumPairRemoval(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 