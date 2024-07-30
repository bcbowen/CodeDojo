import pytest

class Solution(object):
    def frequencySort(self, nums):
        """
        :type nums: List[int]
        :rtype: List[int]
        """
        num_counts = {}
        for num in nums: 
            if not num in num_counts: 
                num_counts[num] = 0
            num_counts[num] += 1

        return sorted(nums, key=lambda x: (num_counts[x], -x))
    
"""
Given an array of integers nums, sort the array in increasing order based on the frequency of the values. If multiple values have the same frequency, sort them in decreasing order.

Return the sorted array.

Example 1:
Input: nums = [1,1,2,2,2,3]
Output: [3,1,1,2,2,2]
Explanation: '3' has a frequency of 1, '1' has a frequency of 2, and '2' has a frequency of 3.

Example 2:
Input: nums = [2,3,1,3,2]
Output: [1,3,3,2,2]
Explanation: '2' and '3' both have a frequency of 2, so they are sorted in decreasing order.
"""

# nums, outputs
"""
run_cases = [
    ([1,1,2,2,2,3], [3,1,1,2,2,2]),
    ([2,3,1,3,2],[1,3,3,2,2])
]
"""

@pytest.mark.parametrize("nums, expected", [
    ([1,1,2,2,2,3], [3,1,1,2,2,2]),
    ([2,3,1,3,2], [1,3,3,2,2])
])
def test_frequencySort(nums, expected):
    result = Solution().frequencySort(nums)
    #print(f"hey dude {names} {heights} --> {result} [{expected}] ")
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])