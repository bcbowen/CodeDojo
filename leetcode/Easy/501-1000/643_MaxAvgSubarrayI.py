import pytest

class Solution:
    def findMaxAverage(self, nums: list[int], k: int) -> float:
        if k == 1: 
            return max(nums)
        total = nums[0]
        for i in range(1, k): 
            total += nums[i]

        average = total / k
        for  i in range(k, len(nums)): 
            total -= nums[i - k]
            total += nums[i]
            average = max(average, total / k)

        return average

"""
Example 1:
Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

Example 2:
Input: nums = [5], k = 1
Output: 5.00000
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([1,12,-5,-6,50,3], 4, 12.75),
    ([5], 1, 5)
])
def test_findMaxAverage(nums: list[int], k: int, expected: float): 
    sol = Solution()
    result = sol.findMaxAverage(nums, k)
    assert(result == expected)        


if __name__ == "__main__": 
    pytest.main([__file__])