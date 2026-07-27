import pytest
from typing import List


class Solution:
    def countValidSelections(self, nums: List[int]) -> int:
        result = 0
        for i in range(len(nums)): 
            for d in [1, -1]: 
                if self.is_valid(nums.copy(), i, d):
                    result += 1

        return result 
    
    def is_valid(self, nums: List[int], start_pos: int, direction: int) -> bool: 
        if nums[start_pos] > 0: 
            return False
        
        value_count = len(list(filter(lambda x: x > 0, nums)))
        pos = start_pos

        while pos >= 0 and pos < len(nums) and value_count > 0: 
            if nums[pos] > 0: 
                nums[pos] -= 1
                if nums[pos] == 0: 
                    value_count -= 1
                direction *= -1
            pos += direction


        return value_count == 0

"""
Example 1:
Input: nums = [1,0,2,0,3]

Output: 2
Explanation:
The only possible valid selections are the following:

Choose curr = 3, and a movement direction to the left.
[1,0,2,0,3] -> [1,0,2,0,3] -> [1,0,1,0,3] -> [1,0,1,0,3] -> [1,0,1,0,2] -> [1,0,1,0,2] -> [1,0,0,0,2] -> [1,0,0,0,2] -> [1,0,0,0,1] -> [1,0,0,0,1] -> [1,0,0,0,1] -> [1,0,0,0,1] -> [0,0,0,0,1] -> [0,0,0,0,1] -> [0,0,0,0,1] -> [0,0,0,0,1] -> [0,0,0,0,0].
Choose curr = 3, and a movement direction to the right.
[1,0,2,0,3] -> [1,0,2,0,3] -> [1,0,2,0,2] -> [1,0,2,0,2] -> [1,0,1,0,2] -> [1,0,1,0,2] -> [1,0,1,0,1] -> [1,0,1,0,1] -> [1,0,0,0,1] -> [1,0,0,0,1] -> [1,0,0,0,0] -> [1,0,0,0,0] -> [1,0,0,0,0] -> [1,0,0,0,0] -> [0,0,0,0,0].

Example 2:
Input: nums = [2,3,4,0,4,1,0]

Output: 0

Explanation:

There are no possible valid selections.
"""
@pytest.mark.parametrize("nums, expected", [
    ([1,0,2,0,3], 2), 
    ([2,3,4,0,4,1,0], 0)
])
def test_countValidSelections(nums: List[int], expected: int):
    result = Solution().countValidSelections(nums)
    assert(result == expected)

@pytest.mark.parametrize("nums, start_pos, direction, expected", [
    ([1,0,2,0,3], 3, 1, True), 
    ([1,0,2,0,3], 3, -1, True), 
    ([1,0,2,0,3], 1, 1, False), 
    ([1,0,2,0,3], 1, -1, False), 
    ([1,0,2,0,3], 2, 1, False), 
    ([1,0,2,0,3], 2, -1, False), 
    ([2,3,4,0,4,1,0], 3, 1, False),
    ([2,3,4,0,4,1,0], 3, -1, False),
    ([2,3,4,0,4,1,0], 6, 1, False),
    ([2,3,4,0,4,1,0], 6, -1, False),
    ([2,3,4,0,4,1,0], 5, 1, False),
    ([2,3,4,0,4,1,0], 5, -1, False)
])
def test_is_valid(nums: List[int], start_pos: int, direction: int, expected: bool):
    result = Solution().is_valid(nums, start_pos, direction)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
