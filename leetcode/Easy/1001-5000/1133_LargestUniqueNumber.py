import pytest
from collections import defaultdict

class Solution:
    def largestUniqueNumber(self, nums: list[int]) -> int:
        counts = defaultdict(int)
        for num in nums: 
            counts[num] += 1

        largest = -1
        for key in counts.keys(): 
            if counts[key] == 1: 
                largest = max(largest, key)
        return largest

"""
Example 1:
Input: nums = [5,7,3,9,4,9,8,3,1]
Output: 8
Explanation: The maximum integer in the array is 9 but it is repeated. The number 8 occurs only once, so it is the answer.

Example 2:
Input: nums = [9,9,8,8]
Output: -1
Explanation: There is no number that occurs only once.
"""
@pytest.mark.parametrize("nums, expected", [
    ([5,7,3,9,4,9,8,3,1], 8),
    ([9,9,8,8], -1) 
])
def test_largestUniqueNumber(nums: list[int], expected: int):
    sol = Solution()
    result = sol.largestUniqueNumber(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])