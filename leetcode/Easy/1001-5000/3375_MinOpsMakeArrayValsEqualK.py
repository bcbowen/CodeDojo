import pytest
from typing import List

class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        nums.sort()
        numSet = set(nums)
        if nums[0] < k: 
            return - 1
        elif nums[0] == k: 
            return len(numSet) - 1
        else: 
            return len(numSet)



"""
Example 1:
Input: nums = [5,2,5,4,5], k = 2
Output: 2
Explanation:
The operations can be performed in order using valid integers 4 and then 2.

Example 2:
Input: nums = [2,1,2], k = 2
Output: -1
Explanation:
It is impossible to make all the values equal to 2.

Example 3:
Input: nums = [9,7,5,3], k = 1
Output: 4
Explanation:
The operations can be performed using valid integers in the order 7, 5, 3, and 1.

"""
@pytest.mark.parametrize("nums, k, expected", [
    ([5,2,5,4,5], 2, 2), 
    ([2,1,2], 2, -1), 
    ([9,7,5,3], 1, 4)     
])
def test_minOperations(nums: List[int], k: int, expected: int):
    result = Solution().minOperations(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 