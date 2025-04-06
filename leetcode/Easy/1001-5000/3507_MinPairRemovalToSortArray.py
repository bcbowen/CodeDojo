import pytest
from typing import List

class Solution:
    def minimumPairRemoval(self, nums: List[int]) -> int:
        def is_decreasing(): 
            for i in range(1, len(nums)): 
                if nums[i] < nums[i - 1]: 
                    return True
            return False
        
        moves = 0
        while is_decreasing():  
            i = 0
            j = 1
            minIndexes = (0, 1)
            minSum = nums[i] + nums[j]
            sum = minSum
            while j < len(nums) - 1: 
                sum -= nums[i]
                i = j
                j += 1
                sum += nums[j]
                if sum < minSum: 
                    minIndexes = (i, j)
                    minSum = sum
            nums[minIndexes[0]] = minSum
            del nums[minIndexes[1]]
            moves += 1
        
        return moves
"""
Example 1:
Input: nums = [5,2,3,1]

Output: 2

Explanation:

The pair (3,1) has the minimum sum of 4. After replacement, nums = [5,2,4].
The pair (2,4) has the minimum sum of 6. After replacement, nums = [5,6].
The array nums became non-decreasing in two operations.

Example 2:
Input: nums = [1,2,2]

Output: 0

Explanation:

The array nums is already sorted.
"""
@pytest.mark.parametrize("nums, expected", [
    ([5,2,3,1], 2), 
    ([1,2,2], 0), 
    ([5], 0)
])
def test_minimumPairRemoval(nums: List[int], expected: int):
    result = Solution().minimumPairRemoval(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 