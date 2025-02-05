import pytest

class Solution:
    def minStartValue(self, nums: list[int]) -> int:
      
        running_sum = [0] * len(nums)
        min = nums[0]
        running_sum[0] = nums[0]
        for i in range(1, len(nums)): 
            running_sum[i] = running_sum[i - 1] + nums[i]
            if running_sum[i] < min: 
                min = running_sum[i]
        if min > 0: 
            return 1
        else: 
            return -(min) + 1

"""
Example 1:
Input: nums = [-3,2,-3,4,2]
Output: 5
Explanation: If you choose startValue = 4, in the third iteration your step by step sum is less than 1.
step by step sum
startValue = 4 | startValue = 5 | nums
  (4 -3 ) = 1  | (5 -3 ) = 2    |  -3
  (1 +2 ) = 3  | (2 +2 ) = 4    |   2
  (3 -3 ) = 0  | (4 -3 ) = 1    |  -3
  (0 +4 ) = 4  | (1 +4 ) = 5    |   4
  (4 +2 ) = 6  | (5 +2 ) = 7    |   2

Example 2:
Input: nums = [1,2]
Output: 1
Explanation: Minimum start value should be positive. 

Example 3:
Input: nums = [1,-2,-3]
Output: 5
"""
@pytest.mark.parametrize("nums, expected", [
    ([-3,2,-3,4,2], 5),
    ([1,2], 1),
    ([1,-2,-3], 5),
    ([-12], 13), 
    ([-3,6,2,5,8,6], 4)
])
def test_minStartValue(nums: list[int], expected: int): 
    sol = Solution()
    result = sol.minStartValue(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])