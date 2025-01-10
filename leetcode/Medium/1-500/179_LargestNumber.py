import pytest

class Solution:
    def largestNumber(self, nums: list[int]) -> str:
        num_strings = [str(num) for num in nums]
        num_strings.sort(key=lambda f: f * 10, reverse=True)
        if num_strings[0] == "0": 
            return "0"
        return "".join(num_strings)
        

"""
Given a list of non-negative integers nums, arrange them such that they form the largest number and return it.

Since the result may be very large, so you need to return a string instead of an integer.
 
Example 1:
Input: nums = [10,2]
Output: "210"

Example 2:
Input: nums = [3,30,34,5,9]
Output: "9534330"

"""

@pytest.mark.parametrize("nums, expected", [
    ([10,2], "210"), 
    ([3,30,34,5,9], "9534330")
])
def test_longestRepeatingSubstring(nums: list[int], expected: str):
    result = Solution().largestNumber(nums)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])