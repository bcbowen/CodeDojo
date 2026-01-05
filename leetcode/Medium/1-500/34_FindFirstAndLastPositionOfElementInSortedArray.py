import pytest

from typing import List

class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        begin = -1
        end = -1

        if len(nums) == 1: 
            if nums[0] == target: 
                return [0, 0]
            else:
                return [begin, end]

        left = 0
        right = len(nums) - 1
        while left <= right: 
            mid = (left + right) // 2
            if nums[mid] == target: 
                begin = self.find_left_edge(nums[0:mid + 1], target)
                end = mid + self.find_right_edge(nums[mid:], target)
                break
            elif nums[mid] < target: 
                left = mid + 1
            else: 
                right = mid - 1 

        return [begin, end]
    
    def find_left_edge(self, nums: List[int], target: int) -> int: 
        if nums[0] == target: 
            return 0
        
        left = 0
        right = len(nums) - 1
        
        while left <= right: 
            mid = (right + left) // 2
            if nums[mid] == target: 
                if mid > 0 and nums[mid - 1] < target: 
                    return mid
                else: 
                    right = mid - 1
            else: 
                if nums[mid + 1] == target: 
                    return mid + 1
                else: 
                    left = mid + 1

        return -1

    def find_right_edge(self, nums: List[int], target: int) -> int: 
        if nums[-1] == target: 
            return len(nums) - 1
        
        left = 0
        right = len(nums) - 1
        
        while left <= right: 
            mid = (right + left) // 2
            if nums[mid] == target: 
                if nums[mid + 1] > target: 
                    return mid
                else: 
                    left = mid + 1
            else: 
                if nums[mid - 1] == target: 
                    return mid - 1
                else: 
                    right = mid - 1

        return -1

"""
Example 1:
Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]

Example 2:
Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]

Example 3:
Input: nums = [], target = 0
Output: [-1,-1]

TC 5: 
[1] target = 1 out = [1, 1]

TC8
[2, 2] t = 2, out = [0, 1]

TC 67
[1,2,3] target = 1 [0, 0]
"""
@pytest.mark.parametrize("nums, target, expected", [
    ([5,7,7,8,8,10], 8, [3, 4]), 
    ([5,7,7,8,8,10], 6, [-1, -1]), 
    ([], 0, [-1, -1]), 
    ([1], 1, [0, 0]), 
    ([2, 2], 2, [0, 1]), 
    ([1, 2, 3], 1, [0, 0])
])    
def test_searchRange(nums: List[int], target: int, expected: List[int]):
    result = Solution().searchRange(nums, target)
    assert(result == expected)

@pytest.mark.parametrize("nums, target, expected", [
    ([1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6], 6, 5),
    ([1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6], 6, 5), 
    ([1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6], 6, 5), 
    ([1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6], 6, 5),
    ([1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6], 6, 5)
])

def test_find_left_edge(nums: List[int], target: int, expected: int):
    result = Solution().find_left_edge(nums, target)
    assert(expected == result)

@pytest.mark.parametrize("nums, target, expected", [
    ([6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 8, 9, 10], 6, 15),
    ([6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 8, 9, 10], 6, 15), 
    ([6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 8, 9, 10], 6, 15), 
    ([6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 8, 9, 10], 6, 15),
    ([6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 8, 9, 10], 6, 15)
])

def test_find_right_edge(nums: List[int], target: int, expected: int):
    result = Solution().find_right_edge(nums, target)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__])