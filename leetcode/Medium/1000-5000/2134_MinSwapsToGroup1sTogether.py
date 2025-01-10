import pytest

class Solution:
    def minSwaps(self, nums: list[int]) -> int:
        # get count of 1s
        count = 0
        for num in nums: 
            if num == 1: 
                count += 1
        
        if count == 0: 
            return count

        # simplify the wraparound by appending the first count - 1 to the end of the array
        nums.extend(nums[0:count - 1])

        # sliding window to find min gaps
        gap = 0
        if nums[0] == 0: 
            gap += 1
        
        r = 0
        while r < count - 1: 
            r += 1
            if nums[r] == 0: 
                gap += 1
        min = gap

        l = 0
        # slide window and adjust gap
        while r < len(nums) - 1: 
            if nums[l] == 0: 
                gap -= 1
            l += 1
            r += 1
            if nums[r] == 0: 
                gap += 1
            if gap < min: 
                min = gap
        
        return min


"""
A swap is defined as taking two distinct positions in an array and 
swapping the values in them.

A circular array is defined as an array where we consider the first 
element and the last element to be adjacent.

Given a binary circular array nums, return the minimum number of 
swaps required to group all 1's present in the array together at any 
location.

 

Example 1:
Input: nums = [0,1,0,1,1,0,0]
Output: 1
Explanation: Here are a few of the ways to group all the 1's together:
[0,0,1,1,1,0,0] using 1 swap.
[0,1,1,1,0,0,0] using 1 swap.
[1,1,0,0,0,0,1] using 2 swaps (using the circular property of the array).
There is no way to group all 1's together with 0 swaps.
Thus, the minimum number of swaps required is 1.

Example 2:
Input: nums = [0,1,1,1,0,0,1,1,0]
Output: 2
Explanation: Here are a few of the ways to group all the 1's together:
[1,1,1,0,0,0,0,1,1] using 2 swaps (using the circular property of the array).
[1,1,1,1,1,0,0,0,0] using 2 swaps.
There is no way to group all 1's together with 0 or 1 swaps.
Thus, the minimum number of swaps required is 2.

Example 3:
Input: nums = [1,1,0,0,1]
Output: 0
Explanation: All the 1's are already grouped together due to the circular property of the array.
Thus, the minimum number of swaps required is 0.
"""

@pytest.mark.parametrize("nums, expected", [
    ([0,1,0,1,1,0,0], 1),
    ([0,1,1,1,0,0,1,1,0], 2),
    ([1,1,0,0,1], 0), 
    ([0,0,0], 0)
])
def test_minSwaps(nums: list[int], expected: int):
    result = Solution().minSwaps(nums)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])

