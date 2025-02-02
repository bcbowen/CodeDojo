import pytest

class Solution:
    def minSubArrayLen(self, target: int, nums: list[int]) -> int:
        if len(nums) == 1: 
            return 1 if nums[0] >= target else 0
        elif nums[0] >= target: 
             return 1
        
        left = 0
        right = 1
        min_len = float('inf')
        total = nums[0] + nums[1]
        while right < len(nums): 
             if total >= target: 
                  current_len = right - left + 1
                  min_len = min(min_len, current_len)
                  total -= nums[left]
                  left += 1
             else: 
                  right += 1
                  if right < len(nums): 
                       total += nums[right]

        return min_len if min_len < float('inf') else 0


"""
Example 1:
Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.

Example 2:
Input: target = 4, nums = [1,4,4]
Output: 1

Example 3:
Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
"""
@pytest.mark.parametrize("target, nums, expected", [
     (7, [2,3,1,2,4,3], 2),
     (4, [1,4,4], 1),
     (11, [1,1,1,1,1,1,1,1], 0),
     (6, [10,2,3], 1)
])
def test_minSubArrayLen(target: int, nums: list[int], expected: int):
        sol = Solution()
        result = sol.minSubArrayLen(target, nums)
        assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])