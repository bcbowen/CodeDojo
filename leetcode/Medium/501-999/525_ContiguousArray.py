import pytest

class Solution:
    def findMaxLength(self, nums: list[int]) -> int:
        max_len = 0
        first_seen = { 0: -1 }
        current_val = 0
        for i, v in enumerate(nums): 
            if v == 0: 
                current_val -= 1
            else: 
                current_val += 1
            
            if not current_val in first_seen: 
                first_seen[current_val] = i
            else: 
                current_len = i - first_seen[current_val]
                max_len = max(max_len, current_len)

        return max_len

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