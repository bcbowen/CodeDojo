import math
import pytest
from typing import List

class Solution:
    def smallestDivisor(self, nums: List[int], threshold: int) -> int:
        def test_value(d: int) -> bool: 
            sum = 0
            for num in nums: 
                sum += math.ceil(num / d)
            return sum <= threshold
        
        left = 1
        right = max(nums)
        while left <= right:
            mid = (left + right) // 2
            if test_value(mid): 
                right = mid - 1
            else: 
                left = mid + 1
        return left
      

"""
Example 1:
Input: nums = [1,2,5,9], threshold = 6
Output: 5
Explanation: We can get a sum to 17 (1+2+5+9) if the divisor is 1. 
If the divisor is 4 we can get a sum of 7 (1+1+2+3) 
and if the divisor is 5 the sum will be 5 (1+1+1+2). 

Example 2:
Input: nums = [44,22,33,11,1], threshold = 5
Output: 44
"""
@pytest.mark.parametrize("nums, threshold, expected", [
    ([1,2,5,9], 6, 5), 
    ([44,22,33,11,1], 5, 44)
])
def test_smallestDivisor(nums: List[int], threshold: int, expected: int):
    result = Solution().smallestDivisor(nums, threshold)
    assert(result == expected)
    
if __name__ == "__main__":
    pytest.main([__file__]) 