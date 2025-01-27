import pytest

class Solution:
    def waysToSplitArray(self, nums: list[int]) -> int:
        prefixes = [0] * len(nums)
        prefixes[0] = nums[0]
        for i in range(1, len(nums)): 
            prefixes[i] = prefixes[i - 1] + nums[i]

        count  = 0 

        for i in range(len(prefixes) - 1): 
            if prefixes[i] >= prefixes[-1] - prefixes[i]: 
                count += 1

        return count


"""
Example 1:
Input: nums = [10,4,-8,7]
Output: 2
Explanation: 
There are three ways of splitting nums into two non-empty parts:
- Split nums at index 0. Then, the first part is [10], and its sum is 10. The second part is [4,-8,7], and its sum is 3. Since 10 >= 3, i = 0 is a valid split.
- Split nums at index 1. Then, the first part is [10,4], and its sum is 14. The second part is [-8,7], and its sum is -1. Since 14 >= -1, i = 1 is a valid split.
- Split nums at index 2. Then, the first part is [10,4,-8], and its sum is 6. The second part is [7], and its sum is 7. Since 6 < 7, i = 2 is not a valid split.
Thus, the number of valid splits in nums is 2.

Example 2:
Input: nums = [2,3,1,0]

Output: 2
Explanation: 
There are two valid splits in nums:
- Split nums at index 1. Then, the first part is [2,3], and its sum is 5. The second part is [1,0], and its sum is 1. Since 5 >= 1, i = 1 is a valid split. 
- Split nums at index 2. Then, the first part is [2,3,1], and its sum is 6. The second part is [0], and its sum is 0. Since 6 >= 0, i = 2 is a valid split.
"""
@pytest.mark.parametrize("nums, expected", [
    ([10,4,-8,7], 2), 
    ([2,3,1,0], 2), 
    ([6, -1, 9], 0),
    ([0, 0], 1)
])
def test_waysToSplitArray(nums: list[int], expected: int):
    sol = Solution() 
    result = sol.waysToSplitArray(nums)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])