from typing import List

import pytest

class Solution:
    def twoSumLessThanK(self, nums: List[int], k: int) -> int:
        nums.sort() 
        left = 0
        result = -1
        for i in range(len(nums) - 1): 
            left = i + 1
            right = len(nums) - 1
            val1 = nums[i]
            val_limit = k - val1
            while left <= right: 
                mid = (right + left) // 2
                test_val = nums[mid]
                if test_val > val_limit: 
                    right = mid - 1
                else: 
                    if test_val < val_limit: 
                        result = max(result, val1 + test_val)
                    left = mid + 1
        return result

"""
Example 1:

Input: nums = [34,23,1,24,75,33,54,8], k = 60
Output: 58
Explanation: We can use 34 and 24 to sum 58 which is less than 60.

Example 2:
Input: nums = [10,20,30], k = 15
Output: -1
Explanation: In this case it is not possible to get a pair sum less that 15.

TC 89: 
nums: [254,914,110,900,147,441,209,122,571,942,136,350,160,127,178,839,201,386,462,45,735,467,153,415,875,282,204,534,639,994,284,320,865,468,1,838,275,370,295,574,309,268,415,385,786,62,359,78,854,944]
k: 200
Output: 198

"""
@pytest.mark.parametrize("nums, k, expected", [
    ([34,23,1,24,75,33,54,8], 60, 58), 
    ([10,20,30], 15, -1), 
    ([254,914,110,900,147,441,209,122,571,942,136,350,160,127,178,839,201,386,462,45,735,467,153,415,875,282,204,534,639,994,284,320,865,468,1,838,275,370,295,574,309,268,415,385,786,62,359,78,854,944], 200, 198)
])
def test(nums: List[int], k: int, expected: int): 
    result = Solution().twoSumLessThanK(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 