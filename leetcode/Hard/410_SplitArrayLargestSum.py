import pytest
from typing import List

class Solution:
    def splitArray(self, nums: List[int], k: int) -> int:
        def try_value(val: int) -> int:
            group_count = 0
            running_total = 0
            for num in nums: 
                if running_total + num <= val: 
                    running_total += num
                else: 
                    running_total = num
                    group_count += 1
            return group_count + 1
        
        left = max(nums)
        right = sum(nums)
        while (left <= right): 
            mid = (left + right) // 2
            if try_value(mid) <= k: 
                right = mid - 1
                min_largest_sum = mid
            else: 
                left = mid + 1
        return min_largest_sum

"""
Example 1:
Input: nums = [7,2,5,10,8], k = 2
Output: 18
Explanation: There are four ways to split nums into two subarrays.
The best way is to split it into [7,2,5] and [10,8], where the largest sum among the two subarrays is only 18.

Example 2:
Input: nums = [1,2,3,4,5], k = 2
Output: 9
Explanation: There are four ways to split nums into two subarrays.
The best way is to split it into [1,2,3] and [4,5], where the largest sum among the two subarrays is only 9.
 
"""
@pytest.mark.parametrize("nums, k, expected", [
     ([7,2,5,10,8], 2, 18), 
     ([1,2,3,4,5], 2, 9)
])
def test_splitArray(nums: List[int], k: int, expected: int):
    result = Solution().splitArray(nums, k)
    assert(result == expected)
    
if __name__ == "__main__": 
    pytest.main([__file__])