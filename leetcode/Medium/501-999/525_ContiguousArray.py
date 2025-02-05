import pytest

class Solution:
    def findMaxLength(self, nums: list[int]) -> int:
        ones = 0
        zeros = 0

        left = 0
        for right in range(len(nums)): 
            if nums[right] == 0: 
                zeros += 1
            else: 
                ones += 1

        

        """
        total = 0
        #last = 0
        max_diff = 0

        
        for i, v in enumerate(nums): 
            if v == 0: 
                total -= 1
            else: 
                total += 1

            if total == 0: 
                #diff = i - last + 1
                max_diff = i + 1 #max(diff, max_diff)
                #last = i
        return max_diff
        """
"""
Example 1:
Input: nums = [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with an equal number of 0 and 1.

Example 2:
Input: nums = [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
"""
@pytest.mark.parametrize("nums, expected", [
    ([0,1], 2), 
    ([0,1,0], 2),
    ([0,1,0,1], 4), 
    ([0,0,1,0,0,0,1,1], 6),
    ([0,1,0,0,0,1,0,0,0,0,0,1], 2) 
])
def test_findMaxLength(nums: list[int], expected: int):
    sol = Solution() 
    result = sol.findMaxLength(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])