import pytest
from typing import List

class Solution:
    def maximumDifference(self, nums: List[int]) -> int:
        maxDiff = 0
        small = nums[0]
        big = nums[0]
        for i in range(1, len(nums)): 
            num = nums[i]
            if num < small: 
                maxDiff = max(maxDiff, big - small)
                small = num
                big = num
            elif num > big:
                big = num
        maxDiff = max(maxDiff, big - small) if big > small or maxDiff > 0 else -1 
        return maxDiff
    

"""
Example 1:

Input: nums = [7,1,5,4]
Output: 4
Explanation:
The maximum difference occurs with i = 1 and j = 2, nums[j] - nums[i] = 5 - 1 = 4.
Note that with i = 1 and j = 0, the difference nums[j] - nums[i] = 7 - 1 = 6, but i > j, so it is not valid.
Example 2:

Input: nums = [9,4,3,2]
Output: -1
Explanation:
There is no i and j such that i < j and nums[i] < nums[j].
Example 3:

Input: nums = [1,5,2,10]
Output: 9
Explanation:
The maximum difference occurs with i = 0 and j = 3, nums[j] - nums[i] = 10 - 1 = 9.
"""
@pytest.mark.parametrize("nums, expected", [
    ([7,1,5,4], 4), 
    ([9,4,3,2], -1), 
    ([1,5,2,10], 9)
])
def test_maximumDifference(nums: List[int], expected: int):
    result = Solution().maximumDifference(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 