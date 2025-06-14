import pytest
from typing import List

class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        result = 0
        for num in nums: 
            mask = num
            result ^= mask
        return result
    

"""
Example 1:
Input: nums = [2,2,1]
Output: 1

Example 2:
Input: nums = [4,1,2,1,2]
Output: 4

Example 3:
Input: nums = [1]
Output: 1
"""
@pytest.mark.parametrize("nums, expected", [
    ([2,2,1], 1),
    ([4,1,2,1,2], 4),
    ([1], 1)
])
def test_singleNumber(nums: List[int], expected: int):
    result = Solution().singleNumber(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])