import pytest

class Solution:
    def moveZeroes(self, nums: list[int]) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        #num = 0
        #zero = 0
        list_len = len(nums)
        for i in range(list_len): 
            if nums[i] == 0: 
                for j in range(i + 1, list_len): 
                    if nums[j] != 0: 
                        nums[i], nums[j] = nums[j], nums[i]
                        break
            

"""
Example 1:
Input: nums = [0,1,0,3,12]
Output: [1,3,12,0,0]

Example 2:
Input: nums = [0]
Output: [0]
"""
@pytest.mark.parametrize("nums, expected", [
    ([0,1,0,3,12], [1,3,12,0,0]),
    ([1, 2, 3, 4, 5], [1, 2, 3, 4, 5]),
    ([1, 0], [1, 0]),
    ([0, 0, 0, 0], [0, 0, 0, 0]),   
    ([0], [0])
])
def test_moveZeroes(nums: list[int], expected: list[int]): 
    sol = Solution()
    sol.moveZeroes(nums)
    assert(nums == expected)

if __name__ == "__main__": 
    pytest.main([__file__])