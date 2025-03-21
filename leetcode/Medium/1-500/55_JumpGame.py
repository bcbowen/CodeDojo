import pytest
from collections import deque

class Solution:
    def canJump(self, nums: list[int]) -> bool:
        if len(nums) == 1: 
            return True
        seen = [False] * len(nums)
        queue = deque([0])
        while queue: 
            pos = queue.popleft() 
            seen[pos] = True
            leap_range = nums[pos] 
            if pos + leap_range >= len(nums) - 1:
                return True
            for leap in range(1,leap_range + 1): 
                next_pos = pos + leap
                if next_pos < len(nums) and not seen[next_pos]: 
                    queue.append(next_pos)
        return False

"""
Example 1:
Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

Example 2:
Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
"""
@pytest.mark.parametrize("nums, expected", [
    ([2,3,1,1,4], True), 
    ([3,2,1,0,4], False), 
    ([2,0,0], True),
    ([0], True), 
    ([2,0], True), 
    ([1,2,3], True)
])
def test_canJump(nums: list[int], expected: bool):
    result = Solution().canJump(nums)
    assert(result == expected) 

if __name__ == "__main__":
    pytest.main([__file__]) 