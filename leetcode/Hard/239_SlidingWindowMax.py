from collections import deque
from typing import List 

import pytest

"""
ans = []
        queue = deque()
        for i in range(len(nums)):
            # maintain monotonic decreasing.
            # all elements in the deque smaller than the current one
            # have no chance of being the maximum, so get rid of them
            while queue and nums[i] > nums[queue[-1]]:
                queue.pop()

            queue.append(i)

            # queue[0] is the index of the maximum element.
            # if queue[0] + k == i, then it is outside the window
            if queue[0] + k == i:
                queue.popleft()
            
            # only add to the answer once our window has reached size k
            if i >= k - 1:
                ans.append(nums[queue[0]])

        return ans
"""

class Solution:
    def maxSlidingWindow(self, nums: List[int], k: int) -> List[int]:
        result = []
        queue = deque() 
        for i in range(len(nums)): 
            while queue and nums[i] > nums[queue[-1]]:
                queue.pop() 
            queue.append(i)

            if queue[0] + k == i: 
                queue.popleft()

            if i >= k - 1: 
                result.append(nums[queue[0]])
            
            

        return result

    def maxSlidingWindow_1(self, nums: list[int], k: int) -> list[int]:
        stack = []
        result = [0] * (len(nums) - k + 1)
        i = 0
        while i < k: 
            while stack and stack[-1] < nums[i]: 
                stack.pop() 
            stack.append(nums[i])
            i += 1
        result[0] = stack[0]

        while i < len(nums): 
            if stack[0] == nums[i - k]: 
                stack.pop(0)
            while stack and stack[-1] < nums[i]: 
                stack.pop()
            stack.append(nums[i])
            result[i - k + 1] = stack[0]
            i += 1
            
        return result

"""
Example 1:
Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]

Example 2:
Input: nums = [1], k = 1
Output: [1]


TC 10: 
nums = [3,1,1,3]
k = 3
Expected = [3,3]

"""
@pytest.mark.parametrize("nums, k, expected", [
    ([1,3,-1,-3,5,3,6,7], 3, [3,3,5,5,6,7]), 
    ([1], 1, [1]), 
    ([3,1,1,3], 3, [3,3])
])
def test_maxSlidingWindow(nums: list[int], k: int, expected: list[int]):
    sol = Solution() 
    result = sol.maxSlidingWindow(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 