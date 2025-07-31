import pytest
from typing import List

class Solution:
    def maximumProduct(self, nums: List[int]) -> int:
        if len(nums) == 3: 
            return nums[0] * nums[1] * nums[2]
       

        nums.sort()
        
        if nums[-1] < 0: 
            return nums[-1] * nums[-2] * nums[-3]
       

        if nums[1] < 0: 
            return max(nums[0] * nums[1] * nums[-1], nums[-1] * nums[-2] * nums[-3])
        else: 
            return nums[-1] * nums[-2] * nums[-3]
    
    def maximumProduct_1(self, nums: List[int]) -> int:
        if len(nums) == 3: 
            return nums[0] * nums[1] * nums[2]
       

        nums.sort()
        
        if nums[-1] < 0: 
            return nums[-1] * nums[-2] * nums[-3]
       

        if nums[1] < 0: 
            v1 = nums[0] * nums[1]
            v2 = nums[-1] * nums[-2]
            if v1 > v2 or nums[-3] <= 0: 
                return v1 * nums[-1]
            else: 
                return v2 * nums[-3]
        else: 
            return nums[-1] * nums[-2] * nums[-3]

"""

Example 1:
Input: nums = [1,2,3]
Output: 6

Example 2:
Input: nums = [1,2,3,4]
Output: 24

Example 3:
Input: nums = [-1,-2,-3]
Output: -6

TC 86: 
nums =
[-8,-7,-2,10,20]

Expected
1120

TC 87: 
[-1,-2,-3,-4]

Expected
-6

TC 89
nums =
[3,4,0,0,-1,-5]

Expected
20


"""
@pytest.mark.parametrize("nums, expected", [
    ([1,2,3], 6),
    ([1,2,3,4], 24),
    ([-1,-2,-3], -6),
    ([-8,-7,-2,10,20], 1120), 
    ([-1, -2, -3, -4], -6), 
    ([3,4,0,0,-1,-5], 20)
])
def test_maximumProduct(nums: List[int], expected: int): 
    result = Solution().maximumProduct(nums)
    assert(expected == result)

"""
TC 90
nums =
[722,634,-504,-379,163,-613,-842,-578,750,951,-158,30,-238,-392,-487,-797,-157,-374,999,-5,-521,-879,-858,382,626,803,-347,903,-205,57,-342,186,-736,17,83,726,-960,343,-984,937,-758,-122,577,-595,-544,-559,903,-183,192,825,368,-674,57,-959,884,29,-681,-339,582,969,-95,-455,-275,205,-548,79,258,35,233,203,20,-936,878,-868,-458,-882,867,-664,-892,-687,322,844,-745,447,-909,-586,69,-88,88,445,-553,-666,130,-640,-918,-7,-420,-368,250,-786]

Use Testcase
Output
920597481
Expected
943695360

"""
def test_case_90(): 
    nums = [722,634,-504,-379,163,-613,-842,-578,750,951,-158,30,-238,-392,-487,-797,-157,-374,999,-5,-521,-879,-858,382,626,803,-347,903,-205,57,-342,186,-736,17,83,726,-960,343,-984,937,-758,-122,577,-595,-544,-559,903,-183,192,825,368,-674,57,-959,884,29,-681,-339,582,969,-95,-455,-275,205,-548,79,258,35,233,203,20,-936,878,-868,-458,-882,867,-664,-892,-687,322,844,-745,447,-909,-586,69,-88,88,445,-553,-666,130,-640,-918,-7,-420,-368,250,-786]
    expected = 943695360
    result = Solution().maximumProduct(nums)
    assert(expected == result)

if __name__ == "__main__":
    pytest.main([__file__]) 