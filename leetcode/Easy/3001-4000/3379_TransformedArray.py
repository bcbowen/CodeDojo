import pytest

from typing import List

class Solution:
    def get_wraparound_value(self, nums: List[int], index: int) -> int: 
        moves = nums[index]
        if moves == 0: 
            return nums[index]
        
        if moves > 0: 
            if index + moves < len(nums): 
                return nums[index + moves]
            else: 
                moves -= len(nums) - index
                return nums[moves - 1]
        else: 
            if index + moves >= 0: 
                return nums[index + moves]
            else: 
                moves -= index
                return nums[len(nums) - moves]

    def constructTransformedArray(self, nums: List[int]) -> List[int]:
        result = [0] * len(nums)
        for i, n in enumerate(nums): 
            v = n % len(nums)
            
            if v > 0: 
                if i + v < len(nums): 
                    pass
                else: 
                    pass
            else: 
                pass

        return result

"""
Example 1:

Input: nums = [3,-2,1,1]

Output: [1,1,1,3]

Explanation:

For nums[0] that is equal to 3, If we move 3 steps to right, we reach nums[3]. So result[0] should be 1.
For nums[1] that is equal to -2, If we move 2 steps to left, we reach nums[3]. So result[1] should be 1.
For nums[2] that is equal to 1, If we move 1 step to right, we reach nums[3]. So result[2] should be 1.
For nums[3] that is equal to 1, If we move 1 step to right, we reach nums[0]. So result[3] should be 3.

Example 2:
Input: nums = [-1,4,-1]

Output: [-1,-1,4]

Explanation:

For nums[0] that is equal to -1, If we move 1 step to left, we reach nums[2]. So result[0] should be -1.
For nums[1] that is equal to 4, If we move 4 steps to right, we reach nums[2]. So result[1] should be -1.
For nums[2] that is equal to -1, If we move 1 step to left, we reach nums[1]. So result[2] should be 4.
"""
@pytest.mark.parametrize("nums, expected", [
    ([3,-2,1,1], [1,1,1,3]), 
    ([-1,4,-1], [-1,-1,4])
])
def test_constructTransformedArray(nums: List[int], expected: List[int]):
    result = Solution().constructTransformedArray(nums)
    assert(result == expected)

@pytest.mark.parametrize("nums, index, expected", [
    ([1, 2, 3, 4], 0, 2),
    ([1, 2, 3, 4], 1, 4),
    ([4, 3, 1, 2], 2, 2),
    ([4, 2, 3, 1], 3, 4),
    ([4, 2, 3, 1], 0, 4),
    ([1, -1, 3, 4], 1, 1),
    ([1, 2, -2, 4], 2, 1),
    ([4, 3, -3, 2], 2, 2),
    ([4, 2, 3, -4], 3, -4),
    ([-1, 2, 3, 1], 0, 1), 
])
def test_get_wraparound_value(nums: List[int], index: int, expected: int):
    result = Solution().get_wraparound_value(nums, index)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 