import pytest

class Solution:
    def runningSum(self, nums: list[int]) -> list[int]:
        result = [0] * len(nums)
        result[0] = nums[0]
        for i in range(1, len(nums)): 
            result[i] = result[i - 1] + nums[i]
        return result

"""
Example 1:
Input: nums = [1,2,3,4]
Output: [1,3,6,10]
Explanation: Running sum is obtained as follows: [1, 1+2, 1+2+3, 1+2+3+4].

Example 2:
Input: nums = [1,1,1,1,1]
Output: [1,2,3,4,5]
Explanation: Running sum is obtained as follows: [1, 1+1, 1+1+1, 1+1+1+1, 1+1+1+1+1].

Example 3:
Input: nums = [3,1,2,10,1]
Output: [3,4,6,16,17]
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,3,4],[1,3,6,10]),
    ([1,1,1,1,1],[1,2,3,4,5]),
    ([3,1,2,10,1],[3,4,6,16,17]) 
])
def test_runningSum(nums: list[int], expected: list[int]): 
    sol = Solution()
    result = sol.runningSum(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])