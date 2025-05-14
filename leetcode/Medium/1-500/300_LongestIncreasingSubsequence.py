import pytest
from typing import List

class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        if not nums: 
            return 0
        
        vals = [1] * len(nums)
        for i in range(len(vals)): 
            for j in range(i): 
                if nums[j] < nums[i]: 
                    vals[i] = max(vals[i], vals[j] + 1)
        return max(vals)

        """
        cache = {}
        def dp(index: int) -> int: 
            if index in cache: 
                return cache[index]
            if index == 0: 
                cache[index] = 1
            elif nums[index] <= nums[index - 1]: 
                cache[index] = dp(index - 1)
            else: 
                cache[index] = dp(index - 1) + 1
            return cache[index]
        """
        
        #return dp(len(nums) - 1)


"""
Example 1:
Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.

Example 2:
Input: nums = [0,1,0,3,2,3]
Output: 4

Example 3:
Input: nums = [7,7,7,7,7,7,7]
Output: 1
"""
@pytest.mark.parametrize("nums, expected", [
    ([10,9,2,5,3,7,101,18], 4), 
    ([0,1,0,3,2,3], 4), 
    ([7,7,7,7,7,7,7], 1), 
    ([4,10,4,3,8,9], 3)
])
def test_lengthOfLIS(nums: List[int], expected: int):
    result = Solution().lengthOfLIS(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])