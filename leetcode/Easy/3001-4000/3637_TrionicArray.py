import pytest

from typing import List

class Solution:
    def isTrionic(self, nums: List[int]) -> bool:
        is_increasing = False 
        is_decreasing = False 
        sections = 0

        for i in range(1, len(nums)): 
            if nums[i] == nums[i - 1]: 
                return False
            
            if nums[i] > nums[i - 1]:

                if not is_increasing:
                    sections += 1
                    is_increasing = True
                    is_decreasing = False
                    

            elif nums[i] < nums[i - 1]: 
                if sections > 1 and not is_decreasing: 
                    # we had an increasing and decreasing section, we expect to increase to the end
                    return False
                if sections == 0: 
                    # we have a decrease before we've had an increase
                    return False
                
                if is_increasing: 
                    is_increasing = False
                    sections += 1
                    is_decreasing = True


        return sections == 3

"""
Example 1:

Input: nums = [1,3,5,4,2,6]
Output: true

Explanation:

Pick p = 2, q = 4:

nums[0...2] = [1, 3, 5] is strictly increasing (1 < 3 < 5).
nums[2...4] = [5, 4, 2] is strictly decreasing (5 > 4 > 2).
nums[4...5] = [2, 6] is strictly increasing (2 < 6).

Example 2:
Input: nums = [2,1,3]
Output: false
Explanation:
There is no way to pick p and q to form the required three segments.

TC 801
[8,9,4,6,1]: False

TC 578
[5,9,1,7]: True

TC 862
[4,1,5,2,3] False

"""
@pytest.mark.parametrize("nums, expected", [
    ([1,3,5,4,2,6], True), 
    ([2,1,3], False), 
    ([8,9,4,6,1], False), 
    ([5,9,1,7], True), 
    ([4,1,5,2,3], False)
])
def test_is_trionic(nums: List[int], expected: bool): 
    result = Solution().isTrionic(nums)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 