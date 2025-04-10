import pytest
from typing import List, Tuple
from functools import lru_cache

class Solution:
    def canPartition(self, nums: List[int]) -> bool:
       @lru_cache(maxsize=None)
       def dfs(nums: Tuple[int], n: int, subset_sum: int) -> bool:
        if subset_sum == 0:
           return True
        if n == 0 or subset_sum < 0:
           return False
        result = (dfs(nums, n - 1, subset_sum - nums[n - 1])
          or dfs(nums, n - 1, subset_sum))

        return result

       full_value = sum(nums)
       if full_value % 2 != 0:
          return False
       half_value = full_value // 2
       n = len(nums)
       return dfs(tuple(nums), n - 1, half_value)



"""
Example 1:
Input: nums = [1,5,11,5]
Output: true
Explanation: The array can be partitioned as [1, 5, 5] and [11].

Example 2:
Input: nums = [1,2,3,5]
Output: false
Explanation: The array cannot be partitioned into equal sum subsets.
"""
@pytest.mark.parametrize("nums, expected", [
  ([1,5,11,5], True),
  ([1,2,3,5], False),
  ([2,3,4,5], True),
  ([4,8,7,1], False) # 1, 4, 7 - 8
])
def test_canPartition(nums: List[int], expected: bool):
    result = Solution().canPartition(nums)
    assert(result == expected)

if __name__ == "__main__":
  pytest.main([__file__])