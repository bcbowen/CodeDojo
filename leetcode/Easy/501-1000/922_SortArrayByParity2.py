import pytest

from typing import List

class Solution:
    def sortArrayByParityII(self, nums: List[int]) -> List[int]:
        is_even = lambda x: x % 2 == 0

        i = 0

        while i < len(nums): 
            j = i + 1
            if j >= len(nums): 
                break

            if is_even(i): 
                if not is_even(nums[i]): 
                    while is_even(nums[j]): 
                        j += 2
                    nums[i], nums[j] = nums[j], nums[i]
            else: 
                if is_even(nums[i]): 
                    while is_even(nums[j]):
                        j += 2
                    nums[i], nums[j] = nums[j], nums[i]
            i += 1
                    
        return nums
    
"""
Example 1:
Input: nums = [4,2,5,7]
Output: [4,5,2,7]
Explanation: [4,7,2,5], [2,5,4,7], [2,7,4,5] would also have been accepted.

Example 2:
Input: nums = [2,3]
Output: [2,3]

"""
@pytest.mark.parametrize("nums", [
    [4, 2, 5, 7], 
    [2, 3], 
    [3, 4], 
    [5, 2, 7, 4]
])
def test_sortArrayByParityII(nums: List[int]):
    result = Solution().sortArrayByParityII(nums)
    assert(check_result(result))    

@pytest.mark.parametrize("nums, expected", [
    ([0, 1, 2, 3, 4, 5], True),
    ([1, 2, 3, 4, 5], False),
    ([0], True),
    ([0, 1], True),
    ([1], False), 
    ([0, 1, 1], False), 
    ([0, 2], False)
])
def test_check_result(nums : List[int], expected: bool): 
    result = check_result(nums)
    assert(result == expected)

def check_result(result: List[int]) -> bool: 
    for i in range(len(result)):
        if i % 2 == 0: 
            if result[i] % 2 != 0: 
                return False
        else: 
            if result[i] % 2 == 0: 
                return False

    return True 

if __name__ == "__main__":
    pytest.main([__file__]) 