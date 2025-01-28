import pytest

"""
class Solution:
    def longestOnes(self, nums: List[int], k: int) -> int:
        left = 0
        for right in range(len(nums)):
            # If we included a zero in the window we reduce the value of k.
            # Since k is the maximum zeros allowed in a window.
            k -= 1 - nums[right]
            # A negative k denotes we have consumed all allowed flips and window has
            # more than allowed zeros, thus increment left pointer by 1 to keep the window size same.
            if k < 0:
                # If the left element to be thrown out is zero we increase k.
                k += 1 - nums[left]
                left += 1
        return right - left + 1
"""


class Solution:
    def longestOnes(self, nums: list[int], k: int) -> int:
        
        left = 0
        for right in range(len(nums)): 
            k -= 1 - nums[right]

            if k < 0: 
                k += 1 - nums[left]
                left += 1
        
        return right - left + 1

"""
Example 1:
Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

Example 2:
Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([1,1,1,0,0,0,1,1,1,1,0], 2, 6), 
    ([0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], 3, 10)
])
def test_longestOnes(nums: list[int], k: int, expected: int): 
    sol = Solution()
    result = sol.longestOnes(nums, k)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])