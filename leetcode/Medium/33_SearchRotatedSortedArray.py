import pytest

class Solution:
    def search(self, nums: list[int], target: int) -> int:
        
        if len(nums) == 0: 
            return -1
        elif len(nums) == 1: 
            return 0 if nums[0] == target else -1
        
        offset, nums = self.depivot(nums)
        
        i = -1
        l = 0
        r = len(nums) - 1
        while l <= r: 
            mid = (l + r) // 2
            if nums[mid] == target: 
                i = mid
                break
            if nums[mid] < target: 
                l = mid + 1
            else: 
                r = mid - 1

        result = i + offset if i > -1 else i
        if result >= len(nums): 
            result = result - len(nums);
        return result
    
    def depivot(self, nums: list[int]) ->  tuple[int, list[int]]:
        if nums[0] < nums[-1] or len(nums) < 2: 
            return (0, nums)

        p = -1
        l = 0
        r = len(nums) - 1
        # find first index where i + 1 < i
        while l < r: 
            mid = (l + r) // 2
            if nums[mid] < nums[mid - 1]:
                p = mid
                break
            if nums[mid] > nums[mid + 1]:
                p = mid + 1
                break
            if nums[mid] > nums[0]:
                l = mid + 1
            else: 
                r = mid - 1

        if p == -1: 
            raise Exception("pivot not found")
        return (p, nums[p:] + nums[0:p])
        

"""

There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index 
k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of 
target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:
Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1

Example 3:
Input: nums = [1], target = 0
Output: -1

"""

@pytest.mark.parametrize("nums, target, expected", [
    ([4,5,6,7,0,1,2], 0, 4),
    ([4,5,6,7,0,1,2], 3, -1),
    ([3,1], 3, 0),
    ([1], 0, -1), 
    ([3, 5, 1], 5, 1)
])
def test_search(nums: list[int], target: int, expected: int):
    result = Solution().search(nums, target)
    assert result == expected

@pytest.mark.parametrize("nums, expected", [
    ([4,5,6,7,8,9,10,11,12,13,14,15,16,17,0,1,2], (14, [0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17])),
    ([15,16,17,0,1,2,4,5,6,7,8,9,10,11,12,13,14], (3, [0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17])),
    ([1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17,0], (16, [0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17])),
    ([17,0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16], (1, [0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17])),
    ([0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17], (0, [0,1,2,4,5,6,7,8,9,10,11,12,13,14,15,16,17])),
    ([0,1,2,4,5,6,7], (0, [0,1,2,4,5,6,7])),
    ([1], (0, [1])), 
    ([2, 1], (1, [1, 2])), 
    ([1, 2], (0, [1, 2])), 
    ([3, 5, 1], (2, [1, 3, 5]))
])
def test_depivot(nums: list[int], expected: tuple[int, list[int]]):
    result = Solution().depivot(nums)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])