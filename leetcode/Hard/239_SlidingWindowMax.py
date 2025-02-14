import pytest

class Solution:
    def maxSlidingWindow(self, nums: list[int], k: int) -> list[int]:
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
"""
@pytest.mark.parametrize("nums, k, expected", [
    ([1,3,-1,-3,5,3,6,7], 3, [3,3,5,5,6,7]), 
    ([1], 1, [1])
])
def test_maxSlidingWindow(nums: list[int], k: int, expected: list[int]):
    sol = Solution() 
    result = sol.maxSlidingWindow(nums, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 