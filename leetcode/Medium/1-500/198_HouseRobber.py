import pytest
from typing import List

class Solution:
    def rob(self, nums: List[int]) -> int:
        pass

"""
Example 1:
Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.

Example 2:
Input: nums = [2,7,9,3,1]
Output: 12
Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
Total amount you can rob = 2 + 9 + 1 = 12.
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,3,1], 4), 
    ([2,7,9,3,1], 12)
])
def rob(nums: List[int], expected: int):
    result = Solution().rob(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])