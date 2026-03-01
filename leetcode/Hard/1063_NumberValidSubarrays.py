import pytest

from typing import List

class Solution:
    def validSubarrays(self, nums: List[int]) -> int:
        test_len = 2
        array_count = len(nums)
        while test_len < len(nums): 
            for i in range(len(nums) - test_len + 1): 
                section = nums[i: i + test_len]
                if section[0] <= min(section[1:]): 
                    array_count += 1
            test_len += 1
        if nums[0] <= min(nums[1:]): 
            array_count += 1
        return array_count

"""
Example 1:
Input: nums = [1,4,2,5,3]
Output: 11
Explanation: There are 11 valid subarrays: 
[1],[4],[2],[5],[3],
[1,4],[2,5],
[1,4,2],[2,5,3],
[1,4,2,5],
[1,4,2,5,3].

Example 2:
Input: nums = [3,2,1]
Output: 3
Explanation: The 3 valid subarrays are: [3],[2],[1].

Example 3:
Input: nums = [2,2,2]
Output: 6
Explanation: There are 6 valid subarrays: [2],[2],[2],[2,2],[2,2],[2,2,2].
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,4,2,5,3], 11), 
    ([3,2,1], 3), 
    ([2,2,2], 6)
])
def test_validSubarrays(nums: List[int], expected: int): 
    result = Solution().validSubarrays(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])